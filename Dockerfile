FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ManualMigrations_EF.csproj", "./"]
RUN dotnet restore "ManualMigrations_EF.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ManualMigrations_EF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManualMigrations_EF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManualMigrations_EF.dll"]
