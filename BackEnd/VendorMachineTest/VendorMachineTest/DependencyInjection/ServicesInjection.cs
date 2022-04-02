using Microsoft.Extensions.DependencyInjection;
using VendorMachineTest.Application.Interfaces;
using VendorMachineTest.Application.Services;
using VendorMachineTest.Data;
using VendorMachineTest.Data.Repository;
using VendorMachineTest.Data.UOW;
using VendorMachineTest.Domain.Interfaces.Repositories;
using VendorMachineTest.Domain.Interfaces.UOW;

namespace VendorMachineTest.DependencyInjection
{
    public static class ServicesInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductStockRepository, ProductStockRepository>();
            services.AddScoped<IMachineCurrencyRepository, MachineCurrencyRepository>();
            services.AddScoped<IMachineLanguageRepository, MachineLanguageRepository>();
            services.AddScoped<IMachineSlotsRepository, MachineSlotsRepository>();
            services.AddScoped<IMachineRepository, MachineRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
        }
    }
}
