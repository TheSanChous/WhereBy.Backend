#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WhereBuy.WebApi/WhereBuy.WebApi.csproj", "WhereBuy.WebApi/"]
COPY ["WhereBuy.Application/WhereBuy.Application.csproj", "WhereBuy.Application/"]
COPY ["WhereBuy.Domain/WhereBuy.Domain.csproj", "WhereBuy.Domain/"]
COPY ["WhereBuy.Abstractions/WhereBuy.Common.csproj", "WhereBuy.Abstractions/"]
COPY ["WhereBuy.Persistence/WhereBuy.Persistence.csproj", "WhereBuy.Persistence/"]
COPY ["WhereBuy.Auth/WhereBuy.Auth.csproj", "WhereBuy.Auth/"]
RUN dotnet restore "WhereBuy.WebApi/WhereBuy.WebApi.csproj"
COPY . .
WORKDIR "/src/WhereBuy.WebApi"
RUN dotnet build "WhereBuy.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WhereBuy.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhereBuy.WebApi.dll"]