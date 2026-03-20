# User Management API

This project is a simple ASP.NET Core Web API for managing users. It supports CRUD operations and includes validation and custom middleware.

## Features

- ✅ Get all users
- ✅ Get user by ID
- ✅ Create user
- ✅ Update user
- ✅ Delete user
- ✅ Input validation
- ✅ Request logging middleware
- ✅ Swagger/OpenAPI documentation

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users` | Create a new user |
| PUT | `/api/users/{id}` | Update an existing user |
| DELETE | `/api/users/{id}` | Delete a user |

## Validation Rules

- **Name**: Required, must be 2-100 characters
- **Email**: Required and must be a valid email address
- **Age**: Required, must be greater than 0

## Middleware

- **Request Logging Middleware**: Logs all incoming HTTP requests with method, path, and response status code

## Project Structure

```
UserManagementAPI/
├── Controllers/
│   └── UsersController.cs      # API endpoints
├── Models/
│   └── User.cs                 # User model with validation attributes
├── Middleware/
│   └── RequestLoggingMiddleware.cs  # Custom logging middleware
├── Program.cs                  # Application setup and configuration
├── appsettings.json            # Default configuration
├── appsettings.Development.json # Development-specific configuration
└── UserManagementAPI.csproj    # Project file
```

## Running the Project

### Prerequisites
- .NET 8.0 SDK or later
- A terminal or command prompt

### Steps

1. **Navigate to the project directory**:
   ```bash
   cd UserManagementAPI
   ```

2. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. **Access the API**:
   - API Base URL: `https://localhost:5001/api/users`
   - Swagger UI: `https://localhost:5001/swagger/index.html`

## Example Requests

### Get All Users
```bash
curl https://localhost:5001/api/users
```

### Get User by ID
```bash
curl https://localhost:5001/api/users/1
```

### Create a New User
```bash
curl -X POST https://localhost:5001/api/users \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Alice Johnson",
    "email": "alice@example.com",
    "age": 25
  }'
```

### Update a User
```bash
curl -X PUT https://localhost:5001/api/users/1 \
  -H "Content-Type: application/json" \
  -d '{
    "name": "John Updated",
    "email": "john.updated@example.com",
    "age": 31
  }'
```

### Delete a User
```bash
curl -X DELETE https://localhost:5001/api/users/1
```

## Response Examples

### Success Response (200 OK)
```json
{
  "id": 1,
  "name": "John Doe",
  "email": "john@example.com",
  "age": 30
}
```

### Validation Error Response (400 Bad Request)
```json
{
  "name": ["Name is required"],
  "email": ["Email must be valid"],
  "age": ["Age must be greater than 0"]
}
```

### Not Found Response (404)
```json
{
  "message": "User with ID 999 not found"
}
```

## Copilot Usage

GitHub Copilot was instrumental in:
- Designing the controller logic with proper HTTP status codes
- Implementing comprehensive input validation using Data Annotations
- Creating the custom middleware for request logging
- Structuring the project with best practices
- Generating comprehensive documentation and examples

## Future Enhancements

- Database integration (SQL Server, PostgreSQL, etc.)
- Authentication and authorization
- Pagination and filtering
- Unit and integration tests
- Error handling middleware
- API versioning
