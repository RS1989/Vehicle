FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ../Vehicle.Ping/Vehicle.Ping.csproj ../Vehicle.Ping/
COPY Vehicle.DB.Models/Vehicle.Models.csproj Vehicle.DB.Models/
RUN dotnet restore ../Vehicle.Ping/Vehicle.Ping.csproj
COPY . .
WORKDIR /src/../Vehicle.Ping
RUN dotnet build Vehicle.Ping.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Vehicle.Ping.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicle.Ping.dll"]
