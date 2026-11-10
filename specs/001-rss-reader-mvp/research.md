# Research: Contoso RSS Reader MVP

## Decision: Use a two-project ASP.NET Core + Blazor WebAssembly MVP

The solution will be structured as an ASP.NET Core Web API backend paired with a Blazor WebAssembly frontend. This matches the stakeholder documents and keeps the app cross-platform on macOS, Windows, and Linux while remaining simple enough for the MVP.

### Rationale
- The stakeholder documents explicitly align to ASP.NET Core and Blazor WebAssembly.
- A separate API backend makes the in-memory subscription list easier to isolate and reason about.
- Blazor WebAssembly keeps the UI logic in C# and supports rapid local validation without introducing unnecessary infrastructure.

### Alternatives considered
- Single-process app with no API boundary: rejected because the stakeholder docs already describe a front-end plus back-end split, and this would blur responsibilities.
- Database-backed MVP: rejected because the constitution and stakeholder docs require in-memory storage and explicitly defer persistence.
- RSS fetching and parsing in the MVP: rejected because the specification and constitution both state those capabilities are not required and must remain out of scope.

## Decision: Keep the subscription state in memory only

The backend will maintain the current subscription list in memory for the active process lifetime. The list will reset when the backend process restarts.

### Rationale
- This matches the constitution’s in-memory requirement for the MVP.
- It keeps the implementation small and allows the team to verify the main user flow quickly.
- It avoids introducing persistence, migration, and data-access complexity before the team reaches the later phases.

### Alternatives considered
- SQLite persistence: deferred to a later phase.
- SQL Server LocalDB: explicitly excluded as not required by the project and not part of the stakeholder guidance.
- In-browser storage: rejected because the stakeholder documents describe a backend-owned in-memory list and a minimal API boundary.

## Decision: Defer feed retrieval and item parsing until Extended-MVP

The MVP does not fetch RSS or Atom content, parse feeds, or surface feed items. Those behaviors are planned only for the Extended-MVP phase.

### Rationale
- The project goals and feature spec both state the MVP is only for subscription management.
- Government and scope boundaries make feed processing out of scope for this milestone.
- Delaying parsing reduces risk, keeps the MVP fast to build, and prevents unnecessary complexity.

### Alternatives considered
- Implementing feed parser integration in the MVP: rejected because it would violate the scope definition.
- Creating a placeholder feed list model: rejected because this would make the MVP more complex without delivering user value.

## Decision: Keep URL validation intentionally minimal for the MVP

The MVP will accept a supplied URL as-is and will not enforce feed-format validation in this phase.

### Rationale
- The stakeholder docs explicitly say to assume valid URLs for the MVP.
- This reduces friction for the core user story and keeps the flow focused on subscription-management behavior.
- It also matches the constitution’s requirement that the MVP avoid unnecessary data validation and complexity.

### Alternatives considered
- URL validation and feed sniffing in the MVP: rejected because it introduces non-essential processing and error handling.
- Rejecting duplicate URLs by default: unresolved, pending a later product decision.

## Open questions to resolve later
- Should duplicate URLs be rejected, ignored, or allowed as separate entries in the same session?
- Should the UI render a simple empty state when the list is empty?
- Should the list show only the raw URL, or additional metadata such as a friendly label or timestamp?

These questions do not block the MVP, but they should be addressed before the team expands the feature toward later phases.
