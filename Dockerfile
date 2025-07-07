# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos y restaurar dependencias
COPY . . 
RUN dotnet restore

# Publicar solo el proyecto API
RUN dotnet publish Lab13_LindaAroniSuana.API/Lab13_LindaAroniSuana.API.csproj -c Release -o /out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar archivos publicados
COPY --from=build /out .

# Render requiere esto para detectar el puerto correctamente
ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE 10000

# Iniciar la API
ENTRYPOINT ["dotnet", "Lab13_LindaAroniSuana.API.dll"]
