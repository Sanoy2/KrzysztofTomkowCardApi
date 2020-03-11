# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers (restore does not works here)
COPY *.sln .
COPY src/FileAccess/*.csproj ./aspnetapp/
COPY src/WebService/*.csproj ./src/WebService/
COPY src/FileAccess/*.csproj ./src/FileAccess/
COPY tests/unit/FileAccess.Unit.Tests/*.csproj ./tests/unit/FileAccess.Unit.Tests/
COPY tests/unit/WebService.Unit.Tests/*.csproj ./tests/unit/WebService.Unit.Tests/

# RUN dotnet restore <-- does not work here

# copy everything else and build app
COPY src/. ./src/
COPY tests/. ./tests/

RUN dotnet restore

WORKDIR /source/src/WebService
RUN dotnet publish -c release -o /app --no-restore

RUN ls /app

# # final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebService.dll"]
