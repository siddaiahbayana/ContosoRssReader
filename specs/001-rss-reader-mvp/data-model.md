# Data Model: Contoso RSS Reader MVP

## Overview

The MVP stores only the subscription list in memory. The design keeps the model intentionally small so the app can prove the core value quickly without introducing persistence or feed processing.

## Entities

### Subscription

Represents a single feed subscription that a user adds to the current working session.

| Field | Type | Description | Validation |
|-------|------|-------------|------------|
| id | string | Stable identifier for the subscription entry | Required for list operations |
| url | string | Feed URL supplied by the user | Must be non-empty after trimming |
| createdAt | datetime | When the subscription was added | Set automatically |

### SubscriptionList

Represents the current set of subscriptions in memory for the active backend session.

| Field | Type | Description | Validation |
|-------|------|-------------|------------|
| items | Subscription[] | Current list of subscriptions | Must be initialized to an empty collection |

## Relationships

- A SubscriptionList contains zero or more Subscription entries.
- The backend owns one in-memory SubscriptionList instance for the active process.
- The frontend does not maintain a separate authoritative list; it mirrors the backend response.

## State lifetime

- The list exists for the lifetime of the backend process.
- The list is reset when the application restarts or the process exits.
- There is no persistence across sessions.

## Validation rules

- URLs must be non-empty after trimming.
- The MVP treats the input as a valid feed URL without additional feed-format validation.
- Duplicate handling remains a product decision and is intentionally left unresolved until a later phase.

## Deferred entities and behaviors

These are intentionally excluded from the MVP data model:
- Feed item records
- Read/unread state
- Folder or category objects
- Polling schedules
- Persisted profile or preference state
- Feed metadata beyond the raw URL in the current session
