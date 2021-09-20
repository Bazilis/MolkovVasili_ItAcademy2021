using Hometask5.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace Hometask5.Tests.DAL
{
    public class SqlServerApplicationDbContextTest : ApplicationDbContextTestBase
    {
        public SqlServerApplicationDbContextTest() : 
            base(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EfTestDb;Trusted_Connection=True;")
                .Options)
        {
        }
    }
}
