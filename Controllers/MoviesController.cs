using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using dot_bioskop.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using FluentValidation.Results;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private IMoviesData _moviesData;
        private readonly ILogger _logger;

        public MoviesController(ILogger<MoviesController> logger, IMoviesData moviesData)
        {
            _moviesData = moviesData;
            _logger = logger;
        }


        [HttpGet("/apiNew/movies")]
        public IActionResult GetMovies()
        {
            _logger.LogInformation("Log accessing all movies data");
            return Ok(_moviesData.GetMovies());
        }

        [HttpGet("/apiNew/movies/{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _moviesData.GetMovie(id);
            if (movie != null)
            {
                _logger.LogInformation("Log accessing available specified movies data (" + id + ")");
                return Ok(movie);
            }
            else
            {
                _logger.LogInformation("Log accessing available specified movies data (" + id + ")");
                return NotFound("Movie tidak diketemukan");
            }
        }

        [HttpPost("/apiNew/movies")]
        public IActionResult AddMovie(movies movie)
        {
            MoviesValidation Obj = new MoviesValidation();
            movie.created_at = DateTime.Now;
            ValidationResult Result = Obj.Validate(movie);
            if (Result.IsValid)
            {
                _logger.LogInformation("Log adding movies data");
                _moviesData.AddMovie(movie);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie.id, movie);
            }
            else
            {
                return BadRequest(Result);
            }
        }

        [HttpDelete("/apiNew/movies/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _moviesData.GetMovie(id);

            if (movie != null)
            {
                _logger.LogInformation("Log deleting available specified movies data (" + id + ")");
                _moviesData.DeleteMovie(movie);
                return Ok("Movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable specified movies data (" + id + ")");
                return NotFound("Movie tidak diketemukan");
            }
        }

        [HttpPatch("/api/movies/{id}")]
        public IActionResult SoftDeleteMovie(int id, movies movie)
        {
            var existingMovie = _moviesData.GetMovie(id);

            if (existingMovie != null)
            {
                movie.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified movies data (" + id + ")");
                movie.id = existingMovie.id;
                _moviesData.SoftDeleteMovie(movie);
                return Ok("Movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified movies data (" + id + ")");
                return NotFound("Movie tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/movies/{id}")]
        public IActionResult UpdateMovie(int id, movies movie)
        {
            var existingMovie = _moviesData.GetMovie(id);

            if (existingMovie != null)
            {
                movie.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified movies data (" + id + ")");
                movie.id = existingMovie.id;
                _moviesData.UpdateMovie(movie);
                return Ok("Movie berhasil diperbarui");
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified movies data (" + id + ")");
                return NotFound("Movie tidak diketemukan");
            }
        }
    }
}