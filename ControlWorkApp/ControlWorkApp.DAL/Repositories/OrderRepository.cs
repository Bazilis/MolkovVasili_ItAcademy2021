using ControlWorkApp.DAL.EF;
using ControlWorkApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkApp.DAL.Repositories
{
    public class OrderRepository : GenericRepository<OrderEntity>
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
