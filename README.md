# 🛒 Order Processing Microservice

A modular, event-driven order processing microservice built with ASP.NET Core 10, EF Core, RabbitMQ and PostgreSQL — containerized with Docker for seamless orchestration.

---

## Table of Contents
- [Introduction to the Microservice](#Order-Processing-Microservice)
- [Table of Contents](#Table-of-Contents)
- [✨ Features](#Features)
- [🏛 Architecture](#Architecture)
  - [🧠 Architectural Decisions](#Architectural-Decisions)
  - [⚠️ Tradeoffs](#Tradeoffs)
- [🚀 Tech Stack](#Tech-Stack)
- [⚙️ Setup Instructions](#Setup-Instructions)
- [📬 API Usage](#API-Usage)
- [🧪 End-to-End Flow](#End-to-End-Flow)
- [📊 Observability (Optional)](#Observability-(Optional))

---

## ✨ Features

1. **Order Management**: Order Creation, Persistence, Computed Values.
2. **Clean Architecture**: Separation of concerns, Event-driven architecture, Domain-driven design.
3. **Infrastructure & Orchestration**: Docker, Automatic Migrations, Environment Variables.
4. **Observability**: RabbitMQ Management UI, Container-level Database Inspection and Logs.
5. **Resilience**: Retry policies and Circuit breakers. 

---

## 🏛 Architecture

<img width="1536" height="1024" alt="ChatGPT Image Nov 6, 2025, 05_04_33 PM" src="https://github.com/user-attachments/assets/d106deff-3f67-4bad-aa2f-4c0a147f9956" />

### 🧠 Architectural Decisions 

1. **Domain-Driven Design**
   - Emphasizes encapsulation and immutability using value objects (`ProductId`, `Money`)
   - Constructor-based validation ensures business rules are enforced early
2. **Event-Driven Messaging**
   - RabbitMQ decouples API from processing logic
   - MassTransit simplifies consumer registration and retry policies
3. **EF Core Mapping Strategy**
   - Navigation collections use backing fields to preserve domain integrity
   - Value objects are mapped as owned types for clean persistence
4. **Containerization**
   - Docker Compose orchestrates API, Worker, PostgreSQL, and RabbitMQ
   - Environment variables injected for portability and CI/CD compatibility
     
### ⚠️ Tradeoffs
- EF Core constructor binding limitations require parameterless constructors
- RabbitMQ setup assumes local dev; cloud migration may require TLS and credential hardening
- Value object mapping adds complexity to migrations and query projections

---

## 🚀 Tech Stack

1. **API Layer**
   - **Technology:** ASP.NET Core Web API  
   - **Rationale:** Enables clean separation of concerns, built-in Swagger support, and extensibility for future endpoints.
2. **Domain Layer**
   - **Technology:** DDD-style entities and value objects  
   - **Rationale:** Enforces business rules, immutability, and encapsulation at the core of the system.
3. **Messaging Layer**
   - **Technology:** MassTransit with RabbitMQ  
   - **Rationale:** Facilitates decoupled communication via durable events and supports scalable message routing.
4. **Persistence Layer**
   - **Technology:** EF Core with PostgreSQL  
   - **Rationale:** Provides relational integrity, supports value object mapping, and integrates seamlessly with .NET.
5. **Worker Layer**
   - **Technology:** Background service hosted in a separate container  
   - **Rationale:** Handles asynchronous event consumption and processing without blocking the API.
6. **Orchestration Layer**
   - **Technology:** Docker Compose  
   - **Rationale:** Enables reproducible, multi-container deployment with clear service dependencies and isolation.

---

## ⚙️ Setup Instructions

### 🔧 Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)  
- [Docker](https://www.docker.com/) + [Docker Compose](https://docs.docker.com/compose/)

### 📦 Build & Run

```bash
docker-compose down -v
docker-compose up --build
```

🧩 This Will
- 🚀 Build and run the **API** on [http://localhost:5000](http://localhost:5000)  
- 🧑‍🏭 Start the **Worker**, **PostgreSQL**, and **RabbitMQ** services  
- 🗃️ Apply **EF Core migrations** automatically on API startup

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
```

#### ✅ Sample Response

```json
{
  "orderId": "a1b2c3d4-e5f6-7890-abcd-1234567890ef"
}
```
---

## 🧪 End-to-End Flow
1. API receives order and persists it to PostgreSQL
2. Publishes OrderPlacedEvent to RabbitMQ
3. Worker consumes the event and logs processing
4. Order and items are stored in the database

---

## 📊 Observability (Optional)

### 🐇 RabbitMQ UI
**URL:** [http://localhost:15672](http://localhost:15672)  
**Login:** `myuser`  
**Password:** `mypassword`

### 🐘 PostgreSQL
**Connect via psql**
```bash
docker exec -it <postgres_container_name> psql -U postgres -d orders
```



