using System;
using System.Collections.Generic;
using DataModel.Entities;
using Services.Interfaces;

namespace Services.Repositories
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository mr)
        {
            this._movieRepository = mr;
        }

        public Movie Add(Movie movie)
        {
            var dbMovie = _movieRepository.GetByTitle(movie.Title);

            if (dbMovie == null)
            {
                return _movieRepository.Add(movie);
            }

            return null;
        }

        public string Delete(int id)
        {
            var movieDeleted = _movieRepository.Delete(id);

            if(!movieDeleted)
            {
                throw new Exception("Ce film n'existe pas");
            }

            _movieRepository.Delete(id);
            return "Le film a bien été supprimé";
        }

        public List<Movie> GetAllMovies(string title)
        {
            var listMovies = _movieRepository.GetAllMovies(title);

            if (listMovies.Count == 0)
            {
                throw new Exception("Aucun film n'a été trouvé avec ce titre");
            }

            return listMovies;
        }

        public Movie GetMovie(int id)
        {
            return _movieRepository.GetMovie(id);
        }

        public Movie GetMovieByTitle(string title)
        {
            return _movieRepository.GetByTitle(title);
        }

        public Movie Update(int id, Movie movie)
        {
            var titleMovie = _movieRepository.GetByTitle(movie.Title);
            var dateMovie = _movieRepository.CheckDate(movie.ReleasedDate);

            if (titleMovie == null && dateMovie > 1980)
            {
                return _movieRepository.Update(id, movie);
            }
            else if (titleMovie != null)
            {
                throw new Exception("Un film existe déjà avec ce titre");
            }
            else if (dateMovie < 1980)
            {
                throw new Exception("L'année du film doit être supérieure à 1980");
            }
            else
            {
                return null;
            }
        }

    }
}
