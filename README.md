# Prueba Técnica - MarcasAutosApi (.NET + PostgreSQL + Docker)

Este proyecto es una API RESTful desarrollada en C# (.NET 8) para gestionar marcas de autos. Incluye:
- Entity Framework Core para conexión con PostgreSQL
- Pruebas unitarias con XUnit
- Reporte de cobertura de código
- Docker Compose para levantar la API y la base de datos

---

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

---

## Ejecución del proyecto (Docker)

1. Abre una terminal en la carpeta raíz (donde está `docker-compose.yml`)
2. Ejecuta:

docker-compose up --build

3. Abre en tu navegador:

http://localhost:5000/swagger

Desde Swagger podrás probar los endpoints disponibles.

---

## Ejecutar pruebas unitarias

Desde la carpeta raíz del proyecto:

dotnet test

---

## Ver reporte de cobertura de código

1. Ejecuta las pruebas con cobertura:

dotnet test --collect:"XPlat Code Coverage"

2. Si tienes instalado `reportgenerator`, genera el reporte HTML:

reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:coverage-report -reporttypes:Html

3. Abre el archivo:

coverage-report/index.html

---

## Estructura del proyecto
CodeTest/
├── MarcasAutosApi/
│   ├── Controllers/
│   ├── Data/
│   ├── Models/
│   ├── Program.cs
│   └── Dockerfile
│
├── MarcasAutosApi.Tests/
│
├── docker-compose.yml
└── README.md

---

## Información adicional

- La API expone los endpoints en `/api/MarcasAutos`
- Swagger está disponible en `http://localhost:5000/swagger`
- El contenedor de la base de datos PostgreSQL usa:
  - usuario: `postgres`
  - contraseña: `admin1357`
  - base de datos: `MarcasAutosDb`