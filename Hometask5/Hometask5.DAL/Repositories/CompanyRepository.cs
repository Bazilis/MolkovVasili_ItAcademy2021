using Hometask5.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hometask5.DAL.Repositories
{
    public class CompanyRepository : GenericRepository<CompanyEntity>
    {
        public CompanyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
