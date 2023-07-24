using DoctorManagmentApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

namespace DoctorManagmentApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Replace "YourConnectionString" with your actual database connection string
        //    optionsBuilder.UseSqlServer("YourConnectionString");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships between entities (if needed)
            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Patient)
            //    .WithMany(p => p.Appointments)
            //    .HasForeignKey(a => a.PatientID);

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Doctor)
            //    .WithMany(d => d.Appointments)
            //    .HasForeignKey(a => a.DoctorID);

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Clinic)
            //    .WithMany(c => c.Appointments)
            //    .HasForeignKey(a => a.ClinicID);
        }
    }
}
