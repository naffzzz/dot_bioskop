using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private ITagsData _tagsData;

        public TagsController(ITagsData tagsData)
        {
            _tagsData = tagsData;
        }


        [HttpGet("/apiNew/tags")]
        public IActionResult getMovieTags()
        {
            return Ok(_tagsData.GetTags());
        }

        [HttpGet("/apiNew/tags/{id}")]
        public IActionResult getMovieTag(int id)
        {
            var movie = _tagsData.GetTag(id);
            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound("Tag tidak diketemukan");
        }

        [HttpPost("/apiNew/tags")]
        public IActionResult addMovieTag(tags tag)
        {
            _tagsData.AddTag(tag);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tag.id, tag);

        }

        [HttpDelete("/apiNew/tags/{id}")]
        public IActionResult deleteMovieTag(int id)
        {
            var tag = _tagsData.GetTag(id);

            if (tag != null)
            {
                _tagsData.DeleteTag(tag);
                return Ok("Tag berhasil dihapus");
            }

            return NotFound("Tag tidak diketemukan");
        }

        [HttpPatch("/apiNew/tags/{id}")]
        public IActionResult updateMovieTag(int id, tags tag)
        {
            var existingTag = _tagsData.GetTag(id);

            if (existingTag != null)
            {
                tag.id = existingTag.id;
                _tagsData.UpdateTag(tag);
            }
            return Ok(tag);
        }
    }
}