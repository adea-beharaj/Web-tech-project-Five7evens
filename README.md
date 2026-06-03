# Five 7evens Travel Agency — Full Stack

A travel agency website with a C# ASP.NET Core Web API backend (following the Students.API pattern) connected to an HTML/jQuery frontend.

---

## Prerequisites

Before running the project, make sure you have these installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 10 or later)
- [Node.js](https://nodejs.org) (for serving the frontend)
- [PostgreSQL](https://www.postgresql.org/download/windows/) (version 18 or later)

---

## Project Structure

```
Five7evens.API/          ← C# Backend (ASP.NET Core 8 + SQLite)
  Five7evens.API.sln
  Five7evens.API/
    Controllers/
      BookingsController.cs   ← CRUD for bookings
      PackagesController.cs   ← Read travel packages
    Models/
      Booking.cs
      Package.cs
    Services/
      BookingsService.cs
      PackagesService.cs
    Data/
      AppDbContext.cs          ← EF Core + SQLite
    Migrations/
      ...                      ← Auto-generated migration
    Program.cs
    appsettings.json

project-connected/       ← HTML/jQuery Frontend (updated to call API)
  index.html
  packages.html
  bookingForm.html
  details.html
  scripts/
    bookingForm.js        ← Now calls API instead of localStorage
    packages.js           ← Now loads prices from API
  styles/
  picture/
```

---

---

## How to Run

### Step 0 — Clone the repository

Open a terminal and run:

```powershell
git clone https://github.com/YOUR_USERNAME/Five7evens-FullStack.git
cd Five7evens-FullStack
```

Then follow the steps below.

### Step 1 — Set up PostgreSQL

1. Open **SQL Shell (psql)** from the Start menu
2. Press **Enter** for all prompts until it asks for a password, then enter your PostgreSQL password (password is: admin)
3. Create the database by running:

```sql
CREATE DATABASE five7evens;
```

### Step 2 — Configure the connection string

Open `Five7evens.API/Five7evens.API/appsettings.json` and update the password to match your PostgreSQL password:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=five7evens;Username=postgres;Password=YOUR_PASSWORD"
}
```

### Step 3 — Run the Backend

Open a terminal and run:

```powershell
cd "Five7evens.API\Five7evens.API"
dotnet restore
dotnet ef database update
dotnet run
```

The API will start on **http://localhost:5000**.
Swagger UI is available at **http://localhost:5000/swagger**.

> All tables and seed data (6 travel packages) are created automatically.

### Step 4 — Run the Frontend

Open a **second terminal** and run:

```powershell
cd "project-connected"
npx serve .
```

Then open your browser and go to: http://localhost:3000/packages.html
> Keep both terminals open at the same time — closing either one stops that part of the app.

---

## API Endpoints

### Bookings

| Method | URL                         | Description       |
|--------|-----------------------------|-------------------|
| GET    | /Bookings/GetAll            | Get all bookings  |
| GET    | /Bookings/GetById?id=1      | Get booking by ID |
| POST   | /Bookings/AddNew            | Create booking    |
| PUT    | /Bookings/Update            | Update booking    |
| DELETE | /Bookings/Delete?id=1       | Delete booking    |

### Packages

| Method | URL                               | Description          |
|--------|-----------------------------------|----------------------|
| GET    | /Packages/GetAll                  | Get all packages     |
| GET    | /Packages/GetByValue?value=paris  | Get package by value |
| GET    | /Packages/GetById?id=1            | Get package by ID    |

