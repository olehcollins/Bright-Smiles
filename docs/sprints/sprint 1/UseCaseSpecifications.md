# Use Case: Login

- **Actors:** User (account holder)
- **Preconditions:**

  - The user has an account on the dental platform.
  - The user has can access the website via the internet.

- ## Main Flow:

  1.  The use case begins when the user selects Sign In The system requests the Username/Password.
  2.  The user enters username and password.
  3.  The system verifies the username/password.
  4.  The system checks to see if the username relates to an admin account.
  5.  If the username/password are correct the system authorises the login
  6.  The system allows access to the correct functions for the user.
  7.  The use case ends when the user is logged in

- ## Alternate Flows:

  - **Invalid Username/Password**:
    - If the username or password entered by the user is incorrect, the system displays an error message indicating invalid credentials.
    - The user is prompted to re-enter their username and password.
    - The use case returns to step 2 of the main flow.
  - **Account Locked**:
    - If there have been too many consecutive failed login attempts, the system locks the user’s account for security reasons.
    - The system displays a message indicating the account is locked and provides instructions for unlocking it, such as contacting customer support or following a password recovery process.
    - The use case ends.
  - **Admin Login**:
    - If the system identifies the username as related to an admin account, the system authorises the login with additional security checks (such as two-factor authentication).
    - If the additional security checks fail, the system returns an error message and does not authorise the login.
    - If successful, the admin is granted access to admin-specific functions.
  - **System Error**:
    - If a system error occurs (e.g., the server is down, or there is a network issue), the system displays an error message indicating the problem.
    - The use case ends, and the user is unable to log in until the issue is resolved.

- ## Post Conditions:
  - The user is successfully logged into the dental platform.
  - The user is granted access to the appropriate functions and features based on their role (e.g., admin or regular user).
  - An authentication session is created for the user.
  - Failed login attempts (if any) are recorded for security and monitoring purposes.
