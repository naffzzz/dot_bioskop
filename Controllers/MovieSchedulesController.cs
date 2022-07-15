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
    public class MovieSchedulesController : ControllerBase
    {
        private IMovieSchedulesData _movieSchedulesData;
        private readonly ILogger _logger;

        public MovieSchedulesController(ILogger<MovieSchedulesController> logger, IMovieSchedulesData movieSchedulesData)
        {
            _movieSchedulesData = movieSchedulesData;
            _logger = logger;
        }


        [HttpGet("/apiNew/movieschedules")]
        public IActionResult GetMovieSchedules()
        {
            _logger.LogInformation("Log accessing all movie schedules data");
            return Ok(_movieSchedulesData.GetMovieSchedules());
        }

        [HttpGet("/apiNew/movieschedules/{id}")]
        public IActionResult GetMovieSchedule(int id)
        {
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

        [HttpPost("/apiNew/movieschedules")]
        public IActionResult AddMovieSchedule(movie_schedules movie_schedule)
        {
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

        [HttpDelete("/apiNew/movieschedules/{id}")]
        public IActionResult DeleteMovieSchedule(int id)
        {
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

        [HttpPatch("/api/movieschedules/{id}")]
        public IActionResult SoftDeleteMovieSchedule(int id)
        {
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

        [HttpPatch("/apiNew/movieschedules/{id}")]
        public IActionResult UpdateMovieSchedules(int id, movie_schedules movie_schedule)
        {
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