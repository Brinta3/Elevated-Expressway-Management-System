Elevated Expressway Management System (EEMS)
Description
The Elevated Expressway Management System (EEMS) is a multi-layer C# Windows Forms application designed to simulate the operations of an expressway. This project uses OOP concepts, multiple forms, and SQL database integration to manage toll operations, control center administration, and patrol monitoring.

The system demonstrates real-world functionalities like user management, vehicle tracking, toll collection, report generation, and incident monitoring in a simple, educational environment.

Technologies & Tools
Language: C#
Framework: .NET (Windows Forms)
Database: SQL Server (Microsoft.Data.SqlClient)
Concepts: OOP, Multi-layer design, CRUD operations, Event-driven programming

Project Structure
Classes
Vehicle Classes: Bike, Car, Bus, Truck, Vehicle
Utility Classes: Database, TollCalc, Program
User Classes: Login, Patrol
Forms
Form1 – Login
Form2 – Control Centre (Admin)
Form3 – Toll Booth (Toll Operator)
Form4 – Report View
Form5 – Patrol

SQL Tables
Toll Booth – Stores toll operations
Control Centre – Stores admin and user data
Report – Stores all generated reports
Patrol – Stores patrol activities and updates
User Roles & Default Credentials

The system supports three types of users, each with default password 1234:

Role	Username	Password	Responsibilities
Toll	Toll Booth Operator	1234	Operate toll booth, record vehicle passage, collect tolls, generate and send toll reports
Admin	Control Centre	1234	Create/manage users, monitor operations, receive toll & patrol reports, maintain system records
Patrol	Patrol Officer	1234	Monitor expressway, identify incidents, submit patrol reports, solve reported problems, update report status

Features
Toll (Toll Booth Operator)
Operate toll booths efficiently
Record entry and passage of vehicles
Collect toll fees from vehicles
Generate toll collection reports
Send reports to patrol and control center

Admin (Control Centre)
Create new users and assign roles
Manage existing users and their permissions
Receive and monitor toll and patrol reports
Oversee expressway operations
Maintain system records

Patrol
Monitor expressway conditions in real-time
Identify incidents or issues
Submit patrol reports
Address and solve reported problems
Update the status of incidents and reports

Installation & Setup

Clone the repository:

git clone <(https://github.com/Brinta3/Elevated-Expressway-Management-System)>


Open the .sln solution file in Visual Studio.
Ensure SQL Server is installed and running.
Update the connection string in Database.cs to match your SQL Server setup.
Build and run the project.
Log in with one of the default users (Toll, Admin, Patrol) and password 1234.

Notes
This project is educational and demonstrates basic expressway management operations.
SQL Server database should be set up with the four tables: Toll Booth, Control Centre, Report, Patrol.
Passwords are currently set to a default 1234 for simplicity.

License
This project is open-source and can be used for educational and learning purposes.

Credit: Microsoft SQL server, Visual Studio, Google, W3 school.
