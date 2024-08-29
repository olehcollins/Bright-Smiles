# Requirements Analysis

## 1. Introduction

This document outlines the functional and non-functional requirements for the Dentist Appointment System. It provides a comprehensive guide to the expected features, behaviour, and performance criteria for the system, aimed at improving the efficiency of appointment scheduling and patient management in a dental practice.

## 2. Functional Requirements

The functional requirements specify the behaviours and capabilities of the system to meet the needs of dentists, receptionists, and the practice manager.

### 2.1 Patient Interface

- **View Appointments**: Patients shall be able to view their own scheduled appointments, including details of each dentist and appointment time.
- **Book Dental Appointments**: Patients shall be able book and cancel appointments.
- **Update Patient Records**: Patients and add and update their dental records.

### 2.2 Dentist Interface

- **View Appointments**: Dentists shall be able to view their own scheduled appointments, including details of each patient and appointment time.
- **Retrieve Patient Records**: Dentists shall be able to access and review patient records relevant to their appointments.

### 2.3 Receptionist Interface

- **Manage Appointments**: Receptionists shall be able to make new appointments, amend existing ones, and cancel appointments as needed.
- **Register New Patients**: Receptionists shall be able to register new patients by entering their personal and contact details into the system.

### 2.4 Practice Manager Interface

- **Staff Management**: The practice manager shall be able to add new dentists and receptionists to the system.
- **Manage Roles and Permissions**: The practice manager shall be able to assign and modify staff roles and permissions to control access to various features of the system.

## 3. Non-Functional Requirements

The non-functional requirements define the performance, security, and operational standards the system must meet.

### 3.1 Security

- **Data Privacy**: The system shall ensure the confidentiality and security of patient records and personal information through encryption and secure access controls.
- **Role-Based Access Control**: The system shall implement role-based access control to ensure that users can only access information and perform actions appropriate to their role.

### 3.2 Scalability

- **Capacity**: The system shall be designed to handle an increasing number of users and data entries without performance degradation.
- **Cloud Hosting**: The system shall use cloud hosting for the server and database to ensure scalability and flexibility.

### 3.3 Usability

- **User-Friendly Interface**: The system shall have a clear and intuitive user interface tailored to the needs of dentists, receptionists, and the practice manager.
- **Ease of Use**: The interface shall be designed to minimize training requirements and support efficient task completion for all users.

### 3.4 Reliability

- **Availability**: The system shall maintain high availability, with a target uptime of 99.9%.
- **Performance**: The system shall perform reliably under various conditions, including peak usage times, with quick response times for user actions.

## 4. Use Case Diagram

Below is the use case diagram that illustrates the primary interactions between the users and the system:

![Use Case Diagram](/docs/UseCaseDiagram.svg)
