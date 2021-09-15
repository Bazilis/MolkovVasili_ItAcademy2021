using Hometask5.DAL.EF;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data.Common;

namespace Hometask5.Tests.DAL
{
    public class SqliteInMemoryApplicationDbContextTest : ApplicationDbContextTestBase, IDisposable
    {
        private readonly DbConnection _dbConnection;

        public SqliteInMemoryApplicationDbContextTest() :
            base(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(CreateInMemoryDatebase())
                .Options)
        {
            _dbConnection = RelationalOptionsExtension.Extract(DbContextOptions).Connection;


        }

        private static DbConnection CreateInMemoryDatebase()
        {
            var connection = new SqliteConnection("Filename = :memory:");
            connection.Open();

            return connection;
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
