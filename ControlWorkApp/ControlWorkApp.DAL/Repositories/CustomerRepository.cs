using ControlWorkApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkApp.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<CustomerEntity>
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
