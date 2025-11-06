# 🛒 Order Processing System

A modular, event-driven order processing microservice built with ASP.NET Core 9, EF Core, RabbitMQ and PostgreSQL — containerized with Docker Compose for seamless orchestration.

---

## 🚀 Tech Stack

### 🔹 API Layer
- **Technology:** ASP.NET Core Web API  
- **Rationale:** Enables clean separation of concerns, built-in Swagger support, and extensibility for future endpoints.

### 🔹 Domain Layer
- **Technology:** DDD-style entities and value objects  
- **Rationale:** Enforces business rules, immutability, and encapsulation at the core of the system.

### 🔹 Messaging Layer
- **Technology:** MassTransit with RabbitMQ  
- **Rationale:** Facilitates decoupled communication via durable events and supports scalable message routing.

### 🔹 Persistence Layer
- **Technology:** EF Core with PostgreSQL  
- **Rationale:** Provides relational integrity, supports value object mapping, and integrates seamlessly with .NET.

### 🔹 Worker Layer
- **Technology:** Background service hosted in a separate container  
- **Rationale:** Handles asynchronous event consumption and processing without blocking the API.

### 🔹 Orchestration Layer
- **Technology:** Docker Compose  
- **Rationale:** Enables reproducible, multi-container deployment with clear service dependencies and isolation.

---

## 🧠 Architectural Decisions & Tradeoffs

### ✅ Domain-Driven Design
- Emphasizes encapsulation and immutability using value objects (`ProductId`, `Money`)
- Constructor-based validation ensures business rules are enforced early

### ✅ Event-Driven Messaging
- RabbitMQ decouples API from processing logic
- MassTransit simplifies consumer registration and retry policies

### ✅ EF Core Mapping Strategy
- Navigation collections use backing fields to preserve domain integrity
- Value objects are mapped as owned types for clean persistence

### ✅ Containerization
- Docker Compose orchestrates API, Worker, PostgreSQL, and RabbitMQ
- Environment variables injected for portability and CI/CD compatibility

### ⚠️ Tradeoffs
- EF Core constructor binding limitations require parameterless constructors
- RabbitMQ setup assumes local dev; cloud migration may require TLS and credential hardening
- Value object mapping adds complexity to migrations and query projections

---

## 📬 API Usage

### 🔹 `POST /api/orders`

Creates a new order and publishes an `OrderPlacedEvent`.

#### ✅ Sample Request

```json
{
  "items": [
    {
      "productId": "d290f1ee-6c54-4b01-90e6-d701748f0851",
      "quantity": 2,
      "unitPrice": 100.0,
      "currency": "KES"
    }
  ]
}
