using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class MoviesService : IMoviesService
    {
        private List<movies> _moviesItem;

        public MoviesService()
        {
            _moviesItem = new List<movies>();
        }

        public List<movies> GetMovies()
        {
            return _moviesItem;
        }

        public movies AddMovies(movies movie)
        {
            _moviesItem.Add(movie);
            return movie;
        }

        public movies UpdateMovies(int id, movies movie)
        {
            for (var index = _moviesItem.Count - 1; index >= 0; index--)
            {
                if (_moviesItem[index].id == id)
                {
                    _moviesItem[index] = movie;
                }
            }
            return movie;
        }

        public string DeleteMovies(int id)
        {
            for (var index = _moviesItem.Count - 1; index >= 0; index--)
            {
                if (_moviesItem[index].id == id)
                {
                    _moviesItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
