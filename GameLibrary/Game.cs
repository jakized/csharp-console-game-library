using System;

namespace GameLibrary;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }

    public Game(int id, string title, string genre, int releaseYear)
    {
        Id = id;
        Title = title;
        Genre = genre;
        ReleaseYear = releaseYear;
    }

    public override string ToString()
    {
        string titleFormatted = Title.Length > 20 ? Title.Substring(0, 20) : Title.PadRight(20);
        string genreFormatted = Genre.Length > 15 ? Genre.Substring(0, 15) : Genre.PadRight(15);

        return $"{Id, -4} | {titleFormatted} | {genreFormatted} | {ReleaseYear}";
    }
}
