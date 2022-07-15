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
    public class TagsController : ControllerBase
    {
        private ITagsData _tagsData;
        private readonly ILogger _logger;
        private readonly TagsValidation _tagsValidation;

        public TagsController(ILogger<TagsController> logger, ITagsData tagsData)
        {
            _tagsData = tagsData;
            _logger = logger;
        }


        [HttpGet("/apiNew/tags")]
        public IActionResult GetTags()
        {
            _logger.LogInformation("Log accessing all tags data");
            return Ok(_tagsData.GetTags());
        }

        [HttpGet("/apiNew/tags/{id}")]
        public IActionResult GetTag(int id)
        {
            var movie = _tagsData.GetTag(id);
            if (movie != null)
            {
                _logger.LogInformation("Log accessing available specified tags data (" + id + ")");
                return Ok(movie);
            }
            else
            {
                _logger.LogInformation("Log accessing unavailable specified tags data (" + id + ")");
                return NotFound("Tag tidak diketemukan");
            }
        }

        [HttpPost("/apiNew/tags")]
        public IActionResult AddTag(tags tag)
        {
            TagsValidation Obj = new TagsValidation();
            tag.created_at = DateTime.Now;
            ValidationResult Result = Obj.Validate(tag);
            if (Result.IsValid)
            {
                _logger.LogInformation("Log adding tags data");
                _tagsData.AddTag(tag);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tag.id, tag);
            }
            else
            {
                return BadRequest(Result);
            }
        }

        [HttpDelete("/apiNew/tags/{id}")]
        public IActionResult DeleteTag(int id)
        {
            var tag = _tagsData.GetTag(id);

            if (tag != null)
            {
                _logger.LogInformation("Log deleting available specified tags data (" + id + ")");
                _tagsData.DeleteTag(tag);
                return Ok("Tag berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable specified tags data (" + id + ")");
                return NotFound("Tag tidak diketemukan");
            }
        }

        [HttpPatch("/api/tags/{id}")]
        public IActionResult SoftDeleteTag(int id, tags tag)
        {
            var existingTag = _tagsData.GetTag(id);

            if (existingTag != null)
            {
                tag.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified tags data (" + id + ")");
                tag.id = existingTag.id;
                _tagsData.SoftDeleteTag(tag);
                return Ok("Tag berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified tags data (" + id + ")");
                return NotFound("Tag tidak diketemukan");
            }
        }

        [HttpPatch("/apiNew/tags/{id}")]
        public IActionResult UpdateTag(int id, tags tag)
        {
            var existingTag = _tagsData.GetTag(id);

            if (existingTag != null)
            {
                tag.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified tags data (" + id + ")");
                tag.id = existingTag.id;
                _tagsData.UpdateTag(tag);
                return Ok("Tag berhasil diperbarui");
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified tags data (" + id + ")");
                return NotFound("Tag tidak diketemukan");
            }
        }
    }
}