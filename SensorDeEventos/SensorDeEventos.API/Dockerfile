#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SensorDeEventos.API/SensorDeEventos.API.csproj", "SensorDeEventos.API/"]
COPY ["src/SensorDeEventos.Historias/SensorDeEventos.Historias.csproj", "src/SensorDeEventos.Historias/"]
COPY ["src/SensorDeEventos.Models/SensorDeEventos.Domain.csproj", "src/SensorDeEventos.Models/"]
COPY ["src/SensorDeEventos.Data/SensorDeEventos.Data.csproj", "src/SensorDeEventos.Data/"]
RUN dotnet restore "SensorDeEventos.API/SensorDeEventos.API.csproj"
COPY . .
WORKDIR "/src/SensorDeEventos.API"
RUN dotnet build "SensorDeEventos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SensorDeEventos.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorDeEventos.API.dll"]
