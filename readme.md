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

To run it from docker (recommended) run docker and run the command:

```
docker run ramymn/demoApi
```

To use the api, run GET or PUT commands, for example 

```
POST http://localhost:5000/api/products/<insertProductNumber>
```

and 

```
PUT http://localhost:5000/api/products/<insertProductNumber>
```
