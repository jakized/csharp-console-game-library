# Game Library Console Application

## Overview

The **Game Library Console Application** is a simple C# console app that allows users to manage a collection of video games. It provides functionality to **Add**, **List**, **Update**, and **Delete** games from a local SQLite database.

This project is an example of implementing basic **CRUD** operations using a console interface, a `SQLite` database, and C#.

## Features

- **Add Game**: Add a new game with title, genre, and release year.
- **List Games**: Display all games stored in the library.
- **Update Game**: Modify an existing game's information.
- **Delete Game**: Remove a game from the library by ID.
- **Validation**: Ensures valid input for game data and prevents invalid operations.

## Project Structure

- **Program.cs**: The entry point of the application. Runs the main menu and interacts with the user.
- **GameController.cs**: Handles user input, validation, and game operations (Add, List, Update, Delete).
- **DatabaseHelper.cs**: Manages all database operations, including creating tables, and performing CRUD operations on the game data.

## Installation

1. Clone the repository:

   ```bash/Widnows Terminal
   git clone https://github.com/yourusername/GameLibraryConsoleApp.git

2. Open the project

3. Ensure you have the required dependencies:

    SQLite (included in System.Data.SQLite package - NuGet)
    .NET SDK

4. Build the project to restore the necessary NuGet packages.


# Usage
Once the project is built and dependencies are restored, you can run the application from your IDE or using the command line.

## Main Menu Options:

    1. Add Game:
        Enter the game title, genre, and release year (validations included).

    2. List Games:
        Displays all games currently in the database with their ID, title, genre, and release year.

    3. Update Game:
        Select a game by its ID and update the title, genre, or release year.

    4. Delete Game:
        Remove a game from the library by specifying its ID.

    5. Exit:
        Closes the application.

## Example run
Game Library

1. Add Game
2. List Games
3. Update Game
4. Delete Game
5. Exit

* Choose an option: 1
* Enter the title: Cyberpunk 2077
* Enter the genre: Action RPG
* Enter release year: 2020
* Game added successfully!


## Future Improvements

    - Search Functionality: Add a feature to search games by title or genre.
    - Sorting Options: Allow listing games in sorted order (by release year, title, etc.).
    - Error Logging: Implement logging to track errors and invalid operations.
