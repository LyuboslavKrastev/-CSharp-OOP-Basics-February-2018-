using System;
using System.Linq;

namespace _04_OnlineRadioDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfSongs = int.Parse(Console.ReadLine());
            var Radio = new Radio();

            for (int i = 0; i < numberOfSongs; i++)
            {
                var songInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var artistName = songInput[0];
                    var songName = songInput[1];
                    var duration = songInput[2].Split(':');
                    var songMinutes = int.Parse(duration[0]);
                    var songSeconds = int.Parse(duration[1]);
                    var song = new Song(artistName, songName, songMinutes, songSeconds);

                    Radio.PlayList.Add(song);
                    Radio.SongAdded();
                }
                catch (FormatException)
                {
                    Console.WriteLine(new InvalidSongLengthException().Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(Radio);

        }
    }
}
