# demoApi

demoApi is a standard .NET Core webapi application. I set it up to read the IP address and port of the redis instance from environmental variables, redis_ip and redis_port. For development, I just used a docker image of redis, the latest. (port 127.0.0.1 and port 6379). 

To build the project, navigate into the folder of demoApi project run the following command

```
dotnet build
```

To run it locally, navigate into the folder of the demoApi project run the following command:

``` 
dotnet run
```

To use the api, run GET or PUT commands, for example 

```
POST http://localhost:5000/api/products/<insertProductNumber>
```

and 

```
PUT http://localhost:5000/api/products/<insertProductNumber>
```
I've taken the liberty of adding swagger to the project, to provide a basic and clean front end for testing. it can be found at 

```
http://localhost:5000/swagger
```