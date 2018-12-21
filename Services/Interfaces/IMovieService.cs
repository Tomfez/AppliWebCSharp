using DataModel.Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies(string title);
        Movie GetMovie(int id);
        Movie Add(Movie movie);
        string Delete(int id);
        Movie Update(int id, Movie movie);
        Movie GetMovieByTitle(string title);
    }
}
