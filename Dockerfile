# Imagen base del SDK de .NET para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos y restaurar dependencias
COPY . . 
RUN dotnet restore

# Compilar y publicar la aplicación
RUN dotnet publish -c Release -o out

# Imagen base de .NET Runtime para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto que usará la app
EXPOSE 80

# Comando para iniciar la app
ENTRYPOINT ["dotnet", "Lab13_DAEA.dll"]
