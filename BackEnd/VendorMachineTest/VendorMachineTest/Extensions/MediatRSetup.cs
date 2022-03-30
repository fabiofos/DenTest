using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace VendorMachineTest.Extensions
{
    public static class MediatRSetup
    {
        public static void AddMediatRSetup(this IServiceCollection services) =>
            services.AddMediatR(Assembly.Load("VendorMachineTest.Domain"));
    }
}
