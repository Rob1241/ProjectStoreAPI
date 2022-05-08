using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectStore.Models;

namespace ProjectStore.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Options = options;
        }
        public DbContextOptions<DataBaseContext> Options {get;}
        public DbSet<Book> BookDbSet { get; set; }
        public DbSet<Customer> CustomerDbSet { get; set; }
        public DbSet<Furniture> FurnitureDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(r => r.Name)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(s => s.Surname)
                .IsRequired();
        }

    }
}
