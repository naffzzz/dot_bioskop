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
    public class StudiosController : ControllerBase
    {
        private ILogger _logger;
        private IStudiosService _studiosService;


        public StudiosController(ILogger<StudiosController> logger, IStudiosService studiosService)
        {
            _logger = logger;
            _studiosService = studiosService;
        }

        [HttpGet("/api/studios")]
        public ActionResult<List<studios>> GetStudios()
        {
            return _studiosService.GetStudios();
        }

        [HttpPost("/api/studios")]
        public ActionResult<studios> AddStudios(studios studio)
        {
            _studiosService.AddStudios(studio);
            return studio;
        }

        [HttpPut("/api/studios/{id}")]
        public ActionResult<studios> UpdateStudios(int id, studios studio)
        {
            _studiosService.UpdateStudios(id, studio);
            return studio;
        }

        [HttpDelete("/api/studios/{id}")]
        public ActionResult<string> DeleteStudios(int id)
        {
            _studiosService.DeleteStudios(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}