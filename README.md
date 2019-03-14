# Game Search Engine
# By Sam Stoia, Aaron Taylor, Tanner Damron, Porter Savage

## Description
This is A webpage that will allow the user to search from a database of games by, Keywords, Genre, platform, and/or year released. The user also will have an option to add games to the database.

## Specifications
* User can search the database by using keywords.
* User can search the database by picking A genre.
* User can search the database by choosing A year released.
* User can search the databse by picking a gaming platform.
* User can search the databse by all the above aformentioned parameters at once. 

## Setup Instructions
* Download and Install .NET Core version 1.1.4 SDK, .NET Core Runtime version 1.1.2, and MAMP.
* Clone the repository by executing the following command in your command line "$git clone (repository link)".
* Execute command to open the repository in your preferred text editor.
* Open MAMP and MAKE SURE your Apache port is set to 8888 and MySql port is set to 8889, then click "Start Servers"
* YOU MUST CREATE THE DATABASE FIRST TO BE ABLE TO USE THIS WEBPAGE!
* In the command line, Execute the command "MySql -uroot -proot -P8889.
* Once you are in the MySql shell, Execute the following commands to create the database:
* > "CREATE DATABASE game;"
* > "USE game;"
* > "CREATE TABLE games (id serial PRIMARY KEY, title VARCHAR(255), desecription VARCHAR(9999), genre VARCHAR(100), platforms VARCHAR(255), year_released VARCHAR(255), rating INT(11), image_large VARCHAR(666), thubmnail_image VARCHAR(666));"
* In order to use to webpage, you need to navigate to the "GameSearchEngine" directory within the "GameSearchEngine.Project" directory.
* Once you've navigated to the "GameSearchEngine" directory, execute these commands in order in the command line, "dotnet restore", "dotnet build", "dotnet run".
* Navigate to "http://localhost:5000" to see the webpage.

## Bugs
* No Known bugs

### Languages and Libraries Used
* C#
* HTML
* CSS
* JavaScript
* .NET Core
* MAMP
* phpMyAdmin

### Contact
* For support contact, samstoia@gmail.com

Copyright (c) 2019 Sam Stoia, Aaron Taylor, Tanner Damron, Porter Savage
