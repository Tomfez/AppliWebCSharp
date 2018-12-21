using System;
using DataModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace AppliWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        // GET api/movies
        [HttpGet]
        public ActionResult<object> Get(string title)
        {
            try
            {
                return _movieService.GetAllMovies(title);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // GET api/movies/{id}
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            return _movieService.GetMovie(id);
        }

        // POST api/movies
        [HttpPost("")]
        public Movie Post(Movie movie)
        {
            return _movieService.Add(movie);
        }

        // PUT api/movies/{id}
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromBody]Movie movie)
        {
            try
            {
                return _movieService.Update(id, movie);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public ActionResult<object> Delete(int id)
        {
            try
            {
               return _movieService.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
    }
}