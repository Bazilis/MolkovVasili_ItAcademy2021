using Hometask5.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hometask5.DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
