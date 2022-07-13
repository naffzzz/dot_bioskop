using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dot_bioskop.Interfaces;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Datas
{
    public class SqlMovieSchedulesData : IMovieSchedulesData
    {
        private MyDBContext _myDBContext;

        public SqlMovieSchedulesData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public movie_schedules AddUser(movie_schedules movie_schedule)
        {
            _myDBContext.users.Add(movie_schedule);
            _myDBContext.SaveChanges();
            return movie_schedule;
        }

        public void DeleteUser(movie_schedules movie_schedule)
        {
            _myDBContext.users.Remove(movie_schedule);
            _myDBContext.SaveChanges();
        }

        public movie_schedules GetUser(int id)
        {
            var movie_schedule = _myDBContext.users.Find(id);
            return movie_schedule;
        }

        public List<movie_schedules> GetUsers()
        {
            return _myDBContext.movie_schedules.ToList();
        }

        public movie_schedules UpdateUser(movie_schedules movie_schedule)
        {
            var existingMovieSchedule = _myDBContext.users.Find(movie_schedule.id);
            if(existingUser != null)
            {
                existingMovieSchedule.name = movie_schedule.name;
                _myDBContext.users.Update(existingMovieSchedule);
                _myDBContext.SaveChanges();
            }
            return movie_schedule;
        }
    }
}
