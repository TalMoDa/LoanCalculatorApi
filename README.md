# LoanCalculatorAPI

## Overview
The `LoanCalculatorAPI` is a backend application designed to calculate loan interests based on client details such as age, loan amount, and loan period. This API uses modern software engineering principles, including CQRS, Result Pattern, Data-Driven Design, and OpenAPI specifications, to deliver a scalable, maintainable, and well-documented system.

---

## Features
- Calculates loan interest dynamically based on configurable rules stored in the database.
- Implements CQRS for clear separation of read and write operations.
- Uses the Result Pattern to standardize API responses.
- Employs Data-Driven Design to dynamically handle loan scenarios and calculations without hardcoding rules.
- Includes global exception handling for consistent error responses.
- Auto-generates API clients and server stubs using OpenAPI specifications.
- Provides a pre-configured HTTP client test file (`Test.http`) and a database initialization script (`init.sql`).

---

## Architecture Highlights

### **CQRS (Command Query Responsibility Segregation)**
The application separates read and write operations for scalability and maintainability:
- **Commands**: Handle modifications like creating or updating records.
- **Queries**: Handle read operations such as fetching client or loan details.

This ensures a clean separation of concerns and improves the ability to optimize each path independently.

### **Result Pattern**
Encapsulates operation outcomes to provide consistent and robust API responses:
- Success or failure indicators.
- Data returned from the operation (e.g., calculated loan value).
- Error messages or codes for failures.

### **Data-Driven Design**
All loan calculation rules (interest rates, age ranges, thresholds) are stored in the database:
- Fetches rules dynamically from the database to eliminate the need for hardcoded logic.
- Acts as a "strategy provider" without requiring the Strategy Pattern explicitly.

### **Global Exception Handling**
Ensures all exceptions are handled consistently:
- Provides meaningful error messages.
- Avoids exposing sensitive information.
- Centralizes error logging and response formatting.

### **Reverse Engineering with Scaffold**
Generates database models and context classes using `dotnet ef dbcontext scaffold`, ensuring:
- Accurate reflection of the database schema.
- Reduced development time.

### **OpenAPI/Swagger Integration**
- Defines API contracts using OpenAPI specifications (YAML).
- Auto-generates client libraries and server stubs.
- Produces interactive API documentation for easy testing and integration.

---

## Setup Instructions

### Prerequisites
- .NET 8 or later
- SQL Server or any compatible database engine
- A tool to run HTTP requests (e.g., Postman or the HTTP client in JetBrains Rider/VS Code)

### Steps to Run the Application
1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd LoanCalculatorAPI
   ```

2. **Database Setup**:
   - Execute the `init.sql` script in your SQL Server instance to create the database and seed initial data.
     ```bash
     sqlcmd -S <ServerName> -d <DatabaseName> -i init.sql
     ```

3. **Configuration**:
   - Update the `appsettings.json` or `appsettings.Development.json` file with your database connection string.
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=<ServerName>;Database=<DatabaseName>;Trusted_Connection=True;"
     }
     ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

5. **Test the API**:
   - Use the `Test.http` file or tools like Postman to test API endpoints.

---

## API Endpoints

### Base URL
`https://localhost:5001`

### Endpoints
1. **Calculate Loan Interest**:
   - **Method**: `GET`
   - **Endpoint**: `/finance/loan`
   - **Parameters (Query)**:
      - `ClientId` (Guid, required): ID of the client.
      - `LoanAmount` (decimal, required): Amount of the loan.
      - `LoanPeriodInMonths` (int, required): Duration of the loan in months.
   - **Response**: Returns the total loan amount with calculated interest.
   - **Example**:
     ```http
     GET /finance/loan?ClientId=94F94586-2B49-4DAA-850D-BAE017133457&LoanAmount=4500&LoanPeriodInMonths=13
     ```

---


## Testing the API
1. Open the `Test.http` file in your HTTP client tool.
2. Run the pre-configured requests.
3. Verify the results against expected values seeded in the database.

---

## Troubleshooting
- **API Errors**:
   - Ensure the database is properly set up using `init.sql`.
   - Verify the connection string in `appsettings.json`.
   - Check if the server is running on the correct port (default: `5001`).

---


## Contact
For support or inquiries, contact the author of this API or submit an issue in the repository.

