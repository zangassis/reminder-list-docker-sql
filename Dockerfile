# Build Stage: Use .NET 8 SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code into the container
COPY . ./

# Publish the application to a folder named 'publish'
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage: Use .NET 8 ASP.NET image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# Set the environment to Development
ENV ASPNETCORE_ENVIRONMENT=Development

# Set the working directory inside the container
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/publish .

# Expose port 80 for HTTP traffic
EXPOSE 80

# Set the entry point to run the app
ENTRYPOINT ["dotnet", "ReminderList.dll"]