using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class MovieTagsService : IMovieTagsService
    {
        private List<movie_tags> _moviesTagsItem;

        public MovieTagsService()
        {
            _moviesTagsItem = new List<movie_tags>();
        }

        public List<movie_tags> GetMovieTags()
        {
            return _moviesTagsItem;
        }

        public movie_tags AddMovieTags(movie_tags movie)
        {
            _moviesTagsItem.Add(movie);
            return movie;
        }

        public movie_tags UpdateMovieTags(int id, movie_tags movie)
        {
            for (var index = _moviesTagsItem.Count - 1; index >= 0; index--)
            {
                if (_moviesTagsItem[index].id == id)
                {
                    _moviesTagsItem[index] = movie;
                }
            }
            return movie;
        }

        public string DeleteMovieTags(int id)
        {
            for (var index = _moviesTagsItem.Count - 1; index >= 0; index--)
            {
                if (_moviesTagsItem[index].id == id)
                {
                    _moviesTagsItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
