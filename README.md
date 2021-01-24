# Azure Function Integration Testing With Dependency Injection 
Demonstrates how to use the DI Container's features inside IHost during integration testing.

## Business Overview
A simple azure function that can send an email and store log at Azure SQL server. This function is trigger by Azure Service Bus.


![alt text](https://github.com/shuvo009/AzureFunctionIntegrationTest/blob/main/imgs/diagram.png "Project Diagram")

## Integration Tests
Integration tests project demonstrates the following features:
- Integration testing azure function.
- Using EF Core in-memory database for integration tests.
- Use IHost startup class (https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihost?view=dotnet-plat-ext-5.0)
- Moqing Email Sending 
