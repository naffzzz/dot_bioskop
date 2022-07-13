using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface IMovieSchedulesService
    {
        public List<movie_schedules> GetMovieSchedules();

        public movie_schedules AddMovieSchedules(movie_schedules movie);

        public movie_schedules UpdateMovieSchedules(int id, movie_schedules movie);

        public string DeleteMovieSchedules(int id);
    }
}
