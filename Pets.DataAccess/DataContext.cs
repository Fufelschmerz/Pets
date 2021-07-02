using Microsoft.EntityFrameworkCore;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using Pets.Core.Domain.ValueObjects;
using System;

namespace Pets.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Breed> AnimalBreeds { get; set; }

        public DbSet<AnimalEntity> Animals { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Cat> Cats { get; set; }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<Feeding> Feedings { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCollation("my_collation", locale: "en-u-ks-primary", provider: "icu", deterministic: false);

            modelBuilder.UseDefaultColumnCollation("my_collation");

            modelBuilder.Entity<Breed>().Property(e => e.Type)
                .HasConversion(
                x => x.ToString(),
                v => (AnimalType)Enum.Parse(typeof(AnimalType), v));

            modelBuilder.Entity<Cat>().Property(e => e.Type)
                .HasConversion(
                x => x.ToString(),
                v => (AnimalType)Enum.Parse(typeof(AnimalType), v));

            modelBuilder.Entity<Dog>().Property(e => e.Type)
                .HasConversion(
                x => x.ToString(),
                v => (AnimalType)Enum.Parse(typeof(AnimalType), v));

            modelBuilder.Entity<Food>().Property(e => e.Type)
                .HasConversion(
                x => x.ToString(),
                v => (AnimalType)Enum.Parse(typeof(AnimalType), v));
        }
    }
}
