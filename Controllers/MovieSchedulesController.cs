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
    public class MovieSchedulesController : ControllerBase
    {
        private readonly ILogger _logger;
        private MyDBContext _myDBContext;

        public MovieSchedulesController(ILogger<MovieSchedulesController> logger, MyDBContext myDBContext)
        {
            _logger = logger;
            _myDBContext = myDBContext;
        }

        [AllowAnonymous]
        [HttpGet("/apiNew/movieschedules")]
        public IActionResult GetMovieSchedules()
        {
            var _movieSchedulesData = new SqlMovieSchedulesData(_myDBContext);
            _logger.LogInformation("Log accessing all movie schedules data");
            return Ok(_movieSchedulesData.GetMovieSchedules());
        }

        [AllowAnonymous]
        [HttpGet("/apiNew/movieschedules/{id}")]
        public IActionResult GetMovieSchedule(int id)
        {
            var _movieSchedulesData = new SqlMovieSchedulesData(_myDBContext);
            var movie_schedule = _movieSchedulesData.GetMovieSchedule(id);
            if (movie_schedule != null)
            {
                _logger.LogInformation("Log accessing avalaible specified movie schedules data (" + id + ")");
                return Ok(movie_schedule);
            }
            else
            {
                _logger.LogInformation("Log accessing unavalaible specified movie schedules data (" + id + ")");
                return NotFound("Jadwal movie tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost("/apiNew/movieschedules")]
        public IActionResult AddMovieSchedule(movie_schedules movie_schedule)
        {
            var _movieSchedulesData = new SqlMovieSchedulesData(_myDBContext);
            MovieSchedulesValidation Obj = new MovieSchedulesValidation();
            movie_schedule.created_at = DateTime.Now;
            ValidationResult Result = Obj.Validate(movie_schedule);
            if (Result.IsValid)
            {
                _logger.LogInformation("Log adding movie schedules data");
                _movieSchedulesData.AddMovieSchedule(movie_schedule);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie_schedule.id, movie_schedule);
            }
            else
            {
                return BadRequest(Result);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("/apiNew/movieschedules/{id}")]
        public IActionResult DeleteMovieSchedule(int id)
        {
            var _movieSchedulesData = new SqlMovieSchedulesData(_myDBContext);
            var movie_schedule = _movieSchedulesData.GetMovieSchedule(id);

            if (movie_schedule != null)
            {
                _logger.LogInformation("Log deleting avalaible specified movie schedules data (" + id + ")");
                _movieSchedulesData.DeleteMovieSchedule(movie_schedule);
                return Ok("Jadwal movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log deleting unavalaible specified movie schedules data (" + id + ")");
                return NotFound("Jadwal movie tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("/api/movieschedules/{id}")]
        public IActionResult SoftDeleteMovieSchedule(int id)
        {
            var _movieSchedulesData = new SqlMovieSchedulesData(_myDBContext);
            var movie_schedule = _movieSchedulesData.GetMovieSchedule(id);

            if (movie_schedule != null)
            {
                movie_schedule.deleted_at = DateTime.Now;
                _logger.LogInformation("Log soft deleting avalaible specified movie schedules data (" + id + ")");
                _movieSchedulesData.SoftDeleteMovieSchedule(movie_schedule);
                return Ok("Jadwal movie berhasil dihapus");
            }
            else
            {
                _logger.LogInformation("Log soft deleting unavalaible specified movie schedules data (" + id + ")");
                return NotFound("Jadwal movie tidak diketemukan");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("/apiNew/movieschedules/{id}")]
        public IActionResult UpdateMovieSchedules(int id, movie_schedules movie_schedule)
        {
            var _movieSchedulesData = new SqlMovieSchedulesData(_myDBContext);
            var existingMovieSchedule = _movieSchedulesData.GetMovieSchedule(id);

            if (existingMovieSchedule != null)
            {
                movie_schedule.updated_at = DateTime.Now;
                _logger.LogInformation("Log updating avalaible specified movie schedules data (" + id + ")");
                movie_schedule.id = existingMovieSchedule.id;
                _movieSchedulesData.UpdateMovieSchedule(movie_schedule);
                return Ok("Jadwal movie berhasil diperbarui");
            }
            else
            {
                _logger.LogInformation("Log updating unavalaible specified movie schedules data (" + id + ")");
                return NotFound("Jadwal movie tidak diketemukan");
            }
        }
    }
}