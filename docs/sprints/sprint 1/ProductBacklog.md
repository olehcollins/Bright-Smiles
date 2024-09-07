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
  3. Create a User Model
  4. Configure the Database Connection.
  5. Configure Services and Middleware in Program.cs.
  6. Populate the database.

2. **Implement an authentication system for the platform.**

- **Tasks:**

  1. Create a Data Folder and in create an initailiser file to populate the DB and context file for dependecy injection.
  2. Set up a DB context using Microsoft Entity Framework Core for users.
  3. Create the Migration file and then apply the migration to the database.

  ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
  ```

  4. Populate the database with 4 dentists, 2 receptionists, and a practice manager.
  5. Set the accessibility restrictions for the users depending on their roles.
  6. Create a ViewModels Folder and in it create models for the Login and Register views.

  ```

  ```

3. **Write a Unit Tests for the authentication system.**

- **Tasks:**
  1. Navigate to the solution folder and run the following command to create a new xUnit test project:
  ```bash
    dotnet new xunit -n DentistAppointmentSystem.Tests
  ```
  3. Navigate into the newly created test project folder and install the necessary NuGet Packages
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
  4. Create a Controller Folder and within it create an AccountControllerTests.cs file
  5. Code write the unit test for the Account Controller Actions

3. **Deploy the Application.**
