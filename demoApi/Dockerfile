FROM microsoft/dotnet:2.0.0-sdk-jessie

MAINTAINER Rebecca McCann-Young <r.mccannyoung@gmail.com>

RUN apt-get update && apt-get install -y \
    redis-server \
  && apt-get clean \
  && rm -rf /var/lib/apt/lists/*

RUN /etc/init.d/redis-server start --port=6379

WORKDIR /app

COPY *.csproj .

COPY . .

RUN ["dotnet", "restore"]

EXPOSE 5000


ENTRYPOINT ["dotnet", "run"]
