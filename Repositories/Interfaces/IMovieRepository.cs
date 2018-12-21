using DataModel.Entities;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies(string title);
        Movie GetMovie(int id);
        Movie Add(Movie movie);
        bool Delete(int id);
        Movie Update(int id, Movie movie);
        Movie GetByTitle(string movieTitle);
        int CheckDate(DateTime dateMovie);
    }
}
