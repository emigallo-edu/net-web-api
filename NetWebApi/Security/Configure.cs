using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Security
{
    public static class Configure
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            //services.AddDbContext<SecurityDbContext>(options => options.UseSqlServer(""));
            //services.AddIdentity<User, IdentityRole>()
            //                   .AddEntityFrameworkStores<SecurityDbContext>()
            //                   .AddDefaultTokenProviders();
            return services;
        }

        public static void UseAuthentication(this WebClient app)
        {
            app.UseAuthentication();
        }
    }
}