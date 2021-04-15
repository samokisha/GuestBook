# Guest Book

## Requirements

- Docker
- docker-compose

## How to run

1. Build
```sh
docker-compose build
```

2. Run MS SQL Server, RabbitMQ, Storage Service and Api at Docker
```sh
docker-compose up
```

3. Open http://localhost:5000/swagger/index.html in browser
4. Explore API

> Notice:
> 
> 1. The first run may be slow. Please, be patient.
> 2. HTTPS not working now. I try fix it in future.
> 
