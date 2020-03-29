using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infraestrutura
{
    public sealed class CrudContextFactory : IDesignTimeDbContextFactory<CrudContext>
    {
        public CrudContext CreateDbContext(string[] args)
        {
            string connectionString = RetrieveConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<CrudContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CrudContext(optionsBuilder.Options);
        }

        private string RetrieveConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}