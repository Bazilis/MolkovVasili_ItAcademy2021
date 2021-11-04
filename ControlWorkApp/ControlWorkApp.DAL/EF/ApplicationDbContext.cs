using ControlWorkApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkApp.DAL.EF
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder)
            : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
