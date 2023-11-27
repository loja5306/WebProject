# WebProject

## Setting Up Database

1) Create a server on Microsoft SQL Server and connect to it
2) Update the connection string in the appsettings.json file
3) Go to the NuGet Console and use command update-database

***Note: You may need to install the Microsoft.EntityFrameworkCore.Tools package in order to run this command***

## Adding New Table To Database
1) Create the database model class for the new table
2) Create a DbSet object for the new table using the new model class
3) Add a migration using the add-migration Name command where Name is a related name for the migration class
4) Use the update-database command to add the table to the database using the migration
