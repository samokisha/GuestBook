# Guest Book

## Requirements

- .Net Core 5
- Docker
- docker-compose

## How to run

1. Run MS SQL Server and RabbitMQ at Docker
```sh
docker-compose up -d
```

2. Run StorageService
```sh
dotnet run -p StorageService
```

3. Run Api
```sh
dotnet run -p Api
```

4. Open https://localhost:5001/swagger/index.html in browser
5. Explore API
