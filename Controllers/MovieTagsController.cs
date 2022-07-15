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
    public class MovieTagsController : ControllerBase
    {
        private IMovieTagsData _movieTagsData;
        private readonly ILogger _logger;

        public MovieTagsController(ILogger<MovieTagsController> logger, IMovieTagsData movieTagsData)
        {
            _movieTagsData = movieTagsData;
            _logger = logger;
        }


        [HttpGet("/apiNew/movietags")]
        public IActionResult getMovieTags()
        {
            _logger.LogInformation("Log accessing all movie tags data");
            return Ok(_movieTagsData.GetMovieTags());
        }

        [HttpGet("/apiNew/movietags/{id}")]
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

        [HttpPost("/apiNew/movietags")]
        public IActionResult AddMovieTag(movie_tags movie_tag)
        {
            MovieTagsValidation Obj = new MovieTagsValidation();
            movie_tag.created_at = DateTime.Now;
            ValidationResult Result = Obj.Validate(movie_tag);
            if (Result.IsValid)
            {
                _logger.LogInformation("Log adding tags movie data");
                _movieTagsData.AddMovieTag(movie_tag);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie_tag.id, movie_tag);
            }
            else
            {
                return BadRequest(Result);
            }
        }

        [HttpDelete("/apiNew/movietags/{id}")]
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

        [HttpPatch("/api/movietags/{id}")]
        public IActionResult SoftDeleteMovieTag(int id, movie_tags movie_tag)
        {
            var existingMovieTag = _movieTagsData.GetMovieTag(id);

            if (existingMovieTag != null)
            {
                movie_tag.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified movie tags data (" + id + ")");
                movie_tag.id = existingMovieTag.id;
                _movieTagsData.SoftDeleteMovieTag(movie_tag);
                return Ok("Tag Movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified movie tags data (" + id + ")");
                return NotFound("Tag Movie tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/movietags/{id}")]
        public IActionResult UpdateMovieTag(int id, movie_tags movie_tag)
        {
            var existingMovieTag = _movieTagsData.GetMovieTag(id);

            if (existingMovieTag != null)
            {
                movie_tag.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified movie tags data (" + id + ")");
                movie_tag.id = existingMovieTag.id;
                _movieTagsData.UpdateMovieTag(movie_tag);
                return Ok("Tag movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified movie tags data (" + id + ")");
                return NotFound("Tag movie tidak diketemukan");
            }
        }
    }
}