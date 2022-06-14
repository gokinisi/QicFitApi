
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace QicFit.DataAccess.EFCore
{
    class QicFitDesignTimeContextFactory : IDesignTimeDbContextFactory<QicFitDataContext>
    {
        // this class used by EF tool for creating migrations via Package Manager Console
        // Add-Migration MigrationName -Project QicFit.DataAccess.EFCore -StartupProject QicFit.DataAccess.EFCore
        // or in case of console building: dotnet ef migrations add MigrationName --project QicFit.DataAccess.EFCore --startup-project QicFit.DataAccess.EFCore
        // after migration is added, please add migrationBuilder.Sql(SeedData.Initial()); to the end of seed method for initial data
        public QicFitDesignTimeContextFactory() {}

        public QicFitDataContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../QitFit.WebApiCore"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("localDb");

            var builder = new DbContextOptionsBuilder<QicFitDataContext>();
            builder.UseSqlServer(connectionString);

            return new QicFitDataContext(builder.Options);
        }
    }
}
