# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Overview

This repository contains two versions of a Brand Management System:
- **Java version** (`src/`): Original implementation using Servlet + MyBatis + Vue.js
- **C# version** (`BrandCase/`): Converted implementation using ASP.NET Core + EF Core + Blazor

## Build and Run Commands

### C# Project (BrandCase/)

```bash
# Build
cd BrandCase
dotnet build

# Run Blazor frontend (recommended, includes backend)
cd BrandCase/BrandCase.Blazor
dotnet run
# Access: https://localhost:5001

# Run Web API only
cd BrandCase/BrandCase.Api
dotnet run
# Swagger: https://localhost:7112/swagger

# Restore packages
dotnet restore

# EF Core migrations
dotnet ef migrations add <Name> -p BrandCase.Infrastructure -s BrandCase.Api
dotnet ef database update -p BrandCase.Infrastructure -s BrandCase.Api
```

### Java Project (src/)

```bash
# Build with Maven
mvn clean package

# Run with Tomcat plugin
mvn tomcat7:run
```

## Architecture

### C# Solution Structure

```
BrandCase.Core           → Entities, DTOs, Interfaces (no dependencies)
BrandCase.Infrastructure → EF Core DbContext, Service implementations (depends on Core)
BrandCase.Api            → Web API controllers (depends on Core, Infrastructure)
BrandCase.Blazor         → Blazor Server UI with MudBlazor (depends on Core, Infrastructure)
```

**Key patterns:**
- Services are registered via DI in `Program.cs`
- `IBrandService` interface in Core, `BrandService` implementation in Infrastructure
- `AppDbContext` maps to MySQL table `tb_brand` with column name transformations (snake_case → PascalCase)

### Java Package Structure

```
com.itheima.pojo     → Entity classes (Brand, PageBean)
com.itheima.mapper   → MyBatis mappers (interface + XML)
com.itheima.service  → Business logic layer
com.itheima.web      → Servlet controllers (BaseServlet uses reflection for routing)
```

## Database

Both versions use the same MySQL database `db1` with table `tb_brand`:

| Column | Type | Maps to |
|--------|------|---------|
| id | INT | Id |
| brand_name | VARCHAR | BrandName |
| company_name | VARCHAR | CompanyName |
| ordered | INT | Ordered |
| description | VARCHAR | Description |
| status | INT | Status (0=禁用, 1=启用) |

Connection string location: `appsettings.json` in both Api and Blazor projects.

## Ports

| Project | HTTP | HTTPS |
|---------|------|-------|
| Blazor | 5000 | 5001 |
| API | 5210 | 7112 |
