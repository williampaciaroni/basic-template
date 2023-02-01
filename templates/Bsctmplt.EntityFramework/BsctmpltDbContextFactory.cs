using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace Bsctmplt.EntityFrameworkCore
{

    public class BsctmpltDbContextFactory : IDesignTimeDbContextFactory<BsctmpltDbContext>
    {

        private static IConfiguration? _Configuration;

        public BsctmpltDbContext CreateDbContext(string[] args)
        {
            // Build config
            IConfiguration config = _Configuration;

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<BsctmpltDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new BsctmpltDbContext(optionsBuilder.Options);
        }

        public static void SetConfiguration(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public static IConfiguration GetConfiguration()
        {
            return _Configuration;
        }
    }
}