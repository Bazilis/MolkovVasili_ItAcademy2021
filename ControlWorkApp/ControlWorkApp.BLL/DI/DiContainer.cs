using ControlWorkApp.BLL.Validators;
using ControlWorkApp.DAL.Entities;
using ControlWorkApp.DAL.Interfaces;
using ControlWorkApp.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ControlWorkApp.BLL.DI
{
    public static class DiContainer
    {
        public static ServiceProvider Container { get; }

        static DiContainer()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IRepository<CustomerEntity>, CustomerRepository>();
            serviceCollection.AddScoped<IRepository<OrderEntity>, OrderRepository>();
            serviceCollection.AddScoped<IRepository<ProductEntity>, ProductRepository>();

            serviceCollection.AddScoped<CustomerValidator>();
            serviceCollection.AddScoped<OrderValidator>();
            serviceCollection.AddScoped<ProductValidator>();

            Container = serviceCollection.BuildServiceProvider();
        }
    }
}
