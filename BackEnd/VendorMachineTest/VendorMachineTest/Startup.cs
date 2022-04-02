using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using VendorMachineTest.Data.Context;
using VendorMachineTest.DependencyInjection;
using VendorMachineTest.Extensions;

namespace VendorMachineTest
{
    public class Startup
    {
        string _connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("DBConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VendorMachineTest", Version = "v1" });
            });
            services.AddApiVersioning();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                                  builder =>
                                  {
                                      builder
                                          .AllowAnyMethod()
                                          .AllowAnyHeader()
                                          .AllowCredentials()
                                          .WithOrigins("http://localhost:4200");
                                  });
            });

            ConfigureDataBase(services);

            services.AddMediatRSetup();

            #region "Auto Mapper Configurations"
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperSetup());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region "Dependency Injection"
             ServicesInjection.Inject(services);
            #endregion
        }

        //Virtual method - override will be done in the tests
        public virtual void ConfigureDataBase(IServiceCollection services)
        {
            #region "Entity Framework Configuration Context"
            services.AddDbContext<VendorMachineContext>(options =>
            options.UseSqlServer(_connectionString));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VendorMachineTest v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
