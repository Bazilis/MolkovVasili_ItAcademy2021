using Hometask5.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace Hometask5.Tests.DAL
{
    public class SqliteApplicationDbContextTest : ApplicationDbContextTestBase
    {
        public SqliteApplicationDbContextTest() : 
            base(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Filename = TestSqlite.db")
                .Options)
        {
        }
    }
}
