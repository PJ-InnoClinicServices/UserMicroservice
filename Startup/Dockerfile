FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Startup/Startup.csproj", "Startup/"]
COPY ["Doctors.Infrastructure/Doctors.Infrastructure.csproj", "Doctors.Infrastructure/"]
COPY ["Common.Domain/Common.Domain.csproj", "Common.Domain/"]
COPY ["Doctors.Application/Doctors.Application.csproj", "Doctors.Application/"]
COPY ["Common.Application/Common.Application.csproj", "Common.Application/"]
COPY ["Doctors.Domain/Doctors.Domain.csproj", "Doctors.Domain/"]
COPY ["Doctors.Shared/Doctors.Shared.csproj", "Doctors.Shared/"]
COPY ["Doctors.WebAPI/Doctors.WebAPI.csproj", "Doctors.WebAPI/"]
RUN dotnet restore "Startup/Startup.csproj"
COPY . .
WORKDIR "/src/Startup"
RUN dotnet build "Startup.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Startup.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Startup.dll"]
