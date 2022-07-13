using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface IMoviesService
    {
        public List<movies> GetMovies();

        public movies AddMovies(movies movie);

        public movies UpdateMovies(int id, movies movie);

        public string DeleteMovies(int id);
    }
}
