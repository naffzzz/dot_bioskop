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
    public class StudiosController : ControllerBase
    {
        private readonly ILogger _logger;
        private MyDBContext _myDBContext;

        public StudiosController(ILogger<StudiosController> logger, MyDBContext myDBContext)
        {
            _logger = logger;
            _myDBContext = myDBContext;
        }

        [AllowAnonymous]
        [HttpGet("/apiNew/studios")]
        public IActionResult GetStudio()
        {
            var _studiosData = new SqlStudiosData(_myDBContext);
            _logger.LogInformation("Log accessing all studios data");
            return Ok(_studiosData.GetStudios());
        }

        [AllowAnonymous]
        [HttpGet("/apiNew/studios/{id}")]
        public IActionResult GetStudio(int id)
        {
            var _studiosData = new SqlStudiosData(_myDBContext);
            var studio = _studiosData.GetStudio(id);
            if (studio != null)
            {
                _logger.LogInformation("Log accessing available specified studios data (" + id + ")");
                return Ok(studio);
            }
            else
            {
                _logger.LogInformation("Log accessing unavailable specified studios data (" + id + ")");
                return NotFound("Studio tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost("/apiNew/studios")]
        public IActionResult AddStudio(studios studio)
        {
            var _studiosData = new SqlStudiosData(_myDBContext);
            StudiosValidation Obj = new StudiosValidation();
            studio.created_at = DateTime.Now;
            ValidationResult Result = Obj.Validate(studio);
            if (Result.IsValid)
            {
                _logger.LogInformation("Log adding studios data");
                _studiosData.AddStudio(studio);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + studio.id, studio);
            }
            else
            {
                return BadRequest(Result);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("/apiNew/studios/{id}")]
        public IActionResult DeleteStudio(int id)
        {
            var _studiosData = new SqlStudiosData(_myDBContext);
            var studio = _studiosData.GetStudio(id);

            if (studio != null)
            {
                _logger.LogInformation("Log deleting available specified studios data (" + id + ")");
                _studiosData.DeleteStudio(studio);
                return Ok("Studio berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavailable specified studios data (" + id + ")");
                return NotFound("Studio tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("/api/studios/{id}")]
        public IActionResult SoftDeleteStudio(int id)
        {
            var _studiosData = new SqlStudiosData(_myDBContext);
            var existingStudio = _studiosData.GetStudio(id);

            if (existingStudio != null)
            {
                existingStudio.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting available specified studios data (" + id + ")");
                _studiosData.SoftDeleteStudio(existingStudio);
                return Ok("Studio berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavailable specified studios data (" + id + ")");
                return NotFound("Studio tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("/apiNew/studios/{id}")]
        public IActionResult UpdateStudio(int id, studios studio)
        {
            var _studiosData = new SqlStudiosData(_myDBContext);
            var existingStudio = _studiosData.GetStudio(id);

            if (existingStudio != null)
            {
                studio.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating available specified studios data (" + id + ")");
                studio.id = existingStudio.id;
                _studiosData.UpdateStudio(studio);
                return Ok("Studio berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log updating unavailable specified studios data (" + id + ")");
                return NotFound("Studio tidak diketemukan");
            }
        }
    }
}