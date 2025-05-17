# AccountDashboard

A web-based dashboard application for managing clients, projects, users, and real-time notifications.  
Built with ASP.NET Core 9.0, following Clean Architecture principles and featuring SignalR for live updates.

---

## Table of Contents

- [Overview](#overview)  
- [Features](#features)  
- [Tech Stack](#tech-stack)  
- [Architecture Overview](#architecture-overview)  
- [Prerequisites](#prerequisites)  
- [Project Structure](#project-structure)   

---

## Overview

AccountDashboard is an ASP.NET Core application that lets administrators and team members:

- Create and manage client accounts  
- Organize projects under each client  
- Assign users with roles and permissions  
- Receive real-time notifications for new accounts, project updates, and user actions  

It aims for maintainability via Clean Architecture and a responsive UI powered by Razor Views and SignalR.

## Features

- **Clean Architecture**: Decoupled Domain, Data, Business, Hubs, and Presentation layers.  
- **ASP.NET Core 9.0** with MVC, Identity, and EF Core.  
- **Real-time Notifications** via SignalR hubs.  
- **Image Handling**: Store images locally or in Azure Blob Storage.  
- **Authentication & Authorization** using ASP.NET Core Identity.  
- **Responsive UI** using Razor Views, HTML5, CSS3, and vanilla JavaScript.  
- **Automated CI/CD** for Azure Web Apps via GitHub Actions.

## Tech Stack

- **Framework**: .NET 9.0 (ASP.NET Core)  
- **ORM**: Entity Framework Core (SQL Server)  
- **Authentication**: ASP.NET Core Identity  
- **Real-time**: SignalR  
- **Storage**:  
  - Local file system (`wwwroot/images/uploads`)  
  - Azure Blob Storage (`Azure.Storage.Blobs`)  
- **UI**: Razor Views, HTML, CSS, JavaScript  
- **CI/CD**: GitHub Actions (Azure Web Apps Deploy)

## Architecture Overview

1. **Domain**  
   - Core entities, DTOs, and mapping extensions.  
2. **Data**  
   - EF Core `DbContext`, entity configurations, and repositories.  
3. **Business**  
   - Application services implementing use cases, image handling, and notification logic.  
4. **Hubs**  
   - SignalR hub (`NotificationHub`) broadcasting real-time updates.  
5. **Presentation**  
   - ASP.NET Core MVC controllers, Razor views, and static assets.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)  
- SQL Server (LocalDB or full edition)  
- Visual Studio 2022 or VS Code (with C# extension)  
- (Optional) Azure subscription and Storage Account for Blob support

## Project Structure 

.
├── .github/                     # GitHub Actions workflows
├── Business/                    # Application services and image handlers
├── Data/                        # EF Core context, entities, migrations, repos
├── Domain/                      # Core models, DTOs, mapping extensions
├── Hubs/                        # SignalR hub definitions
├── Presentation/                # ASP.NET Core MVC project
│   ├── Controllers/  
│   ├── Views/  
│   ├── wwwroot/                 # CSS, JS, images
│   └── Program.cs  
└── AccountDashboard.sln         # Visual Studio solution
