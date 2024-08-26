# Requirements Analysis

## 1. Introduction

This document outlines the functional and non-functional requirements for the blogging platform project. It serves as a guide to understanding the expected features, behaviour, and performance criteria for the system.

## 2. Functional Requirements

The functional requirements describe the expected behaviour of the system, focusing on what the system should do to meet the needs of the users.

### 2.1 User Management

- **User Registration**: The system shall allow users to create an account by providing their username, email, and password.
- **User Authentication**: The system shall allow users to log in using their credentials and access their personalised dashboard.
- **User Profile Management**: The system shall allow users to update their profile information and delete their account if desired.

### 2.2 Blogging Features

- **Create Blog Post**: The system shall allow users to create, edit, and delete blog posts.
- **Publish Blog Post**: The system shall allow users to publish blog posts, making them visible to other users.
- **View Blog Posts**: The system shall allow all users, including guests, to view published blog posts.
- **Commenting System**: The system shall allow users to comment on blog posts, and the author to moderate or delete comments.

### 2.3 Interaction Features (Version 2.0)

- **Like/Unlike Posts**: The system shall allow users to like or unlike blog posts.
- **Follow Bloggers**: The system shall allow users to follow their favourite bloggers and receive updates when new posts are published.

### 2.4 Notification System (Version 3.0)

- **Post Notifications**: The system shall notify users when bloggers they follow publish new content.
- **Subscription Management**: The system shall allow users to manage their subscriptions to different bloggers.
- **Priority Display**: The system shall prioritise displaying blog posts from followed bloggers at the top of the feed.

## 3. Non-Functional Requirements

The non-functional requirements specify the performance and operational criteria the system must meet.

### 3.1 Performance

- **Scalability**: The system shall scale to accommodate a large number of concurrent users without performance degradation.
- **Response Time**: The system shall respond to user requests within 2 seconds for standard operations under normal load.

### 3.2 Security

- **Data Protection**: The system shall implement strong encryption for storing sensitive user information, such as passwords.
- **Access Control**: The system shall ensure that only authenticated users can access personalised features and sensitive information.

### 3.3 Usability

- **User Interface**: The system shall have an intuitive and easy-to-navigate user interface to enhance user experience.
- **Accessibility**: The system shall be accessible to users with disabilities, complying with WCAG 2.1 standards.

### 3.4 Reliability

- **Uptime**: The system shall maintain an uptime of 99.9% to ensure availability.
- **Error Handling**: The system shall handle errors gracefully, providing user-friendly error messages and logging issues for later review.

## 4. Use Case Diagram

Below is the use case diagram that illustrates the primary interactions between the users and the system:

![Use Case Diagram](/UseCaseDiagram.svg)
