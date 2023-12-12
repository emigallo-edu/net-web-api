using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace NetWebApi.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            string connectionString = this.GetConnectionString(args);

            contextOptionsBuilder.UseSqlServer(connectionString, x =>
                x.MigrationsHistoryTable("_MigrationsHistory", "dbo")
                .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new ApplicationDbContext(contextOptionsBuilder.Options);
        }

        private string GetConnectionString(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            var configuration = configurationBuilder.Build();

            return configuration.GetConnectionString("DefaultConnectionString");
        }
    }
}