# CountriesOfTheWorld Project
Visualization of countries of the world using external APIs.
Display general information about the country, flag, coat of arms, map (external api) and the national anthem with its motto.


## Changelog
- **26/01/2025**: Initial upload of the project. API correction to follow RESTful conventions and ensure that routes are appropriate and plural. Front end: Correction of URL invocations.
- **07/03/2025**: Code cleanup and remove unnecessary comments. Database: ER diagram is added.
- **14/04/2025**: Change in the look & feel of the application, working with the Angular parent and child form concept. It fetches the country info on a map (using the external api maplibre-gl: 5.3.0.
  

## Objective:
Practice **.NET (C#)** / **SQL** and **Angular (Typescript)** / **Design Patterns** / **Onion Architecture**.
To explain, roughly to people outside of programming, what is **BackEnd**, what is **FrontEnd**, and what is **BBDD** (Database).  
Familiarize myself with the use of postgreSQL with Docker and DBeaver. 

## Features

### BACKEND:
- **Onion Architecture**.
- **Design Patterns**: 
  - Repository
  - UnitOfWork
  - Singleton
  - Base Entity

### FRONTEND:
- Developed with **Angular 18.0.2 / 18.2.12**
- Utilizes the concept of data transfer between **parent-child components**
- **Popup presentation library**: 
  - `@angular/cdk: 17.0.0`
  - `@angular/material: 17.0.0`
  - `@maplibre-gl: 5.3.0`
- **Module-oriented** structure.

### DB:
- Written in **PostgreSQL**.
- Contains **Tables (DDLs)** and **Data (DMLs)**.

## Installation

### Prerequisites:
Make sure you have the following installed:
- **.NET SDK** (version 9.0.200)
- **DBeaver 25.0.2** or a compatible database.
- **Docker 4.40.0** or similar.
- **Node.js** and **npm** (for frontend development).

### Steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/waltermillan/CountriesOfTheWorld.git
    ```

2. Follow the video guides for setup:
    - [1st Version Setup](https://youtu.be/LM-5ZPD8xyk)
    - [2nd Version Setup](https://youtu.be/ekfzAAOC0io)

3. Follow the rest of the installation steps provided in the documentation.

## Future Improvement
- The data for the images of the flags, coat of arms and nationals anthem sounds are loaded into the postgreSQL database. This should be moved to a NoSQL database such as MongoDB.


## License
Free

