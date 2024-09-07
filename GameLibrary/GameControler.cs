using System;
using System.Data.Common;

namespace GameLibrary;

public class GameController
{
    private DatabaseHelper _dbHelper = new DatabaseHelper();

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\nGame Library\n");
            Console.WriteLine("1. Add Game");
            Console.WriteLine("2. List Games");
            Console.WriteLine("3. Update Game");
            Console.WriteLine("4. Delete Game");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGame();
                    break;

                case "2":
                    ListGames();
                    break;

                case "3":
                    UpdateGame();
                    break;

                case "4":
                    DeleteGame();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    private void AddGame()
    {
        string title;
        do
        {
            System.Console.Write("Enter the title: ");
            title = Console.ReadLine();

            if (string.IsNullOrEmpty(title))
            {
                System.Console.WriteLine("Title cannot be empty. Enter a valid title.");
            }
        } while (string.IsNullOrEmpty(title));

        string genre;
        do
        {
            System.Console.Write("Enter the genre: ");
            genre = Console.ReadLine();

            if (string.IsNullOrEmpty(genre))
            {
                System.Console.WriteLine("Genre cannot be empty. Enter a valid genre.");
            }
        } while (string.IsNullOrEmpty(genre));

        int year;
        do
        {
            System.Console.Write("Enter release year: ");
            string yearInput = Console.ReadLine();

            if (!int.TryParse(yearInput, out year) || year < 1980 || year > DateTime.Now.Year)
            {
                Console.WriteLine($"Please enter a valid year between 1980 and {DateTime.Now.Year}.");
            }
        } while (year < 1980 || year > DateTime.Now.Year);

        _dbHelper.InsertGame(title, genre, year);
        System.Console.WriteLine("Game added successfully!\n");

    }

    private void ListGames()
    {
        System.Console.WriteLine();
        var games = _dbHelper.GetAllGames();
        string header = $"{"ID",-4} | {"Title",-20} | {"Genre",-15} | {"Release Year"}";
        System.Console.WriteLine(header);
        System.Console.WriteLine(new string('-', header.Length));
        foreach (var game in games)
        {
            System.Console.WriteLine(game);
        }
        System.Console.WriteLine();
    }

    private void UpdateGame()
    {
        ListGames();

        int id;
        System.Console.Write("Enter the game ID you want to update: ");
        while (!int.TryParse(Console.ReadLine(), out id) || !_dbHelper.GameExists(id))
        {
            Console.WriteLine("Invalid ID or no game found with that ID. Please enter a valid game ID.");
        }

        string title;
        do
        {
            System.Console.Write("Enter new title: ");
            title = Console.ReadLine();

            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title cannot be empty. Please enter a valid title.");
            }
        } while (string.IsNullOrEmpty(title));

        string genre;
        do
        {
            System.Console.Write("Enter new genre: ");
            genre = Console.ReadLine();

            if (string.IsNullOrEmpty(genre))
            {
                Console.WriteLine("Genre cannot be empty. Please enter a valid genre.");
            }
        } while (string.IsNullOrEmpty(genre));

        int year;
        do
        {
            System.Console.Write("Enter new release year: ");
            if (!int.TryParse(Console.ReadLine(), out year) || year < 1980 || year > DateTime.Now.Year)
            {
                Console.WriteLine($"Please enter a valid year between 1980 and {DateTime.Now.Year}.");
            }
        } while (year < 1980 || year > DateTime.Now.Year);


        _dbHelper.UpdateGame(id, title, genre, year);
        System.Console.WriteLine("Game updated successfully!");
    }

    private void DeleteGame()
    {
        ListGames();
        int id;
        do
        {
            System.Console.Write("Enter the Id of the game you wish to delete: ");
            if (!int.TryParse(Console.ReadLine(), out id) || !_dbHelper.GameExists(id))
            {
                Console.WriteLine("Invalid ID or no game found with that ID. Please enter a valid game ID.");
            }
        } while (!_dbHelper.GameExists(id));

        _dbHelper.RemoveGame(id);
        System.Console.WriteLine("\nGame removed.\n");
    }

}
