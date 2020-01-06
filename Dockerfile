FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Cloud-System-dev-ops/ThAmCo-ReSale.csproj", "Cloud-System-dev-ops/"]
RUN dotnet restore "Cloud-System-dev-ops/ThAmCo-ReSale.csproj"
COPY . .
WORKDIR "/src/Cloud-System-dev-ops"
RUN dotnet build "ThAmCo-ReSale.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ThAmCo-ReSale.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ThAmCo-ReSale.dll"]