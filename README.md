# Blazor .Net 8 Demo

This demo (repo) is meant to demonstrate some key comprehensions related to typical .Net web application development.

Also included is a basic example of new .Net 8 Rendermodes for Blazor. It was initially set using InteractiveAuto, but performed better using InteractiveServer.

### Notes:
    1. Client-side services were omitted for this demo.
    2. Data validations were omitted for this demo.
    3. I used a very separated MVVM architecture to demonstrate a comprehension, but I don't actually prefer over-architected software.
    
## Installation 
- Simply Clone this repository using Visual Studio 2022 (.Net required)
- Build and run the solution in Visual Studio 2022
- Once the solution is running, if the browser does not automatically load, you can simply pull up a browser and paste in the https localhost url from BlazorNet8Demo > Properties > launchSettings.json (https://localhost:7284)

## Key Items Demonstrated
### Architecture
A very separated MVVM architecture. I wanted to demonstrate that I've worked in these kinds of architectures, 
but I don't always think they are necessary depending on the scope of the application.

### .Net Core
Setup and configuration for a typical web application using .Net Core and Entity Framework 8.

### Entity Framework Core
Setup, configuration and utilization of Entity Framework Core 8, including dependency injection for the ApplicationDbContext.
<br />
This demo utilizes an in-memory database.

### Blazor .Net 8
Demonstrate the fundamentals of a new Blazor Web App solution using .Net 8 & Entity Framework Core 8.

### Integration Testing
Demonstrate the fundamentals of integration testing using MSTest to test the Repository.
