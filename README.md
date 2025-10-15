# Error Tracker Demo API

RESTful API that centralizes the logging, storage, and monitoring of errors across multiple applications.  
Designed to serve as a foundation for a **lightweight observability service** with **customizable alerts**.

---

## Table of Contents

1. [Introduction](#introduction)
2. [Overall Architecture](#overall-architecture)
3. [Main Endpoints](#main-endpoints)
4. [Data Flow](#data-flow)
5. [Project Setup](#project-setup)
6. [Usage Examples](#usage-examples)
7. [Future Roadmap](#future-roadmap)
8. [License](#license)

---

## Introduction

**Error Tracker Demo API** is an educational tool inspired by services like *Sentry* or *Rollbar*, simplified for backend developers who want to understand the architecture behind error capturing and monitoring systems.

---

## Overall Architecture

```
        ┌────────────┐
        │ Client App │
        └─────┬──────┘
              │ POST /api/errors/new
              ▼
        ┌────────────┐
        │ Error API  │
        │ (C#/.NET 8)│
        └─────┬──────┘
              │ EF Core
              ▼
        ┌────────────┐
        │   DB Log   │
        └────────────┘
```

---

## Main Endpoints

| Method | Route | Description | Authentication |
|--------|-------|-------------|----------------|
| POST   | `/api/errors/new` | Register a new error | API Key |
| GET    | `/api/errors`     | List errors | API Key |
| GET    | `/api/errors/{id}`| Error details | API Key |
| GET    | `/api/status`     | Service status | Public |

---

## Project Setup

### 1️. Clone and prepare environment
```bash
git clone https://github.com/wilycabe/Error-Tracker-Demo-API.git
cd error-tracker-demo
dotnet restore
```

### 2️. Environment variables
```
```

### 3️. Run the project
```bash
dotnet run
```

---

## Usage Example (Postman or curl)
```http
POST /api/errors/new
Header: x-api-key: demo-key-123
Body:
{
  "appName": "PaymentService",
  "errorMessage": "TimeoutException processing order 553",
  "stackTrace": "...",
  "severity": "High"
}
```

---

## Future Roadmap

- [ ] Web dashboard with filters and metrics  
- [ ] WebSocket for real-time alerts  
- [ ] Integration with third-party services (Slack, Telegram)  

---

## License

Distributed under the **MIT License**.  
Developed with ❤️ by Wellington Cabezas.