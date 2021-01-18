using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persistence
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "sqlConnection";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        public TContext CreateDbContext(string[] args)
        {
            var basepath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}WebApi", Path.DirectorySeparatorChar);
            return Create(basepath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }
        private TContext Create(string basePath, string enviromentName)
        {
            var coniguration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{enviromentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            var connectionstring = coniguration.GetConnectionString(ConnectionStringName);
            return Create(connectionstring);
        }
        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));

            }
            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return CreateNewInstance(optionsBuilder.Options);
        }
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
    }
}
