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
    [Route("vendorMachine/webapi/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class MachineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public MachineController(IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet("{machineId}")]
        [SwaggerResponse((200), Type = typeof(MachineViewModel))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<JsonResult> GetMachineById(int machineId)
        {
                       
            var machine = await _unitOfWork.Repository<Machine>()
                .GetBy(mn => mn.Id == machineId, inc => inc.MachineCurrency, inc => inc.MachineLanguage);

            MachineViewModel resp = _mapper.Map<MachineViewModel>(machine.FirstOrDefault());
            return Json(resp);
        }

        [HttpGet("{machineId}")]
        [SwaggerResponse((200), Type = typeof(List<MachineSlotsViewModel>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<JsonResult> GetSlotsMachineById(int machineId)
        {

            var machineSlots = await _unitOfWork.Repository<MachineSlots>()
                .GetBy(mn => mn.MachineId == machineId, inc => inc.Product);

            List<MachineSlotsViewModel> resp = _mapper.Map<List<MachineSlotsViewModel>>(machineSlots.ToList());
           
            return Json(resp);
        }

        [HttpGet("{productId}")]
        [SwaggerResponse((200), Type = typeof(ProductStockViewModel))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<JsonResult> GetProductStockByProductId(int productId)
        {

            var productStock = await _unitOfWork.Repository<ProductStock>()
                .GetBy(mn => mn.Id == productId);

            ProductStockViewModel resp = _mapper.Map<ProductStockViewModel>(productStock.FirstOrDefault());

            return Json(resp);
        }


        [HttpPost]
        [SwaggerResponse((201), Type = typeof(ProductViewModel))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<ActionResult<ProductViewModel>> CreateSale(CreateSaleCommand model)
        {

            var result = await _mediator.Send(model);

            return new ObjectResult(result);
        }

        [HttpPut]
        [SwaggerResponse((201), Type = typeof(MachineViewModel))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<ActionResult<MachineViewModel>> UpdateMachine(UpdateMachineCommand model)
        {

            var result = await _mediator.Send(model);

            return new ObjectResult(result);
        }
    }
}
