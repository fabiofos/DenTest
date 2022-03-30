using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendorMachineTest.Domain.Commands.Product;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.Interfaces.UOW;
using VendorMachineTest.Domain.ViewModels;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorMachineTest.Controllers
{
    [ApiVersion("1")]
    [Route("signalr/webapi/v{version:apiVersion}/[controller]/[action]")]
    [ApiController] //it means we dont have to specify frombody anottations either check if model state is valid, .net does it auto.
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public ProductController(IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet("{productId}")]
        [SwaggerResponse((200), Type = typeof(ProductViewModel))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<JsonResult> GetProductById(int productId)
        {
            var product = await _unitOfWork.Repository<Product>().GetBy(pId => pId.Id == productId);
            ProductViewModel resp = _mapper.Map<ProductViewModel>(product.FirstOrDefault());
            return Json(resp);
        }

        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<ProductViewModel>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<JsonResult> GetProducts()
        {
            var products = _mapper.Map<List<ProductViewModel>>(await _unitOfWork.Repository<Product>().GetAll());
            return Json(products.OrderByDescending(ord => ord.CreatedOn));
        }

        [HttpPost]
        [SwaggerResponse((201), Type = typeof(ProductViewModel))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<ActionResult<ProductViewModel>> CreateProduct(CreateProductCommand model)
        {

            var result = await _mediator.Send(model);

            var vm = _mapper.Map<ProductViewModel>(model);

            return new ObjectResult(result);
        }

        [HttpPut]
        [SwaggerResponse((200), Type = typeof(ProductViewModel))]
        [SwaggerResponse(202)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<ActionResult<ProductViewModel>> UpdateProduct(ProductViewModel model)
        {
            var result = await _mediator.Send(model);

            return new ObjectResult(result);
        }
    }
}
