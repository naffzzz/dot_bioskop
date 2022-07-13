using dot_bioskop.DBContexts;
using dot_bioskop.Models;
using dot_bioskop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private ILogger _logger;
        private IMoviesService _moviesService;


        public MoviesController(ILogger<MoviesController> logger, IMoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        [HttpGet("/api/movies")]
        public ActionResult<List<movies>> GetMovies()
        {
            return _moviesService.GetMovies();
        }

        [HttpPost("/api/movies")]
        public ActionResult<movies> AddMovies(movies movie)
        {
            _moviesService.AddMovies(movie);
            return movie;
        }

        [HttpPut("/api/movies/{id}")]
        public ActionResult<movies> UpdateMovies(int id, movies movie)
        {
            _moviesService.UpdateMovies(id, movie);
            return movie;
        }

        [HttpDelete("/api/movies/{id}")]
        public ActionResult<string> DeleteMovies(int id)
        {
            _moviesService.DeleteMovies(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}