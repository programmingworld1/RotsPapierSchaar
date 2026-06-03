FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY RotsPapierSchaar.slnx .
COPY RotsPapierSchaar.Api/RotsPapierSchaar.Api.csproj RotsPapierSchaar.Api/
COPY RotsPapierSchaar.Application/RotsPapierSchaar.Application.csproj RotsPapierSchaar.Application/
COPY RotsPapierSchaar.Domain/RotsPapierSchaar.Domain.csproj RotsPapierSchaar.Domain/
COPY RotsPapierSchaar.Contracts/RotsPapierSchaar.Contracts.csproj RotsPapierSchaar.Contracts/
COPY RotsPapierSchaar.Infrastructure/RotsPapierSchaar.Infrastructure.csproj RotsPapierSchaar.Infrastructure/

RUN dotnet restore RotsPapierSchaar.slnx

COPY . .

RUN dotnet publish RotsPapierSchaar.Api/RotsPapierSchaar.Api.csproj -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RotsPapierSchaar.Api.dll"]
