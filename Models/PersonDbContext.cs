using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS_EFCore.Models
{
    public class PersonDbContext :DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public PersonDbContext()
        {
                
        }
        //Configure DB Connection with application
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PersonDb;Integrated Security=SSPI");
        }
        //PRovide mechanism of modelmapping while database and table  are created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }
    }
}
