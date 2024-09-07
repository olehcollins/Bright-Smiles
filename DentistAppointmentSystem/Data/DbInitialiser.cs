using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DentistAppointmentSystem.Models;
using System;
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
                roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }).Wait();
                roleManager.CreateAsync(new IdentityRole { Name = "Dentist", NormalizedName = "DENTIST" }).Wait();
                roleManager.CreateAsync(new IdentityRole { Name = "Receptionist", NormalizedName = "RECEPTIONIST" }).Wait();
                roleManager.CreateAsync(new IdentityRole { Name = "Patient", NormalizedName = "PATIENT" }).Wait();
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
                    EmailConfirmed = true
                };

                userManager.CreateAsync(adminUser, "AdminPassword123!").Wait();
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                Console.WriteLine("Admin Created");

                // Create 4 Dentists with realistic names
                var dentists = new List<(string FirstName, string LastName)>
                {
                    ("James", "Anderson"),
                    ("Sarah", "Roberts"),
                    ("Michael", "Johnson"),
                    ("Laura", "Smith")
                };

                foreach (var dentist in dentists)
                {
                    var dentistUser = new ApplicationUser
                    {
                        UserName = $"{dentist.FirstName.ToLower()}.{dentist.LastName.ToLower()}@brightsmile.com",
                        Email = $"{dentist.FirstName.ToLower()}.{dentist.LastName.ToLower()}@brightsmile.com",
                        FirstName = dentist.FirstName,
                        LastName = dentist.LastName,
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(dentistUser, $"DentistPassword{dentists.IndexOf(dentist) + 1}123!").Wait();
                    userManager.AddToRoleAsync(dentistUser, "Dentist").Wait();
                    Console.WriteLine($"{dentist.FirstName} {dentist.LastName} (Dentist) Created");
                }

                // Create 1 Receptionist with a realistic name
                var receptionistUser = new ApplicationUser
                {
                    UserName = "emily.brown@brightsmile.com",
                    Email = "emily.brown@brightsmile.com",
                    FirstName = "Emily",
                    LastName = "Brown",
                    EmailConfirmed = true
                };

                userManager.CreateAsync(receptionistUser, "ReceptionistPassword123!").Wait();
                userManager.AddToRoleAsync(receptionistUser, "Receptionist").Wait();
                Console.WriteLine("Emily Brown (Receptionist) Created");

                // Create 15 Patients with realistic names
                var patients = new List<(string FirstName, string LastName)>
                {
                    ("Olivia", "Williams"),
                    ("Liam", "Jones"),
                    ("Emma", "Davis"),
                    ("Noah", "Garcia"),
                    ("Ava", "Martinez"),
                    ("Sophia", "Hernandez"),
                    ("Isabella", "Lopez"),
                    ("Mason", "Gonzalez"),
                    ("Mia", "Wilson"),
                    ("Ethan", "Moore"),
                    ("Lucas", "Taylor"),
                    ("Amelia", "Anderson"),
                    ("Benjamin", "Thomas"),
                    ("Harper", "Jackson"),
                    ("Charlotte", "White")
                };

                foreach (var patient in patients)
                {
                    var patientUser = new ApplicationUser
                    {
                        UserName = $"{patient.FirstName.ToLower()}.{patient.LastName.ToLower()}@brightsmile.com",
                        Email = $"{patient.FirstName.ToLower()}.{patient.LastName.ToLower()}@brightsmile.com",
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(patientUser, $"PatientPassword{patients.IndexOf(patient) + 1}123!").Wait();
                    userManager.AddToRoleAsync(patientUser, "Patient").Wait();
                    Console.WriteLine($"{patient.FirstName} {patient.LastName} (Patient) Created");
                }

                Console.WriteLine("Users initialized successfully!");
            }
            else
            {
                Console.WriteLine("Users already exist. Initialization skipped.");
            }

            await context.SaveChangesAsync();
        }
    }
}