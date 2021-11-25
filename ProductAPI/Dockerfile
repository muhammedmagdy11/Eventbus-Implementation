#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProductAPI/ProductAPI.csproj", "ProductAPI/"]
COPY ["D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj", "D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/IntegrationEventLogEF/"]
COPY ["D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBus/EventBus.csproj", "D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBus/"]
COPY ["D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBusRabbitMQ/"]
COPY ["D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBusServiceBus/EventBusServiceBus.csproj", "D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBusServiceBus/"]
RUN dotnet restore "ProductAPI/ProductAPI.csproj"
COPY . .
WORKDIR "/src/ProductAPI"
RUN dotnet build "ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductAPI.dll"]
