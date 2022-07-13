using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface IMovieTagsService
    {
        public List<movie_tags> GetMovieTags();

        public movie_tags AddMovieTags(movie_tags movie_tag);

        public movie_tags UpdateMovieTags(int id, movie_tags movie_tag);

        public string DeleteMovieTags(int id);
    }
}
