using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Common;

namespace Wims.Data.Tests
{
    public class BaseTest
    {
        protected DbContextOptions<DefaultContext> DbContextOptions { get; private set; }
        private DbConnection _connection;

        [TestInitialize]
        public void Setup()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            DbContextOptions = new DbContextOptionsBuilder<DefaultContext>()
                    .UseSqlite(_connection)
                    .Options;

            // Create the schema in the database
            using (var context = new DefaultContext(DbContextOptions))
            {
                context.Database.EnsureCreated();
            }
        }

        public void CleanUp()
        {
            if (_connection != null)
                _connection.Close();
        }
    }
}
