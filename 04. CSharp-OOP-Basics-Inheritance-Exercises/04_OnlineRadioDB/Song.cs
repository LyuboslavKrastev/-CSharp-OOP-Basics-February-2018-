using System;
public class Song
{

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            ValidateSeconds(value);
            seconds = value;
        }
    }

    private static void ValidateSeconds(int value)
    {
        if (value < 0 || value > 59)
        {
            throw new InvalidSongSecondsException();
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            ValidateMinutes(value);
            minutes = value;
        }
    }

    private static void ValidateMinutes(int value)
    {
        if (value < 0 || value > 14)
        {
            throw new InvalidSongMinutesException();
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            ValidateSongName(value);
            songName = value;
        }
    }

    private static void ValidateSongName(string value)
    {
        if (value.Length < 3 || value.Length > 30)
        {
            throw new InvalidSongNameException();
        }
    }

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            ValidateArtistName(value);
            artistName = value;
        }
    }

    private static void ValidateArtistName(string value)
    {
        if (value.Length < 3 || value.Length > 20)
        {
            throw new InvalidArtistNameException();
        }
    }
}

