# 🧑‍💼 CountriesOfTheWorld Project

Visualization of countries of the world using external APIs.  
Display general information about the country, flag, coat of arms, map (external API), and the national anthem with its motto.

---

## 📅 Changelog

- **14/04/2025**: Change in the look & feel of the application, working with the Angular parent and child form concept. It fetches the country info on a map (using the external API **maplibre-gl: 5.3.0**).
- **26/01/2025**: Initial upload of the project. API correction to follow RESTful conventions and ensure that routes are appropriate and plural. Front end: Correction of URL invocations.
- **07/03/2025**: Code cleanup and removal of unnecessary comments. Database: ER diagram added.
- **26/02/2025**:
  - **Back end**: API correction to follow RESTful conventions and ensure that routes are proper and plural.
  - **Front end**: Correction of URL invocations.
- **26/01/2025**: Uploading the whole project (BackEnd, FrontEnd, Database).

---

## 🎯 Objective

Practice **.NET (C#)** / **SQL** and **Angular (Typescript)** / **Design Patterns** / **Onion Architecture**.  
To explain, roughly to people outside of programming, what is **BackEnd**, what is **FrontEnd**, and what is **BBDD** (Database).  
Familiarize myself with the use of **PostgreSQL** with Docker and **DBeaver**.

### Technologies:
- **.NET (C#)** and **PostgreSQL**
- **Angular (TypeScript)**
- **Design Patterns**
- **Onion Architecture**

---

## 🚀 Features

### 🔧 BACKEND:
- **Onion Architecture**
- **Design Patterns**: 
  - Repository
  - UnitOfWork
  - Singleton
  - Base Entity

### 💻 FRONTEND:
- Developed with **Angular 18.0.2 / 18.2.12**
- Utilizes the concept of data transfer between **parent-child components**
- **Popup presentation library**:
  - `@angular/cdk: 17.0.0`
  - `@angular/material: 17.0.0`
  - `@maplibre-gl: 5.3.0`
- **Module-oriented** structure.

---

### 🗄️ Database

- Uses **PostgreSQL**, running via **Docker Desktop**
- Includes:
  - Entity-Relationship Diagram (ERD)
  - Sample data insertion scripts (`.sql`)
  - **DDL scripts** for table creation
  - **DML scripts** for sample data insertion

---

## 🧪 Installation

### ✅ Prerequisites

Ensure the following tools are installed:

- [.NET SDK 9.0.200](https://dotnet.microsoft.com/)
- [DBeaver 25.0.4](https://dbeaver.io/download/)
- [Docker Desktop 4.40.0+](https://www.docker.com/)
- [Node.js + npm](https://nodejs.org/) (for frontend)
- [Postman 11.44.3](https://www.postman.com/downloads/)

---

### 🔧 Setup Steps

1. Clone the repository:
    ```bash
    git clone https://github.com/waltermillan/CountriesOfTheWorld.git
    ```

2. Follow the video guide for setup:
    - [1st Version Setup](https://youtu.be/LM-5ZPD8xyk)
    - [2nd Version Setup](https://youtu.be/ekfzAAOC0io)

3. Complete any remaining setup steps described in the project documentation.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
