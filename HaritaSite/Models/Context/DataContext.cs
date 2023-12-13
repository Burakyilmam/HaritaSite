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
        public DbSet<User> Users { get; set; }
        public DbSet<Drawing> Drawings { get; set; }

    }
}
