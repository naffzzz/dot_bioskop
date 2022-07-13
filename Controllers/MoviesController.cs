using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private IMoviesData _moviesData;

        public MoviesController(IMoviesData moviesData)
        {
            _moviesData = moviesData;
        }


        [HttpGet("/apiNew/movies")]
        public IActionResult getMovies()
        {
            return Ok(_moviesData.GetMovies());
        }

        [HttpGet("/apiNew/movies/{id}")]
        public IActionResult getMovie(int id)
        {
            var movie = _moviesData.GetMovie(id);
            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound("Movie tidak diketemukan");
        }

        [HttpPost("/apiNew/movies")]
        public IActionResult addMovie(movies movie)
        {
            _moviesData.AddMovie(movie);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie.id, movie);

        }

        [HttpDelete("/apiNew/movies/{id}")]
        public IActionResult deleteMovie(int id)
        {
            var movie = _moviesData.GetMovie(id);

            if (movie != null)
            {
                _moviesData.DeleteMovie(movie);
                return Ok("Movie berhasil dihapus");
            }

            return NotFound("Movie tidak diketemukan");
        }

        [HttpPatch("/apiNew/movies/{id}")]
        public IActionResult updateMovie(int id, movies movie)
        {
            var existingMovie = _moviesData.GetMovie(id);

            if (existingMovie != null)
            {
                movie.id = existingMovie.id;
                _moviesData.UpdateMovie(movie);
            }
            return Ok(movie);
        }
    }
}