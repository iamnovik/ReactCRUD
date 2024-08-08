# Используем базовый образ для .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Используем базовый образ для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install Node.js
RUN apt-get update && \
    apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_16.x | bash - && \
    apt-get install -y nodejs

WORKDIR /src
COPY ["BookStore.API/BookStore.API.csproj", "BookStore.API/"]
COPY ["BookStore.BLL/BookStore.BLL.csproj", "BookStore.BLL/"]
COPY ["BookStore.DAL/BookStore.DAL.csproj", "BookStore.DAL/"]
RUN dotnet restore "BookStore.API/BookStore.API.csproj"
COPY . .
WORKDIR "/src/BookStore.API"
RUN dotnet build "BookStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Выполняем публикацию
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BookStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.API.dll"]
