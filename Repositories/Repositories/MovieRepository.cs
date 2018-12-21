using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Entities;
using Services.Interfaces;

namespace Services.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            this._context = context;
        }

        public Movie Add(Movie movie)
        {
            foreach(MovieActor ma in movie.Actors)
            {
                var actor = ma.Actor;
                var dbActor = this._context.Persons.FirstOrDefault(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName);
                if(dbActor != null)
                {
                    ma.Actor = dbActor;
                }
            }

            this._context.Movies.Add(movie);
            this._context.SaveChanges();
            return movie;
        }
      
        public bool Delete(int id)
        {
            var entity = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return false;
            }

            _context.Movies.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Movie> GetAllMovies(string title)
        {
            var listMovies = _context.Movies.Where(x => x.Title.Contains(title));
            return listMovies.ToList();
        }

        public Movie GetByTitle(string movieTitle)
        {
            return _context.Movies.FirstOrDefault(x => x.Title == movieTitle);
        }

        public Movie GetMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            return movie;
        }

        public Movie Update(int id, Movie movie)
        {
            var entity = _context.Movies.FirstOrDefault(x => x.Id == id);
            movie.Id = id;
            _context.Entry(entity).CurrentValues.SetValues(movie);
            _context.SaveChanges();
            return entity;
        }

        public int CheckDate(DateTime releasedDate)
        {
            return releasedDate.Year;
        }
    }
}
