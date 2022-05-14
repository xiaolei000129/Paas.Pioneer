#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9202

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Paas.Pioneer.Hangfire.HttpApi.Host/Paas.Pioneer.Hangfire.HttpApi.Host.csproj", "src/Paas.Pioneer.Hangfire.HttpApi.Host/"]
COPY ["src/Paas.Pioneer.Hangfire.Application/Paas.Pioneer.Hangfire.Application.csproj", "src/Paas.Pioneer.Hangfire.Application/"]
COPY ["src/Paas.Pioneer.Hangfire.Domain/Paas.Pioneer.Hangfire.Domain.csproj", "src/Paas.Pioneer.Hangfire.Domain/"]
COPY ["src/Paas.Pioneer.Hangfire.Domain.Shared/Paas.Pioneer.Hangfire.Domain.Shared.csproj", "src/Paas.Pioneer.Hangfire.Domain.Shared/"]
COPY ["src/Paas.Pioneer.Hangfire.Application.Contracts/Paas.Pioneer.Hangfire.Application.Contracts.csproj", "src/Paas.Pioneer.Hangfire.Application.Contracts/"]
COPY ["src/Paas.Pioneer.Hangfire.HttpApi/Paas.Pioneer.Hangfire.HttpApi.csproj", "src/Paas.Pioneer.Hangfire.HttpApi/"]
COPY ["src/Paas.Pioneer.Hangfire.EntityFrameworkCore/Paas.Pioneer.Hangfire.EntityFrameworkCore.csproj", "src/Paas.Pioneer.Hangfire.EntityFrameworkCore/"]
RUN dotnet restore "src/Paas.Pioneer.Hangfire.HttpApi.Host/Paas.Pioneer.Hangfire.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Paas.Pioneer.Hangfire.HttpApi.Host"
RUN dotnet build "Paas.Pioneer.Hangfire.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paas.Pioneer.Hangfire.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paas.Pioneer.Hangfire.HttpApi.Host.dll"]