using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class InMemoryDbContext : BaseCalculatorDbContext
    {
        public InMemoryDbContext(DbContextOptions<BaseCalculatorDbContext> options) : base(options)
        {            
            this.LoadData();
        }

        private int LoadData()
        {
            this.Logins.Add(new LoginModel(1, "Juan", "juan@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(2, "Juana", "Juana@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(3, "Ignacio", "Ignacio@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(4, "Pedro", "Pedro@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(5, "Laura", "Laura@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(6, "Julieta", "Julieta@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(7, "Verónica", "Verónica@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(8, "Pablo", "Pablo@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(9, "Martín", "Martín@mail.com", DateTime.Now));
            this.Logins.Add(new LoginModel(10, "Agustina", "Agustina@mail.com", DateTime.Now));

            return this.SaveChanges();
        }

        //public DbSet<LoginModel> Logins { get; set; }


        public override void Dispose()
        {

        }
    }
}