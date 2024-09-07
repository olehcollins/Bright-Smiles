# Dental Practice Appointment System

[![Build Status](https://dev.azure.com/Althaus-Digital-DentalPractice-Platform/Bright%20Smiles/_apis/build/status%2Folehcollins.Bright-Smiles?branchName=main)](https://dev.azure.com/Althaus-Digital-DentalPractice-Platform/Bright%20Smiles/_build/latest?definitionId=2&branchName=main)

This is a .NET MVC web application for managing appointments in a dental practice. The system allows patients, doctors, receptionists, and administrators to perform different actions related to appointments and user management.

<a href="https://olehcollins.github.io/Bright-Smiles/">WireFrame</a>

## Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [CI/CD with Azure DevOps](#cicd-with-azure-devops)
- [Development Workflow using Scrum](#development-workflow-using-scrum)
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
- **CI/CD:** Azure DevOps

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

## CI/CD with Azure DevOps

The project uses Azure DevOps for Continuous Integration and Continuous Deployment (CI/CD). The pipeline is configured to automatically build, test, and deploy the application whenever changes are pushed to the repository.

- **Build Status:** [![Build Status](https://dev.azure.com/Althaus-Digital-DentalPractice-Platform/Bright%20Smiles/_apis/build/status%2Folehcollins.Bright-Smiles?branchName=main)](https://dev.azure.com/Althaus-Digital-DentalPractice-Platform/Bright%20Smiles/_build/latest?definitionId=2&branchName=main)
- **Pipeline Configuration:**
  - The Azure Pipeline is defined using a YAML file located in the root directory of the repository (`azure-pipelines.yml`).
  - The pipeline performs the following tasks:
    - Restores NuGet packages.
    - Builds the .NET solution.
    - Runs unit and integration tests using xUnit.
    - Runs Selenium-based end-to-end tests.
    - Deploys the application to the designated environment.

## Development Workflow using Scrum

The project follows the **Scrum agile methodology** to ensure iterative development and continuous delivery of value. The following practices are in place:

- **Sprint Planning:** At the beginning of each sprint, the team conducts sprint planning to define the sprint goal and select user stories from the product backlog.
- **Daily Stand-ups:** Daily stand-up meetings are held to discuss progress, impediments, and coordinate work.
- **Sprint Review:** At the end of each sprint, a sprint review meeting is conducted to demonstrate the work completed during the sprint and gather feedback.
- **Sprint Retrospective:** After the sprint review, a retrospective meeting is held to discuss what went well, what could be improved, and how to enhance team collaboration and workflow.
- **Backlog Management:** The product backlog is maintained and prioritised in Azure DevOps, and user stories are broken down into tasks and assigned to team members.

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
