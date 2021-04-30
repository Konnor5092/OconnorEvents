#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OconnorEvents.Ordering/OconnorEvents.Ordering.csproj", "OconnorEvents.Ordering/"]
RUN dotnet restore "OconnorEvents.Ordering/OconnorEvents.Ordering.csproj"
COPY . .
WORKDIR "/src/OconnorEvents.Ordering"
RUN dotnet build "OconnorEvents.Ordering.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OconnorEvents.Ordering.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OconnorEvents.Ordering.dll"]