# Implementation Plan: Contoso RSS Reader MVP

**Branch**: `001-rss-reader-mvp` | **Date**: 2026-11-09 | **Spec**: [specs/001-rss-reader-mvp/spec.md](../spec.md)

**Input**: Feature specification from `/specs/001-rss-reader-mvp/spec.md`

## Summary

Build the MVP for a single-user RSS reader that accepts feed URLs, stores the subscriptions only in memory, and updates the visible subscription list immediately. The implementation will use an ASP.NET Core Web API backend and a Blazor WebAssembly frontend, both running on .NET 10 for this local macOS walkthrough. Feed fetching, parsing, persistence, sorting, and read/unread tracking remain explicitly deferred to Extended-MVP and post-MVP phases.

## Technical Context

**Language/Version**: C# on .NET 10

**Primary Dependencies**: ASP.NET Core Web API, Blazor WebAssembly, xUnit for automated tests

**Storage**: In-memory application state in the backend. No SQL Server LocalDB, SQLite, database migration, or external persistence for this MVP.

**Testing**: dotnet test with xUnit for backend and UI contract smoke checks; browser smoke validation for list update behavior

**Target Platform**: Local development on macOS, with cross-platform compatibility for Windows and Linux

**Project Type**: Web application

**Performance Goals**: Immediate local UI updates for a small in-memory list; p95 for add-subscription flow should remain within a few hundred milliseconds in local development environments

**Constraints**: No RSS parsing, no feed fetching, no persistence, no polling, no sorting, no unread tracking, and no network dependency beyond local API communication

**Scale/Scope**: Single user, small local session state, minimal UI and API surface, low volume and low complexity

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

The plan passes the current constitution because it stays within the approved MVP scope and retains the required phase boundaries:
- MVP Scope Discipline: satisfied; the feature is limited to adding URLs and showing the subscription list.
- Cross-Platform Delivery: satisfied; the architecture and commands remain compatible with macOS, Windows, and Linux.
- Incremental Phase Gates: satisfied; feed parsing, persistence, and advanced behaviors remain deferred.
- Minimal Data and State Boundaries: satisfied; the plan uses in-memory storage only and avoids introducing non-MVP obligations.
- Explicit Future Feature Separation: satisfied; SQLite persistence and RSS parsing are documented as future work and are not included in this phase.

No constitution violation is identified for this plan.

## Project Structure

### Documentation (this feature)

```text
specs/001-rss-reader-mvp/
├── plan.md              # This file
├── research.md          # Phase 0 output
├── data-model.md        # Phase 1 output
├── quickstart.md        # Phase 1 output
├── contracts/           # Phase 1 output
├── spec.md              # Feature spec
├── checklists/
│   └── requirements.md
└── tasks.md             # Phase 2 output, not created in this step
```

### Source Code (repository root)

```text
backend/
├── ContosoRssReader.Api/
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   ├── Program.cs
│   └── Properties/
├── ContosoRssReader.Api.Tests/
│   └── Unit/
├── ContosoRssReader.sln
└── Directory.Build.props

frontend/
├── ContosoRssReader.UI/
│   ├── Components/
│   ├── Pages/
│   ├── Services/
│   ├── wwwroot/
│   ├── Program.cs
│   └── App.razor
├── ContosoRssReader.UI.Tests/
│   └── Smoke/
└── .env.example
```

**Structure Decision**: Use a two-project web application structure with a dedicated ASP.NET Core Web API backend and a Blazor WebAssembly frontend. The backend owns the in-memory subscription state; the frontend owns the user input and subscription list rendering. No database project is included for the MVP.

## Complexity Tracking

> **No gate violations require justification for this plan.**

## Conflict Review

No direct conflict was identified with the stakeholder documents. The stakeholder requirements already call for an ASP.NET Core Web API backend and Blazor WebAssembly frontend, a cross-platform local development path, and an MVP limited to subscription management with in-memory storage. The only caution is to preserve those boundaries and explicitly defer feed parsing, persistence, and related capabilities until the later phases defined by the project documents.
