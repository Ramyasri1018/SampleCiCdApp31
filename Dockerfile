# Build stage
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY SampleCiCdApp31.sln ./
COPY WebApi/WebApi.csproj WebApi/
COPY WebApi.Tests/WebApi.Tests.csproj WebApi.Tests/
RUN dotnet restore
COPY . .
RUN dotnet publish WebApi/WebApi.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "WebApi.dll"]