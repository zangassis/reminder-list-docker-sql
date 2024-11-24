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
