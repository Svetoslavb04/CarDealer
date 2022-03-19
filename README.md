# Car Dealer

Car Dealer is basic MVC app for listing Cars

## Description

The Car Dealer app is an MVC project that stores cars and information about them.
The cars are stored in a database. The application has two user interfaces - Console and Web. Both allow you to add a new entity to the database, edit it and delete it. A search functionality is also available for a specific record by brand or model name.

## Getting Started

### Approaches

The database was created using the Code First approach provided by the framework. We created the models then the database was generated.
The next thing we have done was the car service. In the service is stored all the bussines. To reduce the data transfer we have created input and output models for the car. We implemented a repository class to level up the abstraction. This means in the future we can use another data source. Repository works with the data source
and it is used by the Car Service. 

### Dependencies

- .Net 6
- ASP.NET Core
- Entity Framework Core
- Auto Mapper
- SQL Server
- Bootstrap
- JQuery

## Authors

Martin Yovkov and Svetoslav Borislavov

