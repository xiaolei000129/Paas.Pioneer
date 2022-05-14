#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9300

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Paas.Pioneer.Admin.Core.HttpApi.Host/Paas.Pioneer.Admin.Core.HttpApi.Host.csproj", "src/Paas.Pioneer.Admin.Core.HttpApi.Host/"]
COPY ["src/Paas.Pioneer.Admin.Core.Application/Paas.Pioneer.Admin.Core.Application.csproj", "src/Paas.Pioneer.Admin.Core.Application/"]
COPY ["src/Paas.Pioneer.Admin.Core.Application.Contracts/Paas.Pioneer.Admin.Core.Application.Contracts.csproj", "src/Paas.Pioneer.Admin.Core.Application.Contracts/"]
COPY ["src/Paas.Pioneer.Admin.Core.Domain.Shared/Paas.Pioneer.Admin.Core.Domain.Shared.csproj", "src/Paas.Pioneer.Admin.Core.Domain.Shared/"]
COPY ["src/Paas.Pioneer.Admin.Core.Domain/Paas.Pioneer.Admin.Core.Domain.csproj", "src/Paas.Pioneer.Admin.Core.Domain/"]
COPY ["src/Paas.Pioneer.Admin.Core.HttpApi/Paas.Pioneer.Admin.Core.HttpApi.csproj", "src/Paas.Pioneer.Admin.Core.HttpApi/"]
COPY ["src/Paas.Pioneer.Admin.Core.EntityFrameworkCore/Paas.Pioneer.Admin.Core.EntityFrameworkCore.csproj", "src/Paas.Pioneer.Admin.Core.EntityFrameworkCore/"]
RUN dotnet restore "src/Paas.Pioneer.Admin.Core.HttpApi.Host/Paas.Pioneer.Admin.Core.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Paas.Pioneer.Admin.Core.HttpApi.Host"
RUN dotnet build "Paas.Pioneer.Admin.Core.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paas.Pioneer.Admin.Core.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paas.Pioneer.Admin.Core.HttpApi.Host.dll"]