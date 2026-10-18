# SAEK – Student Absence Management System

A desktop application for managing student absences, developed using **VB.NET, Windows Forms, and MySQL**.

## 📌 Overview

The Student Absence Management System is designed to record, manage, and monitor student absences through a Windows desktop interface connected to a MySQL database.

The application provides tools for recording absence details, reviewing records, and monitoring absence-hour limits.

## ✨ Features

- **Absence Management** – Register student absences with a student name, course, date, and number of hours.
- **MySQL Database Integration** – Store and retrieve absence records from a MySQL database.
- **Calendar Interface** – Select dates and review absence records.
- **Absence Limit Monitoring** – Display warnings when students approach or exceed configured absence-hour limits.
- **Records Table** – Load and view absence records in a data grid.
- **Search by Date** – Filter records using the calendar.
- **Text File Export** – Save displayed records to a text file.
- **Average Hours Calculation** – Calculate the average absence hours.
- **Weekend and Holiday Handling** – Highlight weekends and configured holidays.

## 🛠️ Technologies Used

- **Language:** Visual Basic .NET (VB.NET)
- **Framework:** .NET 9
- **User Interface:** Windows Forms
- **Database:** MySQL
- **Database Connector:** MySql.Data
- **Development Environment:** Visual Studio Code
- **Local Database Environment:** XAMPP / phpMyAdmin

## 📂 Project Structure

```text
SAEK-Absence-Management-System/
├── Form1.vb
├── Form1.Designer.vb
├── Program.vb
├── StudentAbsences.vbproj
├── database_backup.sql
├── Texniki_Anafora.docx
├── README.md
└── .gitignore
```

## ⚙️ Requirements

Before running the application, make sure you have:

- Windows
- .NET 9 SDK
- MySQL Server
- XAMPP or another MySQL-compatible environment
- Visual Studio Code or another suitable .NET development environment

## 🚀 Installation and Setup

### 1. Clone the repository

```bash
git clone https://github.com/nikolasmarantas9/SAEK-Absence-Management-System.git
```

Open the downloaded project folder.

### 2. Set up the database

1. Start MySQL using XAMPP or your preferred MySQL environment.
2. Open phpMyAdmin in your browser.
3. Import the `database_backup.sql` file.
4. Confirm that the `students_db` database and its `absences` table have been created.

### 3. Configure the database connection

Open `Form1.vb` and locate the MySQL connection string.

Update the server, username, password, and database settings to match your local MySQL configuration.

### 4. Build the application

Open a terminal in the project folder and run:

```bash
dotnet restore
dotnet build
```

### 5. Run the application

```bash
dotnet run
```

The application is a Windows desktop application and requires a compatible Windows environment.

## 🗄️ Database Structure

The application uses the `students_db` database and the `absences` table.

| Column | Description |
|---|---|
| `id` | Unique absence record identifier |
| `name` | Student name |
| `hours` | Number of absence hours |
| `course_name` | Course associated with the absence |
| `absence_date` | Date of the absence |

## 🔒 Security Notes

- Configure database credentials according to your local environment.
- Avoid committing real passwords or sensitive information to a public repository.
- Use an appropriately secured MySQL account for production environments.

## 🎓 Project Purpose

This project was developed as an educational software application to demonstrate desktop application development, database connectivity, data management, and user interface design using VB.NET and MySQL.

## 📄 License

No license has been specified yet. Contact the repository owner before redistributing or reusing this project.

---

**Developed by:** Nikolas Marantas  
**Repository:** [SAEK-Absence-Management-System](https://github.com/nikolasmarantas9/SAEK-Absence-Management-System)
