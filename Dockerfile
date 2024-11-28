

# Step 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80

# Copy project files
COPY *.csproj .
RUN dotnet restore

# Copy the remaining files and build
COPY . .
RUN dotnet publish -c Release -o /publish

# Step 2: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the .dll file from the build step
COPY --from=build /publish .

# Specify the entry point for the app
ENTRYPOINT ["dotnet", "tSchoolManagementSystem.dll"]
