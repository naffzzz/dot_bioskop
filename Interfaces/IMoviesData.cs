using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface IMoviesData
    {
        List<movies> GetMovies();

        movies GetMovie(int id);

        movies AddMovie(movies movie);

        movies UpdateMovie(movies movie);

        void DeleteMovie(movies movie);
    }
}
