using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendorMachineTest.Data.Context;

namespace VendorMachineTest.Tests.Infrastructure
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {

        }

        public override void ConfigureDataBase(IServiceCollection services)
        {
            services.AddDbContext<VendorMachineContext>(option =>
            {
                option
                .UseInMemoryDatabase("inMemoryDb")
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Singleton);
        }
    }
}
