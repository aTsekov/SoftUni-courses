using MusicHub.Data.Models;

namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }
        public DbSet<Performer> Performers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(entity =>
            {
                entity.Property(s => s.CreatedOn)// Make sure that the type in SQL will be "DATE" only.
                    .HasColumnType("date");
            });

            builder.Entity<Album>(entity =>
            {
                entity.Property(a => a.ReleaseDate).HasColumnType("date");
            });

            builder.Entity<SongPerformer>(entity => //Here we create a composite key of the mapping class.
            {
                entity.HasKey(sp => new { sp.PerformerId, sp.SongId });
            });
        }
    }
}
