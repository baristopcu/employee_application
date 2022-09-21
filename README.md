# Employee Application

Employee application is a simple project that have AuthenticationService and EmployeeService.

## Installation

Please run two MySql scripts below before starting projects. This app uses .Net Core 3.1

```bash
AuthenticationDB-WithUsersData.sql
```
```bash
EmployeeDB-WithEmployeeData.sql
```

You can find those scripts in root of project. They are going to create databases with named "AuthenticationDB" and "EmployeeDB". If you have databases with same name, please edit script to prevent data loss.

Second step is changing connection string if its required. Connection strings locations are below:

For AuthenticationService:

```bash
AuthenticationService/Authentication.API/appsettings.json
```
For EmployeeService:

```bash
EmployeeService/EmployeeService.API/appsettings.json
```

You can find "ConnectionString" parameter from JSON and be able to change it.

Both services uses localhost and root user without password as default.

## Usage

After installation, you'll have two database with some data in it like users, employees and roles.

Start both service, AuthenticationService will use 5001 port and EmployeeService will use 6001 port if you dont change port settings.

Both services have SwaggerUI in it and you can use this UI to test project.

Test users to authenticate (Scripts includes those data) :

1- adminuser - Password123 (Admin user for testing Update,Insert, Delete)

2- basicuser - Password (Basic user, only reads data)

Run and authenticate from AuthenticateService.
After authenticate process please provide given token to EmployeeService by wherever you are doing test from. (Swagger or Postman etc.)

![auth_service](https://i.imgur.com/tCsg53G.png)

You should able to see request and response schemes from SwaggerUI.

![auth_service](https://i.imgur.com/yXnUHNI.png)
