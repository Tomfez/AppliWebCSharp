﻿using DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class MovieDbContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        public MovieDbContext()
        {

        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=moviedb;uid=root;password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(bc => bc.DirectedMovies)
                .WithOne(x => x.Director)
                ;

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Actors)
                .WithOne(x => x.Movie)
                ;

            modelBuilder.Entity<Person>()
                .HasMany(x => x.PlayedMovies)
                .WithOne(x => x.Actor)
                ;

            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.ActorId, x.MovieId });
        }
    }
}
