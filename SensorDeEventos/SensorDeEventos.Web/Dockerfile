#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SensorDeEventos.Web/SensorDeEventos.Web.csproj", "SensorDeEventos.Web/"]
RUN dotnet restore "SensorDeEventos.Web/SensorDeEventos.Web.csproj"
COPY . .
WORKDIR "/src/SensorDeEventos.Web"
RUN dotnet build "SensorDeEventos.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SensorDeEventos.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorDeEventos.Web.dll"]