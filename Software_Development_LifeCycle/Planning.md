# Project Initialization and Planning (Sprint Zero)

## 1. Define the Project Vision and Goals

- **Project Vision**: To build a microservices-based blogging platform that allows users to register, create, edit, and manage blog posts, leave comments, and receive notifications.
- **Project Goals**:
  1. Implement a modular architecture using microservices.
  2. Ensure high-quality code with automated testing.
  3. Deploy the application to the cloud for real-world use.
  4. Document the project thoroughly to demonstrate your skills.

## 2. Set Up the Scrum Framework

- **Scrum Team Roles**:

  - **Product Owner**: Define and prioritize features (I will take on this role).
  - **Scrum Master**: Ensure the Scrum process is followed (I will also take on this role).
  - **Development Team**: Implement the features (I will take on this role).

- **Scrum Artifacts**:
  - **Product Backlog**: Contains all the features, enhancements, and fixes required in the product.
  - **Sprint Backlog**: A list of tasks to be completed during the sprint, derived from the product backlog.
  - **Increment**: The working product at the end of each sprint, which includes all completed tasks.

## 3. Project Management Tools for Agile Development

### 3.1 Project Board

- **Tool**: Azure DevOps
- **Purpose**: It creates a pipeline so that commits to the GitHub repo invoke a continuous integration build in Azure DevOps. Once that build is complete, it will invoke a continuous delivery deployment to push the bits out to Azure, creating the required resources, if necessary.
- **Setup Documentation**: [Azure DevOps Labs - GitHub Integration](https://www.azuredevopslabs.com/labs/vstsextend/github-azurepipelines/)

### 3.2 High-Level User Stories

- **Blog App Version 1.0**:

  1. **As a blogger**, I want to create an account, update it, and delete it if I no longer want it.
  2. **As a blogger**, I want to log in to access my personalized blog space and log out when I am done.
  3. **As a blogger**, I want to create and publish blog posts so that I can share my ideas with the world.
  4. **As a blogger**, I want to create, edit, and delete blog posts so that I can manage my content.
  5. **As a user**, I want to browse various posts without having to create an account.

- **Blog App Version 2.0**:

  1. **As a user**, I want to like and comment on blog posts that interest me.
  2. **As a user**, I want to unlike and uncomment on blog posts.

- **Blog App Version 3.0**:
  1. **As a user**, I want to get notifications when my favorite blogger posts a blog.
  2. **As a user**, I want to subscribe to my favorite bloggers so I can keep up to date with what they post.
  3. **As a user**, I want to see my favorite blog posts first before others.
  4. **As a user**, I want to share blog posts that I find interesting.
