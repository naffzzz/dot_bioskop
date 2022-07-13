using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudiosController : ControllerBase
    {
        private IStudiosData _studiosData;

        public StudiosController(IStudiosData studiosData)
        {
            _studiosData = studiosData;
        }


        [HttpGet("/apiNew/studios")]
        public IActionResult getStudio()
        {
            return Ok(_studiosData.GetStudios());
        }

        [HttpGet("/apiNew/studios/{id}")]
        public IActionResult getStudio(int id)
        {
            var studio = _studiosData.GetStudio(id);
            if (studio != null)
            {
                return Ok(studio);
            }

            return NotFound("Studio tidak diketemukan");
        }

        [HttpPost("/apiNew/studios")]
        public IActionResult addStudio(studios studio)
        {
            _studiosData.AddStudio(studio);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + studio.id, studio);

        }

        [HttpDelete("/apiNew/studios/{id}")]
        public IActionResult deleteStudio(int id)
        {
            var studio = _studiosData.GetStudio(id);

            if (studio != null)
            {
                _studiosData.DeleteStudio(studio);
                return Ok("Studio berhasil dihapus");
            }

            return NotFound("Studio tidak diketemukan");
        }

        [HttpPatch("/apiNew/studios/{id}")]
        public IActionResult updateStudio(int id, studios studio)
        {
            var existingStudio = _studiosData.GetStudio(id);

            if (existingStudio != null)
            {
                studio.id = existingStudio.id;
                _studiosData.UpdateStudio(studio);
            }
            return Ok(studio);
        }
    }
}