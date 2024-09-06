# Dental Practice Appointment System

This is a .NET MVC web application for managing appointments in a dental practice. The system allows patients, doctors, receptionists, and administrators to perform different actions related to appointments and user management.

## Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Testing](#testing)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)

## Features

### Patients

- Register and log in to the system.
- View their upcoming and past appointments.
- Update their profile information.

### Doctors

- Log in to the system.
- View their appointments for specific dates.
- Update their profile information.

### Receptionists

- Log in to the system.
- Create new appointments for patients.
- Alter existing appointments.
- Cancel appointments.
- View a calendar view of all appointments.

### Administrators

- Log in to the system.
- Perform all actions available to receptionists.
- Add, update, or delete staff members (doctors, receptionists, and other administrators).
- View all appointments for all users.

## Technology Stack

- **Backend:** .NET Core MVC Framework
- **Frontend:** Razor Pages, HTML5, CSS3, JavaScript, Bootstrap
- **Database:** SQL Server
- **Authentication:** ASP.NET Identity
- **IDE:** Visual Studio or Visual Studio Code
- **Testing Frameworks:** xUnit, Selenium WebDriver

## Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/dental-practice-appointment-system.git
   cd dental-practice-appointment-system
   ```

2. **Restore NuGet packages:**
   Open the solution in Visual Studio or Visual Studio Code and restore the required NuGet packages.

3. **Set up the database:**
   Update the `appsettings.json` file with your SQL Server connection string. Run the following commands in the Package Manager Console to apply migrations and set up the database:

   ```bash
   Update-Database
   ```

4. **Run the application:**
   Press `F5` in Visual Studio or use the command line:
   ```bash
   dotnet run
   ```

## Configuration

- **Connection Strings:** Update `appsettings.json` to include the correct connection string for your SQL Server instance.
- **Authentication:** Ensure proper setup of ASP.NET Identity for handling user roles and authentication.

## Usage

1. **Register/Login:**

   - Patients, doctors, and staff can register or log in using their credentials.

2. **Appointments Management:**

   - Patients can view their appointments.
   - Doctors can view their schedules.
   - Receptionists can create, modify, or cancel appointments.
   - Administrators have full control over appointments and user management.

3. **Staff Management:**
   - Administrators can add or remove staff members (doctors, receptionists).

## Testing

The project includes both unit/integration testing and automated UI testing using Selenium.

### Unit and Integration Tests

- **Framework:** xUnit
- **Description:** Unit tests are used to verify the functionality of individual components such as controllers, services, and models. Integration tests are used to test the interaction between multiple components, including database operations.

1. **Run Tests in Visual Studio:**

   - Open the Test Explorer and run all tests or specific test categories.

2. **Run Tests in Visual Studio Code:**
   - Use the integrated terminal to run the following command:
   ```bash
   dotnet test
   ```
