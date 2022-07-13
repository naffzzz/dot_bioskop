using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class MovieSchedulesService : IMovieSchedulesService
    {
        private List<movie_schedules> _moviesSchedulesItem;

        public MovieSchedulesService()
        {
            _moviesSchedulesItem = new List<movie_schedules>();
        }

        public List<movie_schedules> GetMovieSchedules()
        {
            return _moviesSchedulesItem;
        }

        public movie_schedules AddMovieSchedules(movie_schedules movie_schedule)
        {
            _moviesSchedulesItem.Add(movie_schedule);
            return movie_schedule;
        }

        public movie_schedules UpdateMovieSchedules(int id, movie_schedules movie_schedule)
        {
            for (var index = _moviesSchedulesItem.Count - 1; index >= 0; index--)
            {
                if (_moviesSchedulesItem[index].id == id)
                {
                    _moviesSchedulesItem[index] = movie_schedule;
                }
            }
            return movie_schedule;
        }

        public string DeleteMovieSchedules(int id)
        {
            for (var index = _moviesSchedulesItem.Count - 1; index >= 0; index--)
            {
                if (_moviesSchedulesItem[index].id == id)
                {
                    _moviesSchedulesItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
