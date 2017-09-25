FROM microsoft/dotnet:2.0.0-sdk-jessie

MAINTAINER Rebecca McCann-Young <r.mccannyoung@gmail.com>

WORKDIR /app

COPY *.csproj .

COPY . .

RUN ["dotnet", "restore"]

EXPOSE 5000


ENTRYPOINT ["dotnet", "run"]
