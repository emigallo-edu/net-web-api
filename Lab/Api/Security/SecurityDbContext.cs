using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Security
{
    public class SecurityDbContext : IdentityDbContext<User>
    {
        public SecurityDbContext()
        {

        }

        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
    }
}