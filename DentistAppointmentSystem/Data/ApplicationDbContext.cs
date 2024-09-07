using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DentistAppointmentSystem.Models;

namespace DentistAppointmentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuring the Patient record relationship
            builder.Entity<PatientRecord>()
                .HasOne(p => p.Patient)
                .WithMany(u => u.PatientRecords)
                .HasForeignKey(p => p.PatientId);

            // Configuring the Appointment relationships
            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany() // Assuming Patient can have multiple appointments
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Dentist)
                .WithMany()  // Assuming Dentist can have multiple appointments
                .HasForeignKey(a => a.DentistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.ScheduledBy)
                .WithMany()  // Assuming ScheduledBy can have multiple appointments
                .HasForeignKey(a => a.ScheduledById)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}