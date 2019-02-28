FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Vehicle.DB.Api/Vehicle.DB.Api.csproj Vehicle.DB.Api/
COPY Vehicle.DB/Vehicle.DB.csproj Vehicle.DB/
COPY Vehicle.DB.Models/Vehicle.DB.Models.csproj Vehicle.DB.Models/
RUN dotnet restore Vehicle.DB.Api/Vehicle.DB.Api.csproj
COPY . .
WORKDIR /src/Vehicle.DB.Api
RUN dotnet build Vehicle.DB.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Vehicle.DB.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicle.DB.Api.dll"]
