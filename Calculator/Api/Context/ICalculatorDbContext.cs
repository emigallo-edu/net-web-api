using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public abstract class BaseCalculatorDbContext : DbContext
    {
        public BaseCalculatorDbContext(DbContextOptions<BaseCalculatorDbContext> options) : base(options)
        {

        }

        public DbSet<LoginModel> Logins { get; set; }
    }
}