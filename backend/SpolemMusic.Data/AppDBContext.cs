using Microsoft.EntityFrameworkCore;
using SpolemMusic.Data.Models;
using SpolemMusic.Data.Models.JoinTables;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base (options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<CartStatus> CartStatuses { get; set; }

        //ProductData
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Track> Tracks { get; set; }

        //JoinTables
        public DbSet<ArtistProduct> ArtistsProducts { get; set; }
        public DbSet<ArtistTrack> ArtistsTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ArtistTrack
            modelBuilder.Entity<ArtistTrack>()
                .HasKey(at => new { at.ArtistId, at.TrackId });
            modelBuilder.Entity<ArtistTrack>()
                .HasOne(a => a.Artist)
                .WithMany(at => at.ArtistTracks)
                .HasForeignKey(a => a.ArtistId);
            modelBuilder.Entity<ArtistTrack>()
                .HasOne(t => t.Track)
                .WithMany(ta => ta.TrackArtists)
                .HasForeignKey(t => t.TrackId);

            //ArtistProduct
            modelBuilder.Entity<ArtistProduct>()
                .HasKey(ap => new { ap.ArtistId, ap.ProductId });
            modelBuilder.Entity<ArtistProduct>()
                .HasOne(a => a.Artist)
                .WithMany(ap => ap.ArtistProducts)
                .HasForeignKey(a => a.ArtistId);
            modelBuilder.Entity<ArtistProduct>()
                .HasOne(p => p.Product)
                .WithMany(pa => pa.ProductArtists)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
