using ControlWorkApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkApp.DAL.Repositories
{
    public class OrderRepository : GenericRepository<OrderEntity>
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
