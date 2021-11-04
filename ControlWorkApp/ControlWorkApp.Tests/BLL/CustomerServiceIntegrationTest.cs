using ControlWorkApp.BLL.DTO;
using ControlWorkApp.BLL.Services;
using ControlWorkApp.BLL.Validators;
using ControlWorkApp.DAL.EF;
using ControlWorkApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace ControlWorkApp.Tests.BLL
{
    public class CustomerServiceIntegrationTest
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=EfTestDb;Trusted_Connection=True;";

        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions =
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

        private ILogger LoggerTestOutput { get; }

        public CustomerServiceIntegrationTest(ITestOutputHelper output)
        {
            LoggerTestOutput = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.TestOutput(output)
                .CreateLogger()
                .ForContext<CustomerServiceIntegrationTest>();
        }

        [Fact]
        public void CreateEntityRepositoryTestMethod()
        {
            var customer = new CustomerDto() { Name = "Vasili" };
            var order = new OrderDto() { Name = "Invoice" };
            var product = new ProductDto() { Name = "Water" };

            var customerRepo = new CustomerRepository(new ApplicationDbContext(_dbContextOptions));
            var orderRepo = new OrderRepository(new ApplicationDbContext(_dbContextOptions));
            var productRepo = new ProductRepository(new ApplicationDbContext(_dbContextOptions));

            var customerValidator = new CustomerValidator();
            var orderValidator = new OrderValidator();
            var productValidator = new ProductValidator();

            var customerService = new CustomerService(customerRepo, customerValidator, LoggerTestOutput);
			var orderService = new OrderService(orderRepo, orderValidator, LoggerTestOutput);
			var productService = new ProductService(productRepo, productValidator, LoggerTestOutput);

            customerService.Create(customer);
            orderService.Create(order);
            productService.Create(product);

            var createdCustomerFromDb = customerService.GetById(customer.Id);
            var createdOrderFromDb = orderService.GetById(order.Id);
            var createdProductFromDb = productService.GetById(product.Id);


            Assert.Equal("Vasili", createdCustomerFromDb.Name);
            Assert.Equal("Invoice", createdOrderFromDb.Name);
            Assert.Equal("Water", createdProductFromDb.Name);
        }

    }
}
