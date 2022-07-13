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
    public class TagsController : ControllerBase
    {
        private ILogger _logger;
        private ITagsService _tagsService;


        public TagsController(ILogger<TagsController> logger, ITagsService tagsService)
        {
            _logger = logger;
            _tagsService = tagsService;
        }

        [HttpGet("/api/tags")]
        public ActionResult<List<tags>> GetTags()
        {
            return _tagsService.GetTags();
        }

        [HttpPost("/api/tags")]
        public ActionResult<tags> AddTags(tags tag)
        {
            _tagsService.AddTags(tag);
            return tag;
        }

        [HttpPut("/api/tags/{id}")]
        public ActionResult<tags> UpdateTags(int id, tags tag)
        {
            _tagsService.UpdateTags(id, tag);
            return tag;
        }

        [HttpDelete("/api/tags/{id}")]
        public ActionResult<string> DeleteTags(int id)
        {
            _tagsService.DeleteTags(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}