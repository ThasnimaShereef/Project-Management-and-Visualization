
# Project Management and Visualization System

## Overview

This project is a comprehensive system for managing projects, vendors, and subsystems. It includes an admin section for handling project details, vendor details, and subsystems with features like adding new records, editing, generating PDF reports, and visualizing project routes on an interactive map. The system also generates structured reports, allowing users to filter and analyze data effectively.

## Features

### Admin Section
1. **Project Management**:
   - Displays a table with project details (ID, name, inserted by, date, status).
   - Allows adding, editing, and generating PDF reports for project data.

2. **Vendor Management**:
   - Displays a table with vendor details (name, subsystem, inserted by, date).
   - Allows adding, editing, and generating PDF reports for vendors.

3. **Subsystem Management**:
   - Displays a table of subsystems with information like project name, type, IP address, serial number, etc.
   - Allows adding, editing, and generating PDF reports for subsystems.

### Map Features
- Visual representation of project sites with layers, route visualizations, hardware icons, and tooltips.
- Controls for zooming, switching views (satellite, dark), and interacting with the map.

### Report Generation
- RDLC-generated PDF reports with filters for project type, name, subsystem type, and date range.
- Detailed and professional output for system data, including project and subsystem details.

## Screenshots

Here are some screenshots of the project:

![Project Table](images/project_table.png)
*Example of the project table view.*

![Map View](images/map_view.png)
*Route visualization between project sites.*

![Subsystem Management](images/subsystem_management.png)
*Subsystem details with editable fields.*


## Installation and Setup

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/ThasnimaShereef/Project-Management-and-Visualization.git
   ```

2. **Install Dependencies**:
   - Ensure ASP.NET MVC is set up correctly in your environment.

3. **Database Setup**:
   - Set up the database using the provided schema for `TSubSystemMasterDetails`.
   - Ensure necessary columns are added, such as `Model`, `Vendor`, `SerialNo`, `Verified`, etc.

4. **Start the Application**:
   - Run the application from Visual Studio or your preferred environment.

## Usage

- Admin users can log in and manage projects, vendors, and subsystems.
- Use the map for visualizing project routes and hardware details.
- Generate PDF reports from the project, vendor, and subsystem tables using the provided buttons.

## Contributions

Feel free to contribute to this project by opening issues or submitting pull requests.

---


 
