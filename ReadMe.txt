Training application - website from scratch.
Web.API, .Net Core, Angular, Identity etc.




Based on:
Building a Web App with ASP.NET Core, MVC, Entity Framework Core, Bootstrap, and Angular By Shawn Wildermuth
https://github.com/psauthor/BuildingASPNETCore2
https://github.com/shawnwildermuth?tab=repositories


Some work with EF tools:

dotnet tool install -g dotnet-ef
Tool 'dotnet-ef' is already installed.

dotnet ef --help
dotnet tool update --global dotnet-ef --version 5.0.12

Issues:
1. I was unable to create code first migration. Answer below:
https://stackoverflow.com/questions/50436910/ef-core-not-creating-tables-on-migrate-method

Whole EF commands used for migrations:

C:\..\repos\DutchTreat\DutchTreat>dotnet ef database update
Build started...
Build succeeded.
No migrations were applied. The database is already up to date.
Done.

C:\..\repos\DutchTreat\DutchTreat>dotnet ef migrations add InitialDb
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'

C:\..\repos\DutchTreat\DutchTreat>dotnet ef database update
Build started...
Build succeeded.
Applying migration '20211120205158_InitialDb'.
Done.

