# Sprint 1 Planning

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
  1. Set up a DB context using Microsoft Entity Framework Core for users.
  1. Populate the database with 4 dentists, 2 receptionists, and a practice manager.
  1. Set the accessibility restrictions for the users depending on their roles.

3. **Write a Unit Tests for the authentication system.**
   - **Tasks:**
   1.
   2.
