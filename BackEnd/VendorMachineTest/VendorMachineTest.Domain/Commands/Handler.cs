using MediatR;
using VendorMachineTest.Domain.Commands.Product;
using VendorMachineTest.Domain.Interfaces.Repositories;
using VendorMachineTest.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VendorMachineTest.Domain.Commands
{
    public class Handler : IRequestHandler<CreateSaleCommand, Result>,
                          IRequestHandler<UpdateMachineCommand, Result>
    {
        private readonly IMediator _mediator;
        private readonly ISalesRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductStockRepository _productStockRepository;
        private readonly IMachineRepository _machineRepository;
        public Handler(IMediator mediator,
                       ISalesRepository saleRepositoryRepository,
                       IMachineRepository machineRepository,
                       IProductRepository productRepository,
                       IProductStockRepository productStockRepository)
        {
            _mediator = mediator;
            _machineRepository = machineRepository;
            _saleRepository = saleRepositoryRepository;
            _productRepository = productRepository;
            _productStockRepository = productStockRepository;
        }

        private IEnumerable<string> GetSalesErrors(CreateSaleCommand request) =>
            request.ValidationResult.Errors.Select(err => err.ErrorMessage);

        private IEnumerable<string> GetMachineErrors(UpdateMachineCommand request) =>
            request.ValidationResult.Errors.Select(err => err.ErrorMessage);

        public async Task<Result> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
                if (await _saleRepository.GetById(request.Id) == null)
                {
                    var sale = new Entities.Sales
                    {
                        Id = request.Id,
                        CreatedOn = request.CreatedOn,
                        ProductPrice = request.ProductPrice,
                        ProductId = request.ProductId
                    };
                    await _saleRepository.Add(sale);

                    var productStockContent = await _productRepository.GetBy(pid => pid.Id == request.ProductId, inc => inc.ProductStock);

                    var productStock = productStockContent.FirstOrDefault();

                    if (productStock.ProductStock != null)
                    {
                        productStock.ProductStock.Quantity -= 1;
                        await _productStockRepository.Update(productStock.ProductStock);
                    }
                }
                else
                {
                    var message = "The Product Id already exists.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult), cancellationToken);
                result.AddErrors(GetSalesErrors(request));
            }
            return result;
        }

        public async Task<Result> Handle(UpdateMachineCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var machine = await _machineRepository.GetById(request.Id);
                if (machine != null)
                {
                    machine.CreatedOn = request.CreatedOn;
                    machine.Id = request.Id;
                    machine.MaintenanceRequested = request.MaintenanceRequested;
                    machine.MachineCurrencyId = request.MachineCurrencyId;
                    machine.MachineLanguageId = request.MachineLanguageId;
                    await _machineRepository.Update(machine);
                }
                else
                {
                    var message = "The product cannot be found.";
                    await _mediator.Publish(new Notification(message), cancellationToken);
                    result.AddError(message);
                }
            }
            else
            {
                await _mediator.Publish(new Notification(request.ValidationResult), cancellationToken);
                result.AddErrors(GetMachineErrors(request));
            }
            return result;
        }
    }
}