using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTagsController : ControllerBase
    {
        private IMovieTagsData _movieTagsData;
        private readonly ILogger _logger;

        public MovieTagsController(ILogger<MovieTagsController> logger, IMovieTagsData movieTagsData)
        {
            _movieTagsData = movieTagsData;
            _logger = logger;
        }


        [HttpGet("/apiNew/movies")]
        public IActionResult getMovieTags()
        {
            _logger.LogInformation("Log accessing all movie tags data");
            return Ok(_movieTagsData.GetMovieTags());
        }

        [HttpGet("/apiNew/movies/{id}")]
        public IActionResult GetMovieTag(int id)
        {
            var movie = _movieTagsData.GetMovieTag(id);
            if (movie != null)
            {
                _logger.LogInformation("Log accessing available specified movie tags data (" + id + ")");
                return Ok(movie);
            }
            else
            {
                _logger.LogInformation("Log accessing unavailable specified movie tags data (" + id + ")");
                return NotFound("Tag Movie tidak diketemukan");
            }
        }

        [HttpPost("/apiNew/movies")]
        public IActionResult AddMovieTag(movie_tags movie_tag)
        {
            movie_tag.created_at = DateTime.Now;
            _logger.LogInformation("Log adding tags movie data");
            _movieTagsData.AddMovieTag(movie_tag);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie_tag.id, movie_tag);

        }

        [HttpDelete("/apiNew/movies/{id}")]
        public IActionResult DeleteMovieTag(int id)
        {
            var movie_tag = _movieTagsData.GetMovieTag(id);

            if (movie_tag != null)
            {
                _logger.LogInformation("Log deleting available specified movie tags data (" + id + ")");
                _movieTagsData.DeleteMovieTag(movie_tag);
                return Ok("Tag Movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable specified movie tags data (" + id + ")");
                return NotFound("Tag Movie tidak diketemukan");
            }
        }

        [HttpPatch("/api/movies/{id}")]
        public IActionResult SoftDeleteMovieTag(int id, movie_tags movie_tag)
        {
            var existingMovieTag = _movieTagsData.GetMovieTag(id);

            if (existingMovieTag != null)
            {
                movie_tag.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified movie tags data (" + id + ")");
                movie_tag.id = existingMovieTag.id;
                _movieTagsData.SoftDeleteMovieTag(movie_tag);
                return Ok(movie_tag);
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified movie tags data (" + id + ")");
                return NotFound("Tag Movie tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/movies/{id}")]
        public IActionResult UpdateMovieTag(int id, movie_tags movie_tag)
        {
            var existingMovieTag = _movieTagsData.GetMovieTag(id);

            if (existingMovieTag != null)
            {
                movie_tag.deleted_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified movie tags data (" + id + ")");
                movie_tag.id = existingMovieTag.id;
                _movieTagsData.UpdateMovieTag(movie_tag);
                return Ok(movie_tag);
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified movie tags data (" + id + ")");
                return NotFound("Tag Movie tidak diketemukan");
            }
        }
    }
}