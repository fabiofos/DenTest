using AutoMapper;
using VendorMachineTest.Domain.Commands.Product;
using VendorMachineTest.Domain.Entities;
using VendorMachineTest.Domain.ViewModels;

namespace VendorMachineTest.Extensions
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductStock, ProductStockViewModel>().ReverseMap();
            CreateMap<Machine, MachineViewModel>().ReverseMap();
            CreateMap<MachineCurrency, MachineCurrencyViewModel>().ReverseMap();
            CreateMap<MachineLanguage, MachineLanguageViewModel>().ReverseMap();
            CreateMap<MachineSlots, MachineSlotsViewModel>().ReverseMap();
            CreateMap<Sales, SalesViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}
