# Student Absences Management System

A VB.NET Windows Forms application for managing student absence records with MySQL.

## Requirements
- Windows
- .NET 9 SDK
- MySQL server (for example, XAMPP)
- Database `students_db` with an `absences` table

## Database schema
The application expects this table:

```sql
CREATE DATABASE IF NOT EXISTS students_db;
USE students_db;

CREATE TABLE IF NOT EXISTS absences (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    hours INT NOT NULL,
    course_name VARCHAR(255) NOT NULL,
    absence_date DATE NOT NULL
);
```

## Configure the database
The default connection string in `Form1.vb` is configured for a local MySQL server with user `root`, an empty password, and database `students_db`. Change it in `Form1.vb` if your local setup uses different credentials. Do not commit real passwords or secrets.

## Build
Open PowerShell in this folder and run:

```powershell
dotnet restore
dotnet build
dotnet run
```

This project targets `net9.0-windows` and uses Windows Forms, so it must be run on Windows.

## Features
- Create absence records with student, course, hours, and date
- Blocks weekend and future-date entries
- Warns when total absence hours approach or exceed the configured threshold
- Lists records from MySQL and displays them in a table
- Deletes a selected absence from the database after confirmation
- Deletes all records for a named student after confirmation
- Exports the currently displayed records to CSV or TXT
- Displays basic absence statistics

## Notes
- The configured threshold is a simple application rule (`40` warning / `50` maximum) and should be adjusted to match the institution's official policy.
- Weekend and holiday highlighting is visual; the current validation blocks weekends but does not yet enforce an official holiday calendar.
