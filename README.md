# Order Management

Basic Order Management api project . I used ASP.NET Core Web API, MsSQL,HttpLogging,JWT, Swagger, Entity Framework Core.

## Getting Started

First of all, you need to clone the project to your local machine.

```
git clone https://github.com/deniztanverdi/Order.Management.git
cd Order.Management
```
### Building

A step by step series of building that project

1. Restore the project :hammer:

```
dotnet restore
```

2. Update appsettings.json or appsettings.Development.json (Which you are working stage)

2. Change all connections for your development or production stage

3. If you want to use different Database Provider (MS SQL, MySQL etc...) You can change on Api layer File: Program.cs (Line: 100)

```
    //For Microsoft SQL Server
    builder.Services.AddDbContext<OrderManagementDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(OrderManagementDbContext)).GetName().Name);
    });
});
```

5. Run EF Core Migrations

```
dotnet ef database update
```
## Endpoints

Swagger link

```
http://localhost:7075/swagger/index.html
```
- `POST      /api/users/authenticate/` Token is created for the orders
- `POST      /api/order/{customerId}/` Creates an order
- `PUT      /api/order/{customerId}/`  Editing an order
- `DELETE  /api/order/{id}/`           Deletes an order
- `GET    /api/order/{id}/`            Returns order by id
- `GET    /api/order/{customerId}/orders` Returns orders by customerId

