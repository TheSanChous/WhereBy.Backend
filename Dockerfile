#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WhereBy.WebApi/WhereBy.WebApi.csproj", "WhereBy.WebApi/"]
COPY ["WhereBy.Persistence/WhereBy.Persistence.csproj", "WhereBy.Persistence/"]
COPY ["WhereBy.Domain/WhereBy.Domain.csproj", "WhereBy.Domain/"]
COPY ["WhereBy.Application/WhereBy.Application.csproj", "WhereBy.Application/"]
RUN dotnet restore "WhereBy.WebApi/WhereBy.WebApi.csproj"
COPY . .
WORKDIR "/src/WhereBy.WebApi"
RUN dotnet build "WhereBy.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WhereBy.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhereBy.WebApi.dll"]