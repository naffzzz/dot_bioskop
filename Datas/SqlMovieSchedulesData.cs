using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Interfaces;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace dot_bioskop.Datas
{
    public class SqlMovieSchedulesData : IMovieSchedulesData
    {
        private MyDBContext _myDBContext;

        public SqlMovieSchedulesData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public movie_schedules AddMovieSchedule(movie_schedules movie_schedule)
        {
            _myDBContext.movie_schedules.Add(movie_schedule);
            _myDBContext.SaveChanges();
            return movie_schedule;
        }

        public void DeleteMovieSchedule(movie_schedules movie_schedule)
        {
            _myDBContext.movie_schedules.Remove(movie_schedule);
            _myDBContext.SaveChanges();
        }

        public movie_schedules GetMovieSchedule(int id)
        {
            var movie_schedule = _myDBContext.movie_schedules.Where(b => b.id == id).Include("movie").Include("studio").FirstOrDefault(); 
            return movie_schedule;
        }

        public List<movie_schedules> GetMovieSchedules()
        {
            return _myDBContext.movie_schedules.Include("movie").Include("studio").ToList();
        }

        public movie_schedules UpdateMovieSchedule(movie_schedules movie_schedule)
        {
            var existingMovieSchedule = _myDBContext.movie_schedules.Find(movie_schedule.id);
            if(existingMovieSchedule != null)
            {
                existingMovieSchedule.movie_id = movie_schedule.movie_id;
                existingMovieSchedule.studio_id = movie_schedule.studio_id;
                existingMovieSchedule.start_time = movie_schedule.start_time;
                existingMovieSchedule.end_time = movie_schedule.end_time;
                existingMovieSchedule.price = movie_schedule.price;
                existingMovieSchedule.date = movie_schedule.date;
                existingMovieSchedule.updated_at = movie_schedule.updated_at;
                _myDBContext.movie_schedules.Update(existingMovieSchedule);
                _myDBContext.SaveChanges();
            }
            return movie_schedule;
        }

        public movie_schedules SoftDeleteMovieSchedule(movie_schedules movie_schedule)
        {
            var existingMovieSchedule = _myDBContext.movie_schedules.Find(movie_schedule.id);
            if (existingMovieSchedule != null)
            {
                existingMovieSchedule.deleted_at = movie_schedule.deleted_at;
                _myDBContext.movie_schedules.Update(existingMovieSchedule);
                _myDBContext.SaveChanges();
            }
            return movie_schedule;
        }
    }
}
