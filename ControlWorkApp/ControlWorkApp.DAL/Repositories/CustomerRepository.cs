using ControlWorkApp.DAL.EF;
using ControlWorkApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkApp.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<CustomerEntity>
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
