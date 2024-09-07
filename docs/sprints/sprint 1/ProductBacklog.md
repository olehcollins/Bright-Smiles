# Sprint 1

## User Story 1:

- **As a User**, I want to sign in and sign out of my account.

## Product Backlog:

1. **Create and Set up the MVC Application.**

- **Tasks:**
  1. Install Entity Framework Core packages.
  ```bash
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.PostgreSQL
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.AspNetCore.Identity.UI
    dotnet add package Microsoft.AspNetCore.Http.Features
  ```
  2. Create the Database Context.
  3. Create a User Model.
  4. Configure the Database Connection.
  5. Configure Services and Middleware in Program.cs.

2. **Implement an authentication system for the platform.**

- **Tasks:**

  1. Create a Data Folder and in create an initailiser file to populate the DB and context file for dependecy injection.
  2. Set up a DB context using Microsoft Entity Framework Core for users.
  3. Create a DB initialiser file and write code to populate the database with 4 dentists, 2 receptionists, and a practice manager.
  4. Set the accessibility restrictions for the users depending on their roles.
  5. Leverage Entity Framework Cores capability to create a drop any existing database and create a new one.

  ```csharp
    // Seed the database with initial data
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();

        // drop existing database
        context.Database.EnsureDeleted();

        // create new database
        context.Database.EnsureCreated();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await DbInitialiser.Initialise(context, userManager, roleManager);
    }
  ```

  6. Create a ViewModels Folder and in it create models for the Login and Register views.
  7. In the Controllers folder create a 'AccountController.cs' file and write the code for the Login and Register actions.
  8. In the Views Folder create a 'Account' Folder and in it a Login and Register View.

3. **Write a Unit Tests for the authentication system.**

- **Tasks:**
  1. Navigate to the solution folder and run the following command to create a new xUnit test project:
  ```bash
    dotnet new xunit -n DentistAppointmentSystem.Tests
  ```
  3. Navigate into the newly created test project folder and install the necessary NuGet Packages.
  ```bash
    dotnet add package xunit
    dotnet add package Moq
    dotnet add package Microsoft.AspNetCore.Hosting
    dotnet add package Microsoft.AspNetCore.Http
  ```
  4. Add a refrence to your project
  ```bash
    dotnet add reference ../DentistAppointmentSystem/DentistAppointmentSystem.csproj
  ```
  4. Create a Controller Folder and within it create an AccountControllerTests.cs file.
  5. Code write the unit test for the Account Controller Actions.
  6. Run the tests and if all are successful move to sprint 2.
