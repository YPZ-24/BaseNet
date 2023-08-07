# BaseNET

Es la base de una API .NET Core con arquitectura clean y mediator

## Requisitos

- .NET Core 6 SDK: [Enlace de descarga](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022: [Enlace de descarga](https://visualstudio.microsoft.com/es/downloads/)
- SQL Server: [Enlace de descarga](https://www.microsoft.com/es-MX/sql-server/sql-server-downloads)

## Configuración

1. Clona este repositorio en tu máquina local
2. Abre la carpeta del proyecto en Visual Studio
3. Entra a la solución `IntranetCorrespondencia.sln`
4. Establece IntranetCorrespondencia.api como proyecto de inicio
5. Abre el archivo `appsettings.Development.json` y configura la cadena de conexión `IntranetCorrespondenciaDb` para que se conecte a tu host local de base de datos, deberás sustituir: `DbHost`, `user` y `password`, por los que tengas en tu maquina
7. Ejecuta los siguientes comandos en la consola de Administración de paquetes, para aplicar las migraciones a tu base de datos local:
   ```bash
   Add-Migration InitialCreate
   Update-Database
8. Inicia la aplicación presionando `start`
