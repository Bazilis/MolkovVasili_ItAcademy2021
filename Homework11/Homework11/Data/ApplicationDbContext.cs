using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Homework11.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder)
            : base(optionsBuilder)
        {
        }

        //private readonly IConfiguration _configuration;

        //protected ApplicationDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        //}
    }
}
