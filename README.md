JoaoLuizDeveloperProject
A personal project by João Luiz showcasing a modular architecture using ASP.NET Core, following best practices for scalable and maintainable applications.

📁 Project Structure
JoaoLuizDeveloper.Application/: Application layer containing business logic.

JoaoLuizDeveloper.Domain/: Domain entities and interfaces.

JoaoLuizDeveloper.Infrastructure/: Infrastructure layer for data access and external services.

JoaoLuizDeveloper.Web/: ASP.NET Core MVC web application.

JoaoLuizDeveloper.WebAPI/: ASP.NET Core Web API project.

JoaoLuizDeveloper.IntegrationTest/: Integration tests.

UnitTest/: Unit tests.

JoaoLuizDeveloper.sln: Visual Studio solution file.

🛠️ Technologies Used
ASP.NET Core

Entity Framework Core

xUnit for testing

🚀 Getting Started
Clone the repository:

git clone https://github.com/JoaoLuizDeveloper/JoaoLuizDeveloperProject.git
<br />
cd JoaoLuizDeveloperProject
Set up the database:

Ensure you have a SQL Server instance running. Update the connection strings in the configuration files as needed.

Run the application:

Open the solution in Visual Studio and run the desired project (Web or WebAPI). Alternatively, use the .NET CLI:

dotnet build
dotnet run --project JoaoLuizDeveloper.Web
The application will be available at http://localhost:5000.

📄 License
This project is licensed under the MIT License.
