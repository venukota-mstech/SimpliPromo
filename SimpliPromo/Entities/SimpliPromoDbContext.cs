using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpliPromo.Entities
{
    public class SimpliPromoDbContext:DbContext
    {
        public SimpliPromoDbContext(DbContextOptions<SimpliPromoDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>();
            modelBuilder.Entity<PersonRole>();
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
