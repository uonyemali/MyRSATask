RSATask Project README

Test Data is contained in the Test Data folder

Overview

The RSATask project aims to provide functionality for managing weather forecasts. It includes features such as uploading weather forecast data from CSV files, retrieving weather forecasts from an external API, and displaying weather forecasts on a web interface.

Project Structure

RSATask.Web: This project contains the web application, including controllers, views, and static files.

RSATask.Domain: This project defines the domain models used throughout the application, such as WeatherForecast and LocationViewModel.

RSATask.Data: This project contains data access logic, including repositories and database context.

RSATask.Services: This project houses the business logic and services used by the application, such as CSV parsing and HTTP requests.

RSATask.Tests: This project contains unit tests and integration tests for various components of the application.

Approach

Requirement Analysis: Understanding the project requirements and identifying key features such as CSV parsing, HTTP requests, and data management.

Architecture Design: Designing the overall architecture of the application, including separation of concerns and dependency injection.

Implementation: Writing code to implement the defined features, following best practices and design patterns.
Testing: Creating unit tests and integration tests to ensure the correctness and robustness of the codebase.

Documentation: Documenting the codebase, including inline comments, README files, and any necessary documentation for future reference.

Technologies Used

ASP.NET MVC: For building the web application and handling HTTP requests.
Entity Framework: For data access and database management.

MOQ: For creating mock objects in unit tests.

Newtonsoft.Json: For JSON serialization and deserialization.

Serilog: For logging errors and diagnostic information.
Bootstrap: For styling the web interface and ensuring responsiveness.

Future Enhancements
Implementing pagination for large datasets to improve performance.
Add more unit tests to cover more scenarios
Enhancing error handling and logging to provide better feedback to users and developers.
