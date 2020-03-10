#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MyBank.Web/MyBank.Web.csproj", "MyBank.Web/"]
COPY ["MyBank.Application.Services/MyBank.Application.Services.csproj", "MyBank.Application.Services/"]
COPY ["MyBank.Domain/MyBank.Domain.csproj", "MyBank.Domain/"]
COPY ["MyBank.Infra.Helpers/MyBank.Infra.Helpers.csproj", "MyBank.Infra.Helpers/"]
COPY ["MyBank.Application.Dtos/MyBank.Application.Dtos.csproj", "MyBank.Application.Dtos/"]
COPY ["MyBank.Infra.Data/MyBank.Infra.Data.csproj", "MyBank.Infra.Data/"]
COPY ["MyBank.Infra.IoC/MyBank.Infra.IoC.csproj", "MyBank.Infra.IoC/"]
RUN dotnet restore "MyBank.Web/MyBank.Web.csproj"
COPY . .
WORKDIR "/src/MyBank.Web"
RUN dotnet build "MyBank.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBank.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBank.Web.dll"]