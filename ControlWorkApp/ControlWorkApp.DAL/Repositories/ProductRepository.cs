using ControlWorkApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkApp.DAL.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
