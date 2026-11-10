# Quickstart: Contoso RSS Reader MVP

## Goal

Validate the MVP locally by creating a backend and frontend, running them together, and confirming that a user can add a subscription and see it appear in the list without any RSS parsing or persistence.

## Prerequisites

- .NET 10 SDK installed
- macOS, Windows, or Linux workstation
- Internet access only for optional external feed testing in later phases

## Local build and run sequence

```bash
# Confirm the SDK version
 dotnet --version

# Create a solution
 dotnet new sln -n ContosoRssReader

# Create the backend API project
 dotnet new webapi -n ContosoRssReader.Api -o backend/ContosoRssReader.Api --framework net10.0

# Create the frontend Blazor WebAssembly project
 dotnet new blazorwasm -n ContosoRssReader.UI -o frontend/ContosoRssReader.UI --framework net10.0

# Add both projects to the solution
 dotnet sln ContosoRssReader.sln add backend/ContosoRssReader.Api/ContosoRssReader.Api.csproj frontend/ContosoRssReader.UI/ContosoRssReader.UI.csproj

# Restore and build
 dotnet restore ContosoRssReader.sln
 dotnet build ContosoRssReader.sln
```

## Run the app locally

Start the backend first, then the frontend:

```bash
# Terminal 1 - backend API
 dotnet run --project backend/ContosoRssReader.Api/ContosoRssReader.Api.csproj

# Terminal 2 - frontend UI
 dotnet run --project frontend/ContosoRssReader.UI/ContosoRssReader.UI.csproj
```

Expected local endpoints:
- Backend API: http://localhost:5151
- Frontend app: http://localhost:5213

## Validation scenarios

1. Open the frontend in the browser.
2. Enter a sample feed URL such as `https://example.com/feed.xml`.
3. Submit the form.
4. Verify that the list updates immediately with the new entry.
5. Refresh the page or restart the backend to confirm the in-memory list resets, as expected for the MVP.

## Explicitly deferred validation

These items are not part of the MVP validation flow and should not be introduced here:
- feed fetching and parsing
- persistence across restarts
- SQLite setup
- read/unread tracking
- background pollers
- RSS item rendering
