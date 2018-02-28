
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Radio
{
    public List<Song> PlayList { get; set; } = new List<Song>();

    public override string ToString()
    {
        var totalSecs = PlayList.Select(s => s.Seconds).Sum();
        var totalMins = PlayList.Select(s => s.Minutes * 60).Sum();
        var secs = totalSecs + totalMins;
        TimeSpan t = TimeSpan.FromSeconds(secs);

        string totalTime = $"{t.Hours}h {t.Minutes}m {t.Seconds}s";

        var result = new StringBuilder();
        result.AppendLine($"Songs added: {PlayList.Count}")
            .AppendLine($"Playlist length: {totalTime}");

        return result.ToString().TrimEnd();
    }
    public void SongAdded()
    {
        Console.WriteLine("Song added.");
    }
}

