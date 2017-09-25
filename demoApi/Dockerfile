FROM microsoft/dotnet:2.0.0-sdk-jessie

MAINTAINER Rebecca McCann-Young <r.mccannyoung@gmail.com>

WORKDIR /app

COPY *.csproj .

COPY . .

RUN ["dotnet", "restore"]

EXPOSE 5000

ENV redis_ip=redis
ENV redis_port=6379

ENTRYPOINT ["dotnet", "run"]
