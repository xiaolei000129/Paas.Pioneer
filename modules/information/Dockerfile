#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9099

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Paas.Pioneer.Information.HttpApi.Host/Paas.Pioneer.Information.HttpApi.Host.csproj", "src/Paas.Pioneer.Information.HttpApi.Host/"]
COPY ["src/Paas.Pioneer.Information.Application/Paas.Pioneer.Information.Application.csproj", "src/Paas.Pioneer.Information.Application/"]
COPY ["src/Paas.Pioneer.Information.Application.Contracts/Paas.Pioneer.Information.Application.Contracts.csproj", "src/Paas.Pioneer.Information.Application.Contracts/"]
COPY ["src/Paas.Pioneer.Information.Domain.Shared/Paas.Pioneer.Information.Domain.Shared.csproj", "src/Paas.Pioneer.Information.Domain.Shared/"]
COPY ["src/Paas.Pioneer.Information.Domain/Paas.Pioneer.Information.Domain.csproj", "src/Paas.Pioneer.Information.Domain/"]
COPY ["src/Paas.Pioneer.Information.HttpApi/Paas.Pioneer.Information.HttpApi.csproj", "src/Paas.Pioneer.Information.HttpApi/"]
COPY ["src/Paas.Pioneer.Information.EntityFrameworkCore/Paas.Pioneer.Information.EntityFrameworkCore.csproj", "src/Paas.Pioneer.Information.EntityFrameworkCore/"]
RUN dotnet restore "src/Paas.Pioneer.Information.HttpApi.Host/Paas.Pioneer.Information.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Paas.Pioneer.Information.HttpApi.Host"
RUN dotnet build "Paas.Pioneer.Information.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paas.Pioneer.Information.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paas.Pioneer.Information.HttpApi.Host.dll"]