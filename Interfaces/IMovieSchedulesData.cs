using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface IMovieSchedulesData
    {
        List<movie_schedules> GetMovieSchedules();

        movie_schedules GetMovieSchedule(int id);

        movie_schedules AddMovieSchedule(movie_schedules movie_schedule);

        movie_schedules UpdateMovieSchedule(movie_schedules movie_schedule);
        movie_schedules SoftDeleteMovieSchedule(movie_schedules movie_schedule);

        void DeleteMovieSchedule(movie_schedules movie_schedule);
    }
}
