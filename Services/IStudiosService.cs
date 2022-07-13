using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface IStudiosService
    {
        public List<studios> GetStudios();

        public studios AddStudios(studios studio);

        public studios UpdateStudios(int id, studios studio);

        public string DeleteStudios(int id);
    }
}
