#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WordFinder.API/WordFinder.API.csproj", "WordFinder.API/"]
RUN dotnet restore "WordFinder.API/WordFinder.API.csproj"
COPY . .
WORKDIR "/src/WordFinder.API"
RUN dotnet build "WordFinder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WordFinder.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WordFinder.API.dll"]