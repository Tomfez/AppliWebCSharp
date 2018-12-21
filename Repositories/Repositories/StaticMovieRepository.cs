using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.Entities;
using Services.Interfaces;

namespace Services.Repositories
{
    public class StaticMovieRepository : IMovieRepository
    {
        public Movie Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public int CheckDate(DateTime dateMovie)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllMovies(string title)
        {
            return new List<Movie>()
            {
                new Movie() { Title = "Star wars", Description = "Star Wars 8", Duration = 150, ReleasedDate = new DateTime(2018, 12, 01) },
                new Movie() { Title = "Martine a la plage", Description = "La nouvelle aventure de Martine", Duration = 95, ReleasedDate = new DateTime(2019, 02, 14) }
            };
        }

        public Movie GetByTitle(string movieTitle)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(int id)
        {
            List<Movie> allMovies = GetAllMovies("ok");
            Movie movie = allMovies.ElementAtOrDefault(id);

            return movie;
        }

        public Movie Update(int id, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
