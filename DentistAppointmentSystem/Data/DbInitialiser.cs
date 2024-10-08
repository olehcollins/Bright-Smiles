using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DentistAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointmentSystem.Data
{
    public static class DbInitialiser
    {
        public static async Task Initialise(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Check if roles already exist, if not, create them.
            if (!context.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Dentist", NormalizedName = "DENTIST" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Receptionist", NormalizedName = "RECEPTIONIST" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Patient", NormalizedName = "PATIENT" });
            }

            // Check if users already exist, if not, create Admin.
            if (!context.Users.Any())
            {
                // Create an admin
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "User",
                    DateOfBirth = DateTime.SpecifyKind(new DateTime(1980, 1, 1), DateTimeKind.Utc),
                    Address = "123 Admin St, Admin City, Adminland",
                    Gender = "Male",
                    EmmergencyContact = "0123456789",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "AdminPassword123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");
                Console.WriteLine("Admin Created");

                // Create Dentists with realistic names
                var dentists = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        UserName = "james.a15",
                        Email = "james.anderson@brightsmile.com",
                        FirstName = "James",
                        LastName = "Anderson",
                        DateOfBirth = DateTime.SpecifyKind(new DateTime(1975, 5, 10), DateTimeKind.Utc),
                        Address = "101 Dental Way, Tooth City",
                        Gender = "Male",
                        EmmergencyContact = "0123456789",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        UserName = "sarah.r20",
                        Email = "sarah.roberts@brightsmile.com",
                        FirstName = "Sarah",
                        LastName = "Roberts",
                        DateOfBirth = DateTime.SpecifyKind(new DateTime(1982, 3, 22), DateTimeKind.Utc),
                        Address = "202 Smile Ave, Dental Town",
                        Gender = "Female",
                        EmmergencyContact = "0123456789",
                        EmailConfirmed = true
                    },
                    // Add more dentists similarly...
                };

                foreach (var dentist in dentists)
                {
                    await userManager.CreateAsync(dentist, $"DentistPassword{dentists.IndexOf(dentist) + 1}123!");
                    await userManager.AddToRoleAsync(dentist, "Dentist");
                    Console.WriteLine($"{dentist.FirstName} {dentist.LastName} (Dentist) Created");
                }

                // Create a Receptionist
                var receptionistUser = new ApplicationUser
                {
                    UserName = "emily.b15",
                    Email = "emily.brown@brightsmile.com",
                    FirstName = "Emily",
                    LastName = "Brown",
                    DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 7, 14), DateTimeKind.Utc),
                    Address = "303 Reception Blvd, Office City",
                    Gender = "Female",
                    EmmergencyContact = "0123456789",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(receptionistUser, "ReceptionistPassword123!");
                await userManager.AddToRoleAsync(receptionistUser, "Receptionist");
                Console.WriteLine("Emily Brown (Receptionist) Created");

                // Create Patients with realistic names
                var patients = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        UserName = "olivia.w23",
                        Email = "olivia.williams@brightsmile.com",
                        FirstName = "Olivia",
                        LastName = "Williams",
                        DateOfBirth = DateTime.SpecifyKind(new DateTime(1995, 11, 5), DateTimeKind.Utc),
                        Address = "404 Patient Lane, Health City",
                        Gender = "Female",
                        EmmergencyContact = "0123456789",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        UserName = "liam.j18",
                        Email = "liam.jones@brightsmile.com",
                        FirstName = "Liam",
                        LastName = "Jones",
                        DateOfBirth = DateTime.SpecifyKind(new DateTime(1998, 8, 18), DateTimeKind.Utc),
                        Address = "505 Patient Rd, Health City",
                        Gender = "Male",
                        EmmergencyContact = "0123456789",
                        EmailConfirmed = true
                    },
                    // Add more patients similarly...
                };

                foreach (var patient in patients)
                {
                    await userManager.CreateAsync(patient, $"PatientPassword{patients.IndexOf(patient) + 1}123!");
                    await userManager.AddToRoleAsync(patient, "Patient");
                    Console.WriteLine($"{patient.FirstName} {patient.LastName} (Patient) Created");
                }

                Console.WriteLine("Users initialised successfully!");

                // Seed Appointments
                var appointments = new List<Appointment>
                {
                    new Appointment
                    {
                        PatientId = patients[0].Id,
                        DentistId = dentists[0].Id,
                        ScheduledById = receptionistUser.Id,
                        Description = "Routine Dental Check-up",
                        TypeOfAppointment = "Check-up",
                        AppointmentDate = DateTime.SpecifyKind(DateTime.Now.AddDays(7), DateTimeKind.Utc)
                    },
                    new Appointment
                    {
                        PatientId = patients[1].Id,
                        DentistId = dentists[1].Id,
                        ScheduledById = receptionistUser.Id,
                        Description = "Teeth Cleaning",
                        TypeOfAppointment = "Cleaning",
                        AppointmentDate = DateTime.SpecifyKind(DateTime.Now.AddDays(14), DateTimeKind.Utc)

                    },
                    // Add more appointments similarly...
                };

                context.Appointments.AddRange(appointments);
                await context.SaveChangesAsync();
                Console.WriteLine("Appointments initialised successfully!");
            }
            else
            {
                Console.WriteLine("Users already exist. Initialisation skipped.");
            }
        }
    }
}