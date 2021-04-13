#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OconnorEvents.ShoppingBasket/OconnorEvents.ShoppingBasket.csproj", "OconnorEvents.ShoppingBasket/"]
RUN dotnet restore "OconnorEvents.ShoppingBasket/OconnorEvents.ShoppingBasket.csproj"
COPY . .
WORKDIR "/src/OconnorEvents.ShoppingBasket"
RUN dotnet build "OconnorEvents.ShoppingBasket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OconnorEvents.ShoppingBasket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OconnorEvents.ShoppingBasket.dll"]