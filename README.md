# SuperHero CRUD Backend Application (ASP.NET Web API)

## Overview

This backend application is built using ASP.NET Web API and provides a set of APIs for CRUD (Create, Read, Update, Delete) operations on a superhero table. Each superhero in the table has a name and a corresponding superpower. Additionally, the application includes APIs for user authentication and registration, allowing users to log in and register to view superheroes through the frontend.

## Technologies Used

- **Framework:** ASP.NET Web API
- **Database:** MS SQL Server

## Setup

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/superhero-crud-backend.git
   cd superhero-crud-backend

## API Endpoints

### Superhero CRUD Operations

- **Create Superhero:**
  - **Endpoint:** `/api/superheroes`
  - **Method:** POST
  - **Request Body:**
    ```json
    {
      "name": "Superman",
      "superpower": "Flight, Super strength"
    }
    ```

- **Get All Superheroes:**
  - **Endpoint:** `/api/superheroes`
  - **Method:** GET

- **Get Superhero by ID:**
  - **Endpoint:** `/api/superheroes/{id}`
  - **Method:** GET

- **Update Superhero:**
  - **Endpoint:** `/api/superheroes/{id}`
  - **Method:** PUT
  - **Request Body:**
    ```json
    {
      "superpower": "Flight, Super strength, Heat vision"
    }
    ```

- **Delete Superhero:**
  - **Endpoint:** `/api/superheroes/{id}`
  - **Method:** DELETE
  ```json
   **Request Body:**
    ```json
    {
      "superpower": "Flight, Super strength, Heat vision"
    }

  ### User Authentication

- **User Registration:**
  - **Endpoint:** `/api/auth/register`
  - **Method:** POST
  - **Request Body:**
    ```json
    {
      "username": "user123",
      "password": "password123"
    }
    ```

- **User Login:**
  - **Endpoint:** `/api/auth/login`
  - **Method:** POST
  - **Request Body:**
    ```json
    {
      "username": "user123",
      "password": "password123"
    }
    ```
  - **Response:**
    ```json
    {
      "token": "your_jwt_token"
    }
    ```
  - The password should be hashed before storing it in the database, and the login endpoint should verify the hashed password.

### Password Hashing

- Passwords should be hashed before storing them in the database. Use a secure password hashing algorithm, such as bcrypt, to enhance security.

### JWT Token

- The JWT token obtained from the login endpoint should be included in the headers of subsequent requests to secure endpoints. Typically, it's included in the `Authorization` header as a Bearer token. Ensure to handle token expiration and implement token refresh mechanisms for enhanced security.

  

