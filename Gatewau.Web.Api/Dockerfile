FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["../Gateway.Web.Api/Gateway.Web.Api.csproj", "../Gateway.Web.Api/"]
RUN dotnet restore "../Gateway.Web.Api/Gateway.Web.Api.csproj"
COPY . .
WORKDIR "/src/../Gateway.Web.Api"
RUN dotnet build "Gateway.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Gateway.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gateway.Web.Api.dll"]
