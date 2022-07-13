using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface IMovieTagsData
    {
        List<movie_tags> GetMovieTags();

        movie_tags GetMovieTag(int id);

        movie_tags AddMovieTag(movie_tags movie_tag);

        movie_tags UpdateMovieTag(movie_tags movie_tag);

        void DeleteMovieTag(movie_tags movie_tag);
    }
}
