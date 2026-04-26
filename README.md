# SpaceMission 2026 - Cosmic Navigation & Rescue System

This project is a .NET 10 console application developed as a technical assessment for **Hitachi Solutions**. It is designed to navigate astronauts through a grid-based cosmic environment, avoiding asteroids and optimizing movement through space debris to reach a central Space Station.

## 🚀 Features

### 🧠 Advanced Pathfinding
* **Dijkstra's Algorithm:** Implements a weighted pathfinding strategy to find the mathematically shortest path.
* **Weighted Terrain:** Different cell types incur different costs (e.g., **Space Debris 'D'** costs 2 steps, while **Open Space '0'** costs 1).
* **Collision Avoidance:** Automatically detects and bypasses impassable **Asteroids ('X')**.

### 🛠 System Capabilities
* **Dual Initialization Modes:** Supports both manual map input (standard input) and **Dynamic Map Generation** for stress testing.
* **Visual Map Rendering:** High-fidelity console output using `*` to trace the calculated route for each astronaut.
* **Multi-Astronaut Support:** Handles up to 3 astronauts (S1, S2, S3) simultaneously, prioritizing successful missions by shortest path.

### 📧 Automated Reporting
* **SMTP Integration:** Feature-rich email service that dispatches a full mission report to Mission Control via a secure SMTP connection.
* **Configurable Settings:** Support for custom SMTP hosts, ports, and App Passwords (tested with Gmail).

## 🏗 Architecture & Design
This application follows a **Clean Code** approach and adheres strictly to **SOLID** principles:

* **Strategy Pattern:** Used for the pathfinding logic, allowing the algorithm to be swapped without changing the core execution.
* **Dependency Injection:** Services are registered and resolved using `Microsoft.Extensions.DependencyInjection`, ensuring high testability and decoupling.
* **Centralized Constants:** Zero "magic strings" – all symbols, messages, and configurations are managed through `AppConstants` and `AppMessages` in a `Common` layer.
* **Interface-Driven Development:** Every service is abstracted behind an interface (Contracts) to ensure a clear "contract-first" design.

## 💻 Technologies
* **Framework:** .NET 10
* **Language:** C# 14
* **DI Container:** `Microsoft.Extensions.DependencyInjection`
* **Protocols:** SMTP (System.Net.Mail)

## 📦 Installation & Usage

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/stoyantsiparov/SpaceMission2026.git](https://github.com/stoyantsiparov/SpaceMission2026.git)
