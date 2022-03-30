using AutoMapper;
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
    public class Handler : IRequestHandler<CreateProductCommand, Result>,
                          IRequestHandler<UpdateProductCommand, Result>,
                          IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;
        public Handler(IMediator mediator,
                       IProductRepository productRepository,
                       IMapper mapper)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }

        private IEnumerable<string> GetErrors(ProductCommand request) =>
            request.ValidationResult.Errors.Select(err => err.ErrorMessage);

        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
                if (await _productRepository.GetById(request.Id) == null)
                {
                    var prod = new Entities.Product
                    {
                        Id = request.Id,
                        CreatedOn = request.CreatedOn,
                        Description = request.Description,
                        Name = request.Name, 
                        Price = request.Price,
                        //Quantity = request.Quantity
                    };
                    await _productRepository.Add(prod);
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
                result.AddErrors(GetErrors(request));
            }
            return result;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var prod =  await _productRepository.GetById(request.Id);
                if (prod != null)
                {
                    prod.CreatedOn = request.CreatedOn;
                    prod.Description = request.Description;
                    prod.Name = request.Name;
                    prod.Price = request.Price;
                    //prod.Quantity = request.Quantity;
                    await _productRepository.Update(prod);
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
                result.AddErrors(GetErrors(request));
            }
            return result;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            if (request.IsValid())
            {
                var prod =  await _productRepository.GetById(request.Id);
                if (prod != null)
                {
                    await _productRepository.Remove(prod); 
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
                result.AddErrors(GetErrors(request));
            }

            return result;
        }
    }
}