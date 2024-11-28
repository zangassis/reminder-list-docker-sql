## Create the app

```bash
dotnet new mvc -o ReminderList -au none
```

## NuGet packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore
```
## Create docker image 

```bash
docker build -t todoapp .  
```

## Run docker container

```bash
docker run -d -p 8080:80 --name todoapp-container todoapp
```


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "ReminderList.dll"]
