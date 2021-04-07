#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OconnorEvents.EventCatalog/OconnorEvents.EventCatalog.csproj", "OconnorEvents.EventCatalog/"]
RUN dotnet restore "OconnorEvents.EventCatalog/OconnorEvents.EventCatalog.csproj"
COPY . .
WORKDIR "/src/OconnorEvents.EventCatalog"
RUN dotnet build "OconnorEvents.EventCatalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OconnorEvents.EventCatalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OconnorEvents.EventCatalog.dll"]