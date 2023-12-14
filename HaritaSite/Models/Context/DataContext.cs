using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HaritaSite.Models.Entity;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace HaritaSite.Models.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Drawing> Drawings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");

            modelBuilder.Entity<Drawing>()
                            .Property(d => d.Shape)
                            .HasColumnType("geometry")
                            .HasColumnName("Shape")
                            .HasConversion(
                                shape => shape == null ? null : new NetTopologySuite.IO.WKTWriter().Write(shape),
                                wkt => string.IsNullOrWhiteSpace(wkt) ? null : new NetTopologySuite.IO.WKTReader().Read(wkt)
                            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
