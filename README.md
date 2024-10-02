# WebApi

This project was created to learn about the commands and integrate with Swagger and Postgres

### Commands:

Migrations:

- `dotnet ef migrations add InitialDB --context SystemTaskDBContext`
- `dotnet ef database update --context SystemTaskDBContext`

Running in development:

- `dotnet run --environment Development`
- `dotnet watch run --environment Development`
