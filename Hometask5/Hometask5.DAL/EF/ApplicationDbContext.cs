using Microsoft.EntityFrameworkCore;
using Hometask5.DAL.Entities;

namespace Hometask5.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder)
            : base(optionsBuilder)
        {
        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
