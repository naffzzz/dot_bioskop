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
    public class MovieSchedulesController : ControllerBase
    {
        private ILogger _logger;
        private IMovieSchedulesService _movieSchedulesService;


        public MovieSchedulesController(ILogger<MovieSchedulesController> logger, IMovieSchedulesService movieSchedulesService)
        {
            _logger = logger;
            _movieSchedulesService = movieSchedulesService;
        }

        [HttpGet("/api/movieschedules")]
        public ActionResult<List<movie_schedules>> GetMovieSchedules()
        {
            return _movieSchedulesService.GetMovieSchedules();
        }

        [HttpPost("/api/movieschedules")]
        public ActionResult<movie_schedules> AddMovieSchedules(movie_schedules movie_schedule)
        {
            _movieSchedulesService.AddMovieSchedules(movie_schedule);
            return movie_schedule;
        }

        [HttpPut("/api/movieschedules/{id}")]
        public ActionResult<movie_schedules> UpdateMovieSchedules(int id, movie_schedules movie_schedule)
        {
            _movieSchedulesService.UpdateMovieSchedules(id, movie_schedule);
            return movie_schedule;
        }

        [HttpDelete("/api/movieschedules/{id}")]
        public ActionResult<string> DeleteMovieSchedules(int id)
        {
            _movieSchedulesService.DeleteMovieSchedules(id);
            //_logger.LogInformation("users", _usersService);
            return id.ToString();
        }
    }
}