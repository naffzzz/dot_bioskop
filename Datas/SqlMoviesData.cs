using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Datas
{
    public class SqlMoviesData
    {
        private MyDBContext _myDBContext;

        public SqlMoviesData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public movies AddMovie(movies movie)
        {
            _myDBContext.movies.Add(movie);
            _myDBContext.SaveChanges();
            return movie;
        }

        public void DeleteMovie(movies movie)
        {
            _myDBContext.movies.Remove(movie);
            _myDBContext.SaveChanges();
        }

        public movies GetMovie(int id)
        {
            var movie = _myDBContext.movies.Where(b => b.id == id).FirstOrDefault();
            return movie;
        }

        public List<movies> GetMovies()
        {
            return _myDBContext.movies.ToList();
        }
        public movies SoftDeleteMovie(movies movie)
        {
            var existingMovie = _myDBContext.movies.Where(b => b.id == movie.id).FirstOrDefault();
            if (existingMovie != null)
            {
                existingMovie.deleted_at = movie.deleted_at;
                _myDBContext.movies.Update(existingMovie);
                _myDBContext.SaveChanges();
            }
            return movie;
        }

        public movies UpdateMovie(movies movie)
        {
            var existingMovie = _myDBContext.movies.Where(b => b.id == movie.id).FirstOrDefault();
            if (existingMovie != null)
            {
                existingMovie.title = movie.title;
                existingMovie.overview = movie.overview;
                existingMovie.poster = movie.poster;
                existingMovie.play_until = movie.play_until;
                existingMovie.updated_at = movie.updated_at;
                _myDBContext.movies.Update(existingMovie);
                _myDBContext.SaveChanges();
            }
            return movie;
        }
    }
}
