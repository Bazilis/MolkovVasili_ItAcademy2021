using ControlWorkApp.BLL.DI;
using ControlWorkApp.BLL.DTO;
using ControlWorkApp.DAL.EF;
using ControlWorkApp.BLL.Interfaces;
using ControlWorkApp.BLL.Services;
using ControlWorkApp.BLL.Validators;
using ControlWorkApp.DAL.Entities;
using ControlWorkApp.DAL.Interfaces;
using ControlWorkApp.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace ControlWorkApp.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlWorkApp.WebApi", Version = "v1" });
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Не работает Dependency Injection, не могу понять почему
            // Написал интеграционный тест и внедрил все зависимости без DI - все работает
            services.AddScoped<IRepository<CustomerEntity>, CustomerRepository>();
            services.AddScoped<IRepository<OrderEntity>, OrderRepository>();
            services.AddScoped<IRepository<ProductEntity>, ProductRepository>();

            services.AddScoped<CustomerValidator>();
            services.AddScoped<OrderValidator>();
            services.AddScoped<ProductValidator>();

            services.AddScoped<IService<CustomerDto>, CustomerService>();
            services.AddScoped<IService<OrderDto>, OrderService>();
            services.AddScoped<IService<ProductDto>, ProductService>();

            // DiContainer.Container.GetServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControlWorkApp.WebApi v1"));
            }

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
