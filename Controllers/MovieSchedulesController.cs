using dot_bioskop.Models;
using dot_bioskop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dot_bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieSchedulesController : ControllerBase
    {
        private IMovieSchedulesData _movieSchedulesData;

        public MovieSchedulesController(IMovieSchedulesData movieSchedulesData)
        {
            _movieSchedulesData = movieSchedulesData;
        }


        [HttpGet("/apiNew/movieschedules")]
        public IActionResult getMovieSchedules()
        {
            return Ok(_movieSchedulesData.GetMovieSchedules());
        }

        [HttpGet("/apiNew/movieschedules/{id}")]
        public IActionResult getMovieSchedule(int id)
        {
            var movie_schedule = _movieSchedulesData.GetMovieSchedule(id);
            if (movie_schedule != null)
            {
                return Ok(movie_schedule);
            }

            return NotFound("Jadwal movie tidak diketemukan");
        }

        [HttpPost("/apiNew/movieschedules")]
        public IActionResult addMovieSchedule(movie_schedules movie_schedule)
        {
            _movieSchedulesData.AddMovieSchedule(movie_schedule);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie_schedule.id, movie_schedule);

        }

        [HttpDelete("/apiNew/movieschedules/{id}")]
        public IActionResult deleteMovieSchedule(int id)
        {
            var movie_schedule = _movieSchedulesData.GetMovieSchedule(id);

            if (movie_schedule != null)
            {
                _movieSchedulesData.DeleteMovieSchedule(movie_schedule);
                return Ok("Jadwal movie berhasil dihapus");
            }

            return NotFound("Jadwal movie tidak diketemukan");
        }

        [HttpPatch("/apiNew/movieschedules/{id}")]
        public IActionResult updateMovieSchedules(int id, movie_schedules movie_schedule)
        {
            var existingMovieSchedule = _movieSchedulesData.GetMovieSchedule(id);

            if (existingMovieSchedule != null)
            {
                movie_schedule.id = existingMovieSchedule.id;
                _movieSchedulesData.UpdateMovieSchedule(movie_schedule);
            }
            return Ok(movie_schedule);
        }
    }
}