# ROTC Attendance System

A desktop application built with Windows Forms (.NET Framework) to track and manage attendance for ROTC sessions.

## Technology Stack
- C#
- Windows Forms (WinForms) for UI
- .NET Framework 4.7.2
- MySQL Database

## Overview

The ROTC Attendance System provides a comprehensive solution for managing student attendance during ROTC training sessions. It features time tracking, student management, reporting capabilities, and administrative controls.

## Features

- Time-in/Time-out tracking for ROTC sessions
- Student registration and profile management 
- Administrative user controls
- Attendance report generation with PDF export
- Statistical data visualization
- Search and filter capabilities
- Late arrival and early departure monitoring

## Prerequisites

- Windows Operating System
- .NET Framework 4.7.2
- MySQL Server
- Visual Studio (for development)

## Dependencies

- MySQL.Data
- iText7/iTextSharp for PDF generation
- System.Windows.Forms.DataVisualization for charting
- BouncyCastle for cryptography
- Additional NuGet packages as specified in packages.config

## Installation

1. Clone the repository:
```sh
git clone https://github.com/Mark-Anthony25/ROTC-attendance-system.git
```

2. Open `TimeTracker.sln` in Visual Studio

3. Restore NuGet packages

4. Configure the database connection string in `UserControl1.cs`, `UserControl2.cs`, `UserControl3.cs`, and `UserControl4.cs`:
```cs
private const string connectionString = "Server=your_server;Database=timetracker;Uid=your_username;Pwd=your_password;";
```

5. Build and run the application

## Usage

1. Launch the application
2. Login with admin credentials
3. Register new students or manage existing records
4. Track attendance using the Time In/Out system
5. Generate attendance reports and analytics

## Development Team

- Mark Anthony T. Reyes (Team Leader)


## Contributing

1. Fork the repository
2. Create a new branch
3. Make your changes
4. Submit a pull request

## License

Copyright © 2024. All rights reserved.
