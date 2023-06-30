# SalesWebApp


## About the project
A web application that allows salesmen to manage products and orders for delivery to customers. The application provides functionality for creating, updating, deleting, and viewing products, as well as creating, updating, deleting, and viewing orders. Salesmen can use the application to manage their inventory and track orders for delivery to customers

The project is developed using clean architecture and minimal api in .net 7.0. The project is developed using vertical slice architecture and mediator pattern CQRS. 



## Software Architecture
- Clean Architecture
- Vertical slice architecture
- Mediator pattern CQRS


## Layers

- Domain: This layer contains the business logic and domain entities. It is independent of any specific technology or framework and defines the core concepts and rules of the application.
  
- Application: This layer contains the application logic and is responsible for handling user input and output. It communicates with the domain layer to perform business logic and with the infrastructure layer to access external resources.
  
- Infrastructure: This layer contains the implementation details of the application, such as database access, external APIs, and other infrastructure concerns. It communicates with the domain layer to persist data and with the application layer to provide external services.
- Api: This layer contains the api endpoints and is responsible for handling user input and output. It communicates with the application layer to perform business logic and with the infrastructure layer to access external resources.


## Technologies And Libraries used
- .Net 7.0
- Minimal API
- Entity Framework Core 7.0
- MediatR
- FluentValidation
- Mapster
- ErrorOr
  