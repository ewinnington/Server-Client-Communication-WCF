#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Server-Client-Communication-WCF.csproj", "."]
RUN dotnet restore "./Server-Client-Communication-WCF.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Server-Client-Communication-WCF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server-Client-Communication-WCF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server-Client-Communication-WCF.dll"]

EXPOSE 8089