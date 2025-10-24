# GestionTurnos

Aplicación web para la gestión de turnos y afiliados desarrollada en ASP.NET Core.

## Descripción

GestionTurnos es una aplicación web que permite administrar afiliados y gestionar turnos (crear, editar, listar y eliminar). Está pensada para centros que necesitan organizar citas o turnos con controles de acceso básicos y generación de carnets/QRs.

El proyecto principal se encuentra en `GestionTurnos.Web` (archivo de proyecto: `GestionTurnos.Web/GestionTurnos.Web.csproj`).

## Funcionalidades principales

- Gestión de afiliados: crear, editar, ver detalles y eliminar.
- Gestión de turnos: programación y listado de turnos (desde la interfaz o mediante controladores si se expone API interna).
- Repositorios y servicios separados para mantener una capa de acceso a datos desacoplada.
- Soporte para migraciones y esquema de base de datos usando Entity Framework Core (`GestionTurnos.Web/Migrations`).
- Vistas Razor para las páginas web (carpeta `GestionTurnos.Web/Views`) y recursos estáticos en `wwwroot`.
- Generación de QR/carnet (hay un helper `Helpers/QrHelper.cs`).

## Requisitos

- .NET SDK 8.0 (o la versión indicada por el proyecto)
- PostgreSQL 17
- .ENV con las credenciales de tu base de datos
- (Opcional) Docker para ejecutar en contenedor

## Uso rápido / Cómo ejecutar (desarrollo)

Abre una terminal PowerShell en la carpeta raíz del repositorio (donde está la solución `GestionTurnos.slnx`) y ejecuta:

```powershell
# Restaurar paquetes
dotnet restore GestionTurnos.Web/GestionTurnos.Web.csproj

# Compilar el proyecto
dotnet build GestionTurnos.Web/GestionTurnos.Web.csproj

# Ejecutar la aplicación en el entorno de desarrollo
dotnet run --project GestionTurnos.Web/GestionTurnos.Web.csproj
```

Por defecto la aplicación cargará la configuración de `GestionTurnos.Web/appsettings.json` y, si está presente, `appsettings.Development.json`.

Accede a la aplicación desde el navegador en la URL que muestre la salida del comando `dotnet run`.

## Base de datos y migraciones

Las migraciones están en `GestionTurnos.Web/Migrations`. Para crear o aplicar migraciones:

```powershell
# Añadir una nueva migración (desde la raíz del repo)
dotnet ef migrations add NombreDeLaMigracion --project GestionTurnos.Web/GestionTurnos.Web.csproj --startup-project GestionTurnos.Web

# Aplicar migraciones a la base de datos
dotnet ef database update --project GestionTurnos.Web/GestionTurnos.Web.csproj --startup-project GestionTurnos.Web
```

Nota: si no tienes las herramientas de EF Core instaladas globalmente, instálalas o usa `dotnet tool restore` si el repo las incluye como herramienta local.

## Ejecutar con Docker

En la carpeta del proyecto web existe un `Dockerfile`. Para construir y ejecutar el contenedor:

```powershell
# Construir la imagen (desde la raíz del repo)
docker build -t gestionturnos -f GestionTurnos.Web/Dockerfile .

# Ejecutar el contenedor, mapeando puertos según el Dockerfile (ejemplo 5000->80)
docker run -p 5000:80 gestionturnos
```

## Configuración importante

- `GestionTurnos.Web/appsettings.json` y `appsettings.Development.json`: cadenas de conexión y opciones de la aplicación.
- `Program.cs`: punto de entrada y registro de servicios (DI), middlewares y rutas.

## Estructura relevante (resumen)

- `GestionTurnos.Web/Controllers/` — controladores MVC
- `GestionTurnos.Web/Data/` — `AppDbContext` y fábrica de contextos
- `GestionTurnos.Web/Repositories/` — acceso a datos
- `GestionTurnos.Web/Services/` — lógica de negocio
- `GestionTurnos.Web/Models/` — modelos y viewmodels
- `GestionTurnos.Web/Views/` — vistas Razor
- `GestionTurnos.Web/wwwroot/` — recursos estáticos (css, js, imágenes)

## Contribuir

1. Clona el repositorio y abre la solución `GestionTurnos.slnx` en Visual Studio o VS Code.
2. Crea una rama para tu trabajo.
3. Añade pruebas o actualiza migraciones cuando cambies el esquema de la base de datos.
4. Abre un pull request con una descripción clara de los cambios.
