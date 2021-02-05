# .NET Notepad
## Targeted framework .NET Core 3.1

### Overview

Simple ASP.NET Core MVC application for creating, editing, deleting, reading notes. Users must be registered and authenticated in order to have access to the main functionality of the application.

There are two tables in the database with one-to-many relationship. One user can create as many as they want notes, in this application they are allowed to create 5 notes.
There is some basic validation when registering, creating a note and editing it.

```update-database``` <br/> command must be executed in the Package Manager Console in order for the database to be created.
