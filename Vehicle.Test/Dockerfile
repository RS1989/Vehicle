FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ../Vehicle.Test/Vehicle.Test.csproj ../Vehicle.Test/
COPY ../Gatewau.Web.Api/Gateway.Web.Api.csproj ../Gatewau.Web.Api/
COPY Vehicle.DB.Models/Vehicle.Models.csproj Vehicle.DB.Models/
COPY Vehicle.DB.Api/Vehicle.DB.Api.csproj Vehicle.DB.Api/
COPY Vehicle.DB/Vehicle.DB.csproj Vehicle.DB/
COPY ../Vehicle.Ping/Vehicle.Ping.csproj ../Vehicle.Ping/
RUN dotnet restore ../Vehicle.Test/Vehicle.Test.csproj
COPY . .
WORKDIR /src/../Vehicle.Test
RUN dotnet build Vehicle.Test.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Vehicle.Test.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicle.Test.dll"]
