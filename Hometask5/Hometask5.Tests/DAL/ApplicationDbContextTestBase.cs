using Hometask5.DAL.EF;
using Hometask5.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Hometask5.DAL.Repositories;
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

        [Fact]
        public void CreateEntityRepositoryTestMethod()
        {
            var companyRepo = new CompanyRepository(new ApplicationDbContext(DbContextOptions));
            var userRepo = new UserRepository(new ApplicationDbContext(DbContextOptions));

            var newCompany = new CompanyEntity() { Name = "EPAM" };
            var newUser = new UserEntity() { Name = "Vasili" };

            companyRepo.Create(newCompany);
            userRepo.Create(newUser);

            var createdCompanyFromDb = companyRepo.GetById(newCompany.Id);
            var createdUserFromDb = userRepo.GetById(newUser.Id);


            Assert.Equal("EPAM", createdCompanyFromDb.Name);
            Assert.Equal("Vasili", createdUserFromDb.Name);
        }

        [Fact]
        public void UpdateEntityRepositoryTestMethod()
        {
            var companyRepo = new CompanyRepository(new ApplicationDbContext(DbContextOptions));
            var userRepo = new UserRepository(new ApplicationDbContext(DbContextOptions));

            var newCompany = new CompanyEntity() { Name = "Microsoft" };
            var newUser = new UserEntity() { Name = "Bill" };

            var createdCompany = companyRepo.Create(newCompany);
            var createdUser = userRepo.Create(newUser);

            createdCompany.Name = "Apple";
            createdUser.Name = "Tim";

            companyRepo.Update(createdCompany);
            userRepo.Update(createdUser);

            var updatedCompanyFromDb = companyRepo.GetById(createdCompany.Id);
            var updatedUserFromDb = userRepo.GetById(createdUser.Id);


            Assert.Equal("Apple", updatedCompanyFromDb.Name);
            Assert.Equal("Tim", updatedUserFromDb.Name);
        }

        [Fact]
        public void DeleteEntityRepositoryTestMethod()
        {
            var companyRepo = new CompanyRepository(new ApplicationDbContext(DbContextOptions));
            var userRepo = new UserRepository(new ApplicationDbContext(DbContextOptions));

            var newCompany = new CompanyEntity() { Name = "SpaceX" };
            var newUser = new UserEntity() { Name = "Elon" };

            var createdCompany = companyRepo.Create(newCompany);
            var createdUser = userRepo.Create(newUser);

            companyRepo.Delete(createdCompany);
            userRepo.Delete(createdUser);

            var deletedCompanyFromDb = companyRepo.GetById(createdCompany.Id);
            var deletedUserFromDb = userRepo.GetById(createdUser.Id);


            Assert.Null(deletedCompanyFromDb);
            Assert.Null(deletedUserFromDb);
        }
    }
}
