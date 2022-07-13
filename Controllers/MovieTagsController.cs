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
    public class MovieTagsController : ControllerBase
    {
        private ILogger _logger;
        private IMovieTagsService _movieTagsService;


        public MovieTagsController(ILogger<MovieTagsController> logger, IMovieTagsService movieTagsService)
        {
            _logger = logger;
            _movieTagsService = movieTagsService;
        }

        [HttpGet("/api/movietags")]
        public ActionResult<List<movie_tags>> GetMovieTags()
        {
            return _movieTagsService.GetMovieTags();
        }

        [HttpPost("/api/movietags")]
        public ActionResult<movie_tags> AddMovieTags(movie_tags movie_tag)
        {
            _movieTagsService.AddMovieTags(movie_tag);
            return movie_tag;
        }

        [HttpPut("/api/movietags/{id}")]
        public ActionResult<movie_tags> UpdateMovieTags(int id, movie_tags movie_tag)
        {
            _movieTagsService.UpdateMovieTags(id, movie_tag);
            return movie_tag;
        }

        [HttpDelete("/api/movietags/{id}")]
        public ActionResult<string> DeleteMovieTags(int id)
        {
            _movieTagsService.DeleteMovieTags(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}