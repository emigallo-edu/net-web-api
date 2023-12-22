using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Model;
using Repository;

namespace NetWebApi.Context
{
    public enum DatabaseType
    {
        SqlServer,
        Files
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            contextOptionsBuilder.Config();
            return new ApplicationDbContext(contextOptionsBuilder.Options);
        }
    }

    public static class ApplicationDbContextFactoryConfig
    {
        private static IServiceProvider _provider;

        public static void AddApplicationDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.Config());
        }

        public static void AddRepositories(this IServiceCollection services, DatabaseType databaseType)
        {
            if (databaseType == DatabaseType.Files)
            {
                services.AddScoped<IClubRepository, ClubFileRepository>(
                 (Iservicepri) => new ClubFileRepository(Path.Combine(Environment.CurrentDirectory, "Files")));
            }
            else
            {
                services.AddScoped<IClubRepository, ClubDbRepository>();
            }
            services.AddScoped<ResponseAuditRepository>();
        }

        public static void SetProvider(this IServiceProvider provider)
        {
            _provider = provider;
        }

        public static T Get<T>()
        {
            return _provider.GetRequiredService<T>();
        }

        public static void Config(this DbContextOptionsBuilder contextOptionsBuilder)
        {
            string connectionString = GetConnectionString();
            contextOptionsBuilder.UseSqlServer(connectionString, x =>
               x.MigrationsHistoryTable("_MigrationsHistory", "dbo")
               .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        }

        private static string GetConnectionString()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            var configuration = configurationBuilder.Build();

            return configuration.GetConnectionString("DefaultConnectionString");
        }
    }
}