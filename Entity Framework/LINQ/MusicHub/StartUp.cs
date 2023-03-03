using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums.Where(p => p.ProducerId == producerId).Select(a => new
            {
                Name = a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                ProducerName = a.Producer.Name,
                AlbumSongs = a.Songs.OrderByDescending(s => s.Name).Select(s => s).ToArray(),
                Price = a.Price,
                SongWriterName = a.Songs.OrderBy(w => w.Name).Select(w => w.Writer.Name).ToArray()

            }).ToArray().OrderByDescending(p => p.Price);

            var sb = new StringBuilder();

            foreach (var a in albums)
            {
                sb.AppendLine($"-AlbumName: {a.Name}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine("-Songs:"); 
                int index = 1;

                foreach (var s in a.AlbumSongs)
                {
                    sb.AppendLine($"---#{index}")
                        .AppendLine($"---SongName: {s.Name}")
                        .AppendLine($"---Price: {s.Price:f2}")
                        .AppendLine($"---Writer: {s.Writer.Name}");
                        
                        



                    index++;
                }

                sb.AppendLine($"-AlbumPrice: {a.Price:f2}");


            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            
            var sb = new StringBuilder();

            var songs = context.Songs.AsEnumerable().Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
            {
                Name = s.Name,
                Performers = s.SongPerformers.Select( sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                    .OrderBy(p => p).ToList(),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album!.Producer!.Name,
                Duration = s.Duration.ToString("c")
            }).OrderBy( s=> s.Name).ThenBy( s=> s.WriterName).ToList();


            int songNumber = 1;
            foreach (var s in songs)
            {
                sb
                    .AppendLine($"-Song #{songNumber}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}");
                foreach (var performer in s.Performers)
                {
                    sb
                        .AppendLine($"---Performer: {performer}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");

                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
