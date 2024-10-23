using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace Api
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            string connectionString = "Server=localhost;Database=NetWebApiDemo;Trusted_Connection=True;Encrypt=false";
            contextOptionsBuilder.UseSqlServer(connectionString, x =>
             x.MigrationsHistoryTable("_MigrationsHistory", "dbo")
             .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new ApplicationDbContext(contextOptionsBuilder.Options);
        }
    }
}
