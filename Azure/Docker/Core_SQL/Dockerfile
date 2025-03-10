# Etapa base, donde se prepara la imagen final con ASP.NET Core.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solo el archivo .csproj para restaurar dependencias
#COPY ["WebApiEntityFrameworkDockerSqlServer.csproj", "./"]
COPY MiAppMVC.csproj ./


# Restaurar las dependencias
RUN dotnet restore "MiAppMVC.csproj"

# Copiar todo el código fuente
COPY . .
#WORKDIR "/src/."

# Compilar el proyecto en modo Release
RUN dotnet build "MiAppMVC.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "MiAppMVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app

# Copiar el resultado de la publicación desde la etapa 'publish'
COPY --from=publish /app/publish .

# Definir el punto de entrada
ENTRYPOINT ["dotnet", "MiAppMVC.dll"]