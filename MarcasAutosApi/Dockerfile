# Etapa base con .NET para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MarcasAutosApi.csproj", "./"]
RUN dotnet restore "./MarcasAutosApi.csproj"
COPY . .
RUN dotnet publish "./MarcasAutosApi.csproj" -c Release -o /app/publish

# Etapa final: ejecuta la app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MarcasAutosApi.dll"]
