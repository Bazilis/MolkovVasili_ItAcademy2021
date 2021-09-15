using Hometask5.DAL.EF;
using Hometask5.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Hometask5.Tests.DAL
{
    public abstract class ApplicationDbContextTestBase
    {
        protected DbContextOptions<ApplicationDbContext> DbContextOptions { get;  }

        protected ApplicationDbContextTestBase(DbContextOptions<ApplicationDbContext> dbContextOptions)
        {
            DbContextOptions = dbContextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(DbContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var company = new CompanyEntity()
                {
                    Name = "Academy",
                    Users = new List<UserEntity>()
                    {
                        new UserEntity()
                        {
                            Name = "Bob"
                        },

                        new UserEntity()
                        {
                            Name = "John"
                        }
                    }
                };

                context.Companies.Add(company);
                context.SaveChanges();
            }
        }

        [Fact]
        public void BaseTestDbSeeding()
        {
            using (var context = new ApplicationDbContext(DbContextOptions))
            {
                var companies = context.Companies
                    .Include(c => c.Users)
                    .ToArray();
                var users = companies[0].Users;

                Assert.Single(companies);
                Assert.Equal("Academy", companies[0].Name);
                Assert.Equal("Bob", users[0].Name);
                Assert.Equal("John", users[1].Name);
            }
        }
    }
}
