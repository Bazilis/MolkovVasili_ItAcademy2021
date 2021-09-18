using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkApp.DAL.EF
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
