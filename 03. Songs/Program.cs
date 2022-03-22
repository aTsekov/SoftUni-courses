using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class SongClass // правим си нов клас.
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine()); // приемаме колко песни ще има. 
            List<SongClass> songList = new List<SongClass>(); // правим нов лист от класа. 

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] lineParmas = Console.ReadLine().Split('_', StringSplitOptions.RemoveEmptyEntries); // правим масив, за да разделим на различни съсватни части стринг, които ще пълнив в новите обекти. 

                SongClass newSongObject = new SongClass() // правим нов обект, който го пълним с данните от масива. 
                {
                    Name = lineParmas[1],
                    Type = lineParmas[0],
                    Time = lineParmas[2],
                };

                songList.Add(newSongObject); // добавяме към листа , новия обект. 
            }

            string filterValue = Console.ReadLine(); // приемаме по какъв начин ще филтрираме (от конзолата)

            if (filterValue == "all") 
            {
                foreach (var song in songList)
                {
                    Console.WriteLine(song.Name); // ако филтъра е алл трябва да принтира всички имена от листа с песни. 
                }

                // LINQ way
                //Console.WriteLine(string
                //    .Join(Environment.NewLine, songs
                //        .Select(song => song.Name)));
            }
            else
            {
                var filteredSongs = songList.FindAll(x => x.Type == filterValue);

                foreach (var song in filteredSongs) // ако филтъра е TypeList  принтирай всички песно с тип Ty[eList. 
                {
                    Console.WriteLine(song.Name);
                }

                // LINQ way
                //Console.WriteLine(string
                //    .Join(Environment.NewLine, filteredSongs
                //        .Select(song => song.Name)));
            }
        }
    }
}