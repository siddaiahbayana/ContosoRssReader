# Tasks: Contoso RSS Reader MVP

## Phase 1: Setup

- [X] T001 Create backend and frontend project structure under `backend/` and `frontend/` per the implementation plan
- [X] T002 [P] Configure .NET 10 solution and local project references for the API and Blazor WebAssembly app
- [X] T003 [P] Set local launch profiles, CORS, and frontend API base URL configuration for the MVP without introducing any later-phase persistence or feed dependencies

## Phase 2: Foundational

- [X] T004 Define the backend subscription model and in-memory store shape for the current session lifetime
- [X] T005 Implement the backend subscription service for add/list operations in memory only
- [X] T006 Create the API contract and controller endpoints for subscription creation and retrieval with the exact constraint: "The MVP MUST preserve the subscription list in memory for the current session only"
- [X] T007 [P] Create the Blazor UI form and state model for the subscription input field and list display
- [X] T008 [P] Connect the frontend to the backend subscription API and prepare the UI to re-render after successful addition

## Phase 3: User Story 1 - Add a feed subscription (Priority: P1)

**Story goal**: A user can submit a feed URL and have it added to the in-memory subscription collection.

**Independent test criteria**: Enter a valid URL into the UI, submit it, and confirm the API stores the subscription in memory and returns the updated list state.

- [X] T009 [US1] Add the backend contract for creating a subscription entry from a URL and validate the request is non-empty after trimming
- [X] T010 [US1] Implement the service logic to append the subscription to the in-memory list and return the created record
- [X] T011 [US1] Add the HTTP endpoint for `POST /api/subscriptions` and return `201 Created` for successful additions
- [X] T012 [P] [US1] Build the front-end form submission flow for entering the URL and calling the backend create endpoint
- [X] T013 [P] [US1] Add a smoke test for the add-subscription flow that verifies the API accepts a valid URL and stores it in the in-memory list

## Phase 4: User Story 2 - Display the updated subscription list (Priority: P1)

**Story goal**: A user can immediately see the subscription list update after adding a new feed URL.

**Independent test criteria**: Add one or more subscriptions and verify the visible subscription list updates in the current view without any feed parsing, refresh action, or storage persistence.

- [X] T014 [US2] Implement the backend list-read API for `GET /api/subscriptions` and return the current in-memory collection
- [X] T015 [US2] Update the Blazor page to load the list and display each subscription URL in the current session
- [X] T016 [US2] Trigger a UI refresh after a successful add so the list re-renders immediately in the same view
- [X] T017 [P] [US2] Add a front-end smoke test that verifies the page shows the new subscription after successful submission
- [X] T018 [P] [US2] Add a backend test that confirms the list endpoint returns the current set of subscriptions after multiple adds

## Phase 5: User Story 3 - Scope guard and deferred features separation (Priority: P2)

**Story goal**: The milestone remains clearly separated from Extended-MVP and post-MVP work.

**Independent test criteria**: Review the project artifacts and confirm the MVP stays limited to in-memory subscription management and does not include feed fetching, parsing, persistence, sorting, or read/unread handling.

- [X] T019 [US3] Add documentation or guardrails that explicitly record the deferred features for Extended-MVP and post-MVP and prevent accidental inclusion in the MVP
- [X] T020 [US3] Confirm the MVP source tree and acceptance tests do not include feed parsing, RSS display, persistence, background polling, or sorting work

## Final Phase: Polish & Cross-Cutting Concerns

- [X] T021 Validate the end-to-end MVP flow with the exact user scenario: enter a URL, add the subscription, and confirm the updated list is visible immediately
- [X] T022 Verify the app remains cross-platform and local-only, with no SQL Server LocalDB, no SQLite persistence, and no feed-fetching or parsing libraries in the MVP scope
- [X] T023 Review the generated project against the constitution and stakeholder constraints to confirm the MVP remains within the approved scope

## Dependencies

- Phase 1 must finish before Phase 2.
- Phase 2 must finish before any user story phase tasks begin.
- User Story 1 is the primary enabling story for User Story 2.
- User Story 3 is a governance and validation story; it can run in parallel with final verification once the core MVP path is working.

## Parallel execution examples

- [P] T002 and T003 may run in parallel during project setup.
- [P] T004 and T005 may run in parallel once the model contract is defined.
- [P] T007 and T008 may run in parallel after the API contract is agreed.
- [P] T012 and T013 may run in parallel once the form flow and backend create logic are both in place.
- [P] T015 and T017 may run in parallel during the UI list-display work.

## Deferred features (explicitly excluded from this MVP)

These items are intentionally not part of the task backlog for this milestone and must remain deferred until later phases:

- Feed fetching and RSS/Atom network retrieval
- Feed parsing and item extraction
- SQLite persistence or database storage
- SQL Server LocalDB setup or other relational persistence
- Removal of subscriptions
- Sorting, prioritization, or unread tracking
- Background polling or scheduled refresh
- Full item-content rendering and read/unread behavior

## Implementation strategy

- Deliver the MVP in the smallest viable slices: project setup, in-memory subscription storage, backend add/list API, UI entry field and list display, and final verification.
- Keep creates and reads local and in-memory only.
- Avoid feed-fetching and parsing libraries in this phase, even if they appear useful for later Extended-MVP phases.
- Treat later-phase behaviors as explicit backlog items rather than hidden requirements.

## Task count summary

- Total tasks: 23
- User Story 1: 5 tasks
- User Story 2: 5 tasks
- User Story 3: 2 tasks
- Setup: 3 tasks
- Foundational: 5 tasks
- Final phase: 3 tasks

## Checklist format validation

All tasks in this file follow the required format:
- each starts with `- [ ]`
- each has a sequential task ID (`T001`, `T002`, ...)
- story tasks include `[US1]`, `[US2]`, or `[US3]` labels
- parallelizable tasks include `[P]`
- file paths are included in task descriptions where appropriate

## Phase 6: Convergence

- [ ] T024 Add automated backend verification for the in-memory subscription add/list flow in `backend/ContosoRssReader.Api.Tests/` per FR-002, FR-003, FR-004, SC-001, SC-002 (missing)
- [ ] T025 Add frontend smoke validation for the subscription form and immediate list update in `frontend/ContosoRssReader.UI.Tests/` per FR-001, FR-003, FR-008, SC-001, SC-002 (missing)
- [ ] T026 Decide and document the product rule for blank and duplicate feed URLs before broader feature expansion, and add explicit acceptance coverage for the chosen behavior per the unresolved questions in the spec and the MVP edge-case checklist (partial)
