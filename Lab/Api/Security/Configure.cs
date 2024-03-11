using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Security
{
    public static class Configure
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                               .AddEntityFrameworkStores<SecurityDbContext>()
                               .AddDefaultTokenProviders()
                               .AddRoles<IdentityRole>();

            return services;
        }
    }
}