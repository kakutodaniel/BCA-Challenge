# Auction Management System

## Overview
This project is a Web API built with ASP<span>.NET</span> Core 6. It provides a set of endpoints for managing resources in a simple Car Auction Management System, offering some operations.

## Technologies Used
- .NET 6.0
- ASP<span>.NET</span> Core 6.0
- Entity Framework Core 7.0 (in memory)
- Swagger 6.5

## Requirements
To run and test this project, you will need the following:

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Postman or another tool to test the endpoints (or Swagger, which will be launched when you run the application)

## Endpoints Overview
Here is an overview of the main API endpoints available:

**Auction**

- POST `/api/auction/start`: Add a new auction for the specified vehicle ids
- POST `/api/auction/{id}/stop`: Stop an auction for the specified auction id
- GET `/api/auction`: Retrieve all auctions

**Bid**

- POST `/api/bid/vehicle/{vehicleId}/place`: Place a bid on the vehicle

**Vehicle**

- POST `/api/vehicle/hatchback`: Add a new hatchback vehicle
- POST `/api/vehicle/sedan`: Add a new sedan vehicle
- POST `/api/vehicle/suv`: Add a new suv vehicle
- POST `/api/vehicle/truck`: Add a new truck vehicle
- GET  `/api/vehicle/search`: Retrieve vehicles by the specified arguments


## Design Patterns Overview

#### 1. CQRS (Command Query Responsibility Segregation)
CQRS is a pattern that separates the responsibility of reading data (queries) and writing data (commands). Instead of using a single model for both read and write operations, we divide the data management into two distinct parts:

- Commands: Represent actions that modify the state of the system.
- Queries: Represent actions that retrieve data without changing the state.

#### 2. Mediator Pattern
The Mediator pattern is used to centralize communication between different components or services within the system. Instead of components communicating directly with each other, they communicate through a mediator, which helps reduce the dependencies between them and centralize the logic for handling communication.

#### 3. DDD (Domain-Driven Design)
DDD is a design methodology that focuses on the business domain and models the application around the domain's rules and logic. The goal is to create a rich, expressive model that mirrors the real-world business processes. DDD emphasizes collaboration between domain experts and developers to create a shared understanding of the domain.

## Assumptions and Validations

When creating a new vehicle, the following assumptions and validations are applied to ensure that the data provided meets the required criteria:

- **Number of doors**:
    - Hatchback: (min: 2, max: 10)
    - Sedan: (min: 2, max: 10)

- **Number of seats**:
    - Suv: (min: 4, max: 20)

- **Load Capacity**:
    - Truck: (min: 1, max: 10000)

- **Identifier (length)**:
    - All vehicle types: (min: 2, max: 50)

- **Manufacturer (length)**:
    - All vehicle types: (min: 2, max: 50)

- **Model (length)**:
    - All vehicle types: (min: 2, max: 50)

- **Year**:
    - All vehicle types: (min: 1900, max: current year)

- **StartingBid**:
    - All vehicle types: (min: 1)


