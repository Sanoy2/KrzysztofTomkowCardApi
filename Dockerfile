# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
# COPY src/FileAccess/*.csproj ./aspnetapp/
COPY src/WebService/*.csproj ./src/WebService/
COPY src/FileAccess/*.csproj ./src/FileAccess/
COPY tests/unit/FileAccess.Unit.Tests/*.csproj ./tests/unit/FileAccess.Unit.Tests/
COPY tests/unit/WebService.Unit.Tests/*.csproj ./tests/unit/WebService.Unit.Tests/


RUN dotnet restore

# # copy everything else and build app
# # COPY src/. ./aspnetapp/
# WORKDIR /source/aspnetapp
# RUN dotnet publish -c release -o /app --no-restore

# # final stage/image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build /app ./
# ENTRYPOINT ["dotnet", "aspnetapp.dll"]
