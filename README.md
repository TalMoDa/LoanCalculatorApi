# LoanCalculatorAPI

## Overview
The `LoanCalculatorAPI` is a backend application designed to calculate loan interests based on client details such as age, loan amount, and loan period. This API allows developers to test its methods using the included `Test.http` file and integrates seamlessly with a database created using the provided `init.sql` script.

---

## Features
- Calculates loan interest based on client details.
- Supports configurable interest rates and extra month interest.
- Designed with modular, reusable components for easy maintenance.
- Includes pre-configured test data and an HTTP client test file for quick validation.

---

## Setup Instructions

### Prerequisites
- .NET 8 or later
- SQL Server or any compatible database engine
- A tool to run HTTP requests (e.g., Postman or the built-in HTTP client in JetBrains Rider/VS Code)

---

### Steps to Run the Application
1. **Clone the Repository**:
   Clone this repository to your local machine.

2. **Database Setup**:
    - Open the `init.sql` file located in the root directory.
    - Execute the script in your SQL Server instance to create the database, tables, and insert the necessary data for the application.

   Example:
   ```bash
   sqlcmd -S <ServerName> -d <DatabaseName> -i init.sql
   ```

3. **Configuration**:
    - Ensure the `appsettings.json` or `appsettings.Development.json` file is configured with the correct connection string for your database.
    - Example connection string:
      ```json
      "ConnectionStrings": {
          "DefaultConnection": "Server=<ServerName>;Database=<DatabaseName>;Trusted_Connection=True;"
      }
      ```

4. **Run the Application**:
    - Use the following command to start the application:
      ```bash
      dotnet run
      ```

5. **Testing the API**:
    - Open the `Test.http` file using an HTTP client tool like JetBrains Rider or VS Code.
    - Send the pre-configured requests to test the API functionality.
    - These requests include sample data for a client already seeded into the database via the `init.sql` script.

---

## File Structure

### Key Folders and Files
- **Controllers**: Contains API controllers that expose endpoints.
- **Data**: Includes entities and repositories for database interaction.
- **Strategies/Calculation**: Implements the core loan calculation logic.
- **init.sql**: SQL script to set up the database schema and insert initial data.
- **Test.http**: A pre-configured HTTP request file to easily test API endpoints.
- **appsettings.json**: Contains application configuration, including database connection strings.

---

## API Endpoints
### Base URL:
`https://localhost:5001`

### Endpoints:
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

## Testing
1. Open the `Test.http` file.
2. Run the pre-configured requests using a compatible HTTP client.
3. Verify that the results match the expected values for the seeded client data.

---

## Troubleshooting
- If the API returns errors:
    - Ensure the database is set up correctly using `init.sql`.
    - Verify the connection string in `appsettings.json`.
    - Check if the server is running on the correct port (default: `5001`).

---

## License
This project is licensed under the MIT License. See the LICENSE file for more information.

---

## Contact
For support or inquiries, contact the author of this API or submit an issue in the repository.

