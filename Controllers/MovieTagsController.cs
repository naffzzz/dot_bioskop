using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTagsController : ControllerBase
    {
        private IMovieTagsData _movieTagsData;

        public MovieTagsController(IMovieTagsData movieTagsData)
        {
            _movieTagsData = movieTagsData;
        }


        [HttpGet("/apiNew/movies")]
        public IActionResult getMovieTags()
        {
            return Ok(_movieTagsData.GetMovieTags());
        }

        [HttpGet("/apiNew/movies/{id}")]
        public IActionResult getMovieTag(int id)
        {
            var movie = _movieTagsData.GetMovieTag(id);
            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound("Tag Movie tidak diketemukan");
        }

        [HttpPost("/apiNew/movies")]
        public IActionResult addMovieTag(movie_tags movie_tag)
        {
            _movieTagsData.AddMovieTag(movie_tag);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie_tag.id, movie_tag);

        }

        [HttpDelete("/apiNew/movies/{id}")]
        public IActionResult deleteMovieTag(int id)
        {
            var movie_tag = _movieTagsData.GetMovieTag(id);

            if (movie_tag != null)
            {
                _movieTagsData.DeleteMovieTag(movie_tag);
                return Ok("Tag Movie berhasil dihapus");
            }

            return NotFound("Tag Movie tidak diketemukan");
        }

        [HttpPatch("/apiNew/movies/{id}")]
        public IActionResult updateMovieTag(int id, movie_tags movie_tag)
        {
            var existingMovieTag = _movieTagsData.GetMovieTag(id);

            if (existingMovieTag != null)
            {
                movie_tag.id = existingMovieTag.id;
                _movieTagsData.UpdateMovieTag(movie_tag);
            }
            return Ok(movie_tag);
        }
    }
}