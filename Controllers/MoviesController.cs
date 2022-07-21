using dot_bioskop.Models;
using dot_bioskop.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using dot_bioskop.Datas;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger _logger;
        private MyDBContext _myDBContext;

        public MoviesController(ILogger<MoviesController> logger, MyDBContext myDBContext)
        {
            _logger = logger;
            _myDBContext = myDBContext;
        }

        [AllowAnonymous]
        [HttpGet("/apiNew/movies")]
        public IActionResult GetMovies()
        {
            var _moviesData = new SqlMoviesData(_myDBContext);
            _logger.LogInformation("Log accessing all movies data");
            return Ok(_moviesData.GetMovies());
        }

        [AllowAnonymous]
        [HttpGet("/apiNew/movies/{id}")]
        public IActionResult GetMovie(int id)
        {
            var _moviesData = new SqlMoviesData(_myDBContext);
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

        [Authorize(Roles = "1")]
        [HttpPost("/apiNew/movies")]
        public IActionResult AddMovie(movies movie)
        {
            var _moviesData = new SqlMoviesData(_myDBContext);
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

        [Authorize(Roles = "1")]
        [HttpDelete("/apiNew/movies/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var _moviesData = new SqlMoviesData(_myDBContext);
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

        [Authorize(Roles = "1")]
        [HttpPatch("/api/movies/{id}")]
        public IActionResult SoftDeleteMovie(int id)
        {
            var _moviesData = new SqlMoviesData(_myDBContext);
            var existingMovie = _moviesData.GetMovie(id);

            if (existingMovie != null)
            {
                existingMovie.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified movies data (" + id + ")");
                _moviesData.SoftDeleteMovie(existingMovie);
                return Ok("Movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified movies data (" + id + ")");
                return NotFound("Movie tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("/apiNew/movies/{id}")]
        public IActionResult UpdateMovie(int id, movies movie)
        {
            var _moviesData = new SqlMoviesData(_myDBContext);
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