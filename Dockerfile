# Use the official ASP.NET Core runtime image as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["DentistAppointmentSystem/DentistAppointmentSystem.csproj", "DentistAppointmentSystem/"]
RUN dotnet restore "DentistAppointmentSystem/DentistAppointmentSystem.csproj"

# Copy the rest of the application source code
COPY . .

# Build the application
WORKDIR "/src/DentistAppointmentSystem"
RUN dotnet build "DentistAppointmentSystem.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "DentistAppointmentSystem.csproj" -c Release -o /app/publish

# Final stage: Create the runtime image with the published output
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DentistAppointmentSystem.dll"]