#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProductAPI2/ProductAPI2.csproj", "ProductAPI2/"]
COPY ["D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj", "D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/IntegrationEventLogEF/"]
COPY ["D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBus/EventBus.csproj", "D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBus/"]
COPY ["D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "D:/eshop containers/eShopOnContainers-dev/src/BuildingBlocks/EventBus/EventBusRabbitMQ/"]
RUN dotnet restore "ProductAPI2/ProductAPI2.csproj"
COPY . .
WORKDIR "/src/ProductAPI2"
RUN dotnet build "ProductAPI2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductAPI2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductAPI2.dll"]
