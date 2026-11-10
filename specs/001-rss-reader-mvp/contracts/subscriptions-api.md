# Subscription API Contract

## Overview

The backend exposes the minimal API surface required for the MVP: adding a subscription and retrieving the current list. This contract intentionally excludes parsing, persistence, and item display.

## Endpoints

### GET /api/subscriptions

Returns the current in-memory list of subscriptions.

**Response**

```json
{
  "subscriptions": [
    {
      "id": "8d5f2d4f-1c84-4e5f-9f3e-bd14a00e8d9b",
      "url": "https://example.com/feed.xml",
      "createdAt": "2026-11-09T12:00:00Z"
    }
  ]
}
```

**Status codes**
- 200 OK

### POST /api/subscriptions

Adds a feed URL to the in-memory list.

**Request body**

```json
{
  "url": "https://example.com/feed.xml"
}
```

**Response**

```json
{
  "subscription": {
    "id": "8d5f2d4f-1c84-4e5f-9f3e-bd14a00e8d9b",
    "url": "https://example.com/feed.xml",
    "createdAt": "2026-11-09T12:00:00Z"
  }
}
```

**Status codes**
- 201 Created
- 400 Bad Request when the URL is empty or whitespace

## Scope boundaries

The following are intentionally outside this contract:
- feed retrieval and parsing
- item listing endpoints
- pagination and sorting
- persistence and database contracts
- SQLite, LocalDB, or any external storage contract
- background polling or scheduled refresh

## Notes

This API contract is intentionally minimal and matches the MVP requirement to manage a subscription list only. Future phases add additional contracts when the Extended-MVP and post-MVP capabilities are approved.
