FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SGPI.Application/SGPI.Application.csproj", "src/SGPI.Application/"]
RUN dotnet restore "src/SGPI.Application/SGPI.Application.csproj"
COPY . .
WORKDIR "/src/src/SGPI.Application"
RUN dotnet build "SGPI.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SGPI.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGPI.Application.dll"]
