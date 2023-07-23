# Elevator Control System API

The Elevator Control System API is a C# ASP.NET Core Web API that simulates an elevator control system. It allows users to request elevators and manage elevator operations through API endpoints.

## Prerequisites

Before you can build and run the project, make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download): Ensure you have .NET 5 SDK or a compatible version installed.

## Building the Project

To build the Elevator Control System API project, follow these steps:

1. Open a terminal or command prompt.

2. Navigate to the root folder of the project (where the .csproj file is located).

3. Run the following command to build the project:

dotnet build

This command will compile the code and generate the necessary build artifacts.

## Running the API

To run the Elevator Control System API, follow these steps:

1. Make sure the project is successfully built (if not, run `dotnet build` first).

2. In the terminal or command prompt, navigate to the root folder of the project.

3. Run the following command to start the API:

dotnet run

4. Once the API is running, you can access it in your web browser or use a tool like [Postman](https://www.postman.com/) to interact with the API endpoints.

The API will be available at `https://localhost:8080` by default. Swagger API landing page will be available at `https://localhost:8080/swagger/index.html`

## API Endpoints

The Elevator Control System API provides the following endpoints:

- `POST /api/person/request_elevator`: Request an elevator to the current floor.

- `POST /api/person/request_floor`: Request to be brought to a floor.

- `GET /api/elevator/request_servicing_floors`: Request all floors that the elevator's current passengers are servicing.

- `GET /api/elevator/request_next_floor`: Request the next floor the elevator needs to service.

Please refer to the API documentation or the Swagger UI for detailed information about the request payloads and responses for each endpoint.

## Notes

- This project is a simplified simulation of an elevator control system and might not represent a full production implementation.

- Feel free to customize and extend the code according to your requirements.

- For more details about the ASP.NET Core framework and Web API development, refer to the [official documentation](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0).

