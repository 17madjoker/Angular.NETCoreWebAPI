using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Make> makes = new List<Make>();
            List<Model> models = new List<Model>();
            List<Feature> features = new List<Feature>();
            Random r = new Random();

            for (int i = 1; i <= 10; i++)
            {
                makes.Add(new Make {Id = i, Name = $"AutoBrand{i}"});
                features.Add(new Feature {Id = i, Name = $"Feature{i}"});
            }

            for (int i = 1; i <= 30; i++)
            {
                models.Add(new Model{Id = i, Name = $"AutoModel{i}", MakeId = r.Next(1, makes.Count + 1)});
            }

            modelBuilder.Entity<Make>().HasData(makes);
            modelBuilder.Entity<Model>().HasData(models);
            modelBuilder.Entity<Feature>().HasData(features);
        }
    }
}