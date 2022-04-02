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
        private readonly ISalesRepository _saleRepositoryRepository;
        private readonly IMachineRepository _machineRepository;
        public Handler(IMediator mediator,
                       ISalesRepository saleRepositoryRepository,
                       IMachineRepository machineRepository)
        {
            _mediator = mediator;
            _machineRepository = machineRepository;
            _saleRepositoryRepository = saleRepositoryRepository;
        }

        private IEnumerable<string> GetSalesErrors(CreateSaleCommand request) =>
            request.ValidationResult.Errors.Select(err => err.ErrorMessage);

        private IEnumerable<string> GetMachineErrors(UpdateMachineCommand request) =>
            request.ValidationResult.Errors.Select(err => err.ErrorMessage);

        public async Task<Result> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
                if (await _saleRepositoryRepository.GetById(request.Id) == null)
                {
                    var sale = new Entities.Sales
                    {
                        Id = request.Id,
                        CreatedOn = request.CreatedOn,
                        ProductPrice = request.ProductPrice,
                        ProductId = request.ProductId
                    };
                    await _saleRepositoryRepository.Add(sale);
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