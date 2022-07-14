using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private ITagsData _tagsData;
        private readonly ILogger _logger;

        public TagsController(ILogger<TagsController> logger, ITagsData tagsData)
        {
            _tagsData = tagsData;
            _logger = logger;
        }


        [HttpGet("/apiNew/tags")]
        public IActionResult GetMovieTags()
        {
            _logger.LogInformation("Log accessing all tags data");
            return Ok(_tagsData.GetTags());
        }

        [HttpGet("/apiNew/tags/{id}")]
        public IActionResult GetMovieTag(int id)
        {
            var movie = _tagsData.GetTag(id);
            if (movie != null)
            {
                _logger.LogInformation("Log accessing available specified tags data");
                return Ok(movie);
            }
            else
            {
                _logger.LogInformation("Log accessing unavailable specified tags data");
                return NotFound("Tag tidak diketemukan");
            }
        }

        [HttpPost("/apiNew/tags")]
        public IActionResult AddMovieTag(tags tag)
        {
            _logger.LogInformation("Log adding tags data");
            _tagsData.AddTag(tag);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tag.id, tag);

        }

        [HttpDelete("/apiNew/tags/{id}")]
        public IActionResult DeleteMovieTag(int id)
        {
            var tag = _tagsData.GetTag(id);

            if (tag != null)
            {
                _logger.LogInformation("Log deleting available specified tags data");
                _tagsData.DeleteTag(tag);
                return Ok("Tag berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable specified tags data");
                return NotFound("Tag tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/tags/{id}")]
        public IActionResult UpdateMovieTag(int id, tags tag)
        {
            var existingTag = _tagsData.GetTag(id);

            if (existingTag != null)
            {
                _logger.LogInformation("Log updating available specified tags data");
                tag.id = existingTag.id;
                _tagsData.UpdateTag(tag);
                return Ok(tag);
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified tags data");
                return NotFound("Tag tidak diketemukan");
            }
        }
    }
}