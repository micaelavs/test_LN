using System;
using System.Data.Entity;

namespace proyectoApi.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() :
           base("DefaultConnection")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //en caso q haya relaciones se pueden conf aca
        }
    }
}
