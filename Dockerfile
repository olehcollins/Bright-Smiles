# Use the .NET 8.0 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ["DentistAppointmentSystem/DentistAppointmentSystem.csproj", "DentistAppointmentSystem/"]
RUN dotnet restore "DentistAppointmentSystem/DentistAppointmentSystem.csproj"
COPY . .
WORKDIR "/app/DentistAppointmentSystem"
RUN dotnet build "DentistAppointmentSystem.csproj" -c Release -o /app/build

# Publish the application to the /app/publish directory
FROM build AS publish
RUN dotnet publish "DentistAppointmentSystem.csproj" -c Release -o /app/publish

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5223
ENTRYPOINT ["dotnet", "DentistAppointmentSystem.dll"]