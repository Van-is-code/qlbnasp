
namespace Asp.Net_MvcWeb_Pj3.Aptech.Models;
using Microsoft.EntityFrameworkCore;



    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Patient>().ToTable("Patient");

            // Các cấu hình khác
        }
    }

