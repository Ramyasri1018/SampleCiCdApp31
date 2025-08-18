# Sample CI/CD App (.NET Core 3.1 + SQLite + HTML UI)

**Why 3.1?** Your system shows .NET Core 3.1 SDK installed (VS2019).
This sample avoids any new installations.

## Features
- ASP.NET Core **3.1** Web API
- EF Core **3.1** + SQLite (`app.db` auto-created & seeded)
- Static HTML UI at `/` calling `/api/items`
- xUnit test using `WebApplicationFactory<Startup>`
- GitHub Actions CI (build/test/publish) pinned to `3.1.x`
- Dockerfile (3.1 SDK/runtime)

## Run locally (VS2019 or CLI)
1. Unzip the folder.
2. Open `SampleCiCdApp31.sln` in Visual Studio 2019 (16.11+ recommended) **or** use CLI:
   ```powershell
   dotnet restore
   dotnet build
   dotnet run --project WebApi/WebApi.csproj
   ```
3. Browse:
   - UI: `http://localhost:5000`
   - Swagger: `http://localhost:5000/swagger`
   - API: `http://localhost:5000/api/items`

> If ports differ when using IIS Express, check `Properties/launchSettings.json`.

## CI/CD (GitHub Actions)
- Push this folder as a repo with default branch `main`.
- Workflow at `.github/workflows/dotnet31.yml`:
  - Restores, builds, tests
  - Publishes app and uploads artifact
  - Builds Docker image (3.1)

## Notes
- This project is intentionally simple to focus on CI/CD.
- .NET Core 3.1 is EOL; for production, upgrade to .NET 8 when possible.