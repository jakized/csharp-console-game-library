using System;
using Microsoft.Data.Sqlite;

namespace GameLibrary;

public class DatabaseHelper
{
    private string _connectionString = @"Data Source=GamesDatabase.db";

    public DatabaseHelper()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        try
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Games (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Genre TEXT NOT NULL,
                ReleaseYear INTEGER);";

                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"{ex.Message}");
        }


    }

    public void InsertGame(string title, string genre, int ReleaseYear)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string insertQuery = @"INSERT INTO Games(Title, Genre, ReleaseYear)
                                    VALUES(@Title, @Genre, @ReleaseYear);";

            using (var command = new SqliteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@ReleaseYear", ReleaseYear);
                command.ExecuteNonQuery();
            }
        }
    }

    public List<Game> GetAllGames()
    {
        var games = new List<Game>();

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string tableQuery = @"SELECT * FROM Games";

            using (var command = new SqliteCommand(tableQuery, connection))
            {
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var game = new Game(
                            Convert.ToInt32(reader["Id"]),
                            reader["Title"].ToString(),
                            reader["Genre"].ToString(),
                            Convert.ToInt32(reader["ReleaseYear"])
                        );
                        games.Add(game);
                    }
                }
            }
        }
        return games;
    }
    
    public void UpdateGame(int id, string title, string genre, int releaseYear)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string updateQuery = @"UPDATE Games SET
                                    Title = @Title,
                                    Genre = @Genre,
                                    ReleaseYear = @ReleaseYear
                                    WHERE Id = @Id";
            
            using (var command = new SqliteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void RemoveGame(int id)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Games WHERE Id = @Id";

            using (var command = new SqliteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }


    public bool GameExists(int id)
    {

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Games WHERE Id = @Id";

            using (var command = new SqliteCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
