# demoApi

demoApi is a standard .NET Core webapi application.

To buid the project, navigate into the folder of demoApi project run the following command

```
dotnet build
``` 

To run it locally, navigate into the folder of the demoApi project run the following command:

``` 
dotnet run
```

To run it from docker (recommended) run docker compose file found in the same directory as the readme:

```
docker-compose –f commpose.yml pull
docker-compose –f commpose.yml up –d
```
To break it down run 
```
docker-compose –f commpose.yml down
```
To use the api, run GET or PUT commands, for example 

```
POST http://localhost:5000/api/products/<insertProductNumber>
```

and 

```
PUT http://localhost:5000/api/products/<insertProductNumber>
```
