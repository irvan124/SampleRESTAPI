using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;
using System;

namespace SampleRESTAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        // Using Data Anotation
        //Create DB Context
        public DbSet<Author> Authors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }  
        public DbSet<Enrollment> Enrollments { get; set; }
        

        //Fluid API Model, Using reference to replace the table name
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Mahasiswa");
        }
        */

    }
}
