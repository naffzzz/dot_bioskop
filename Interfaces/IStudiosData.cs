using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface IStudiosData
    {
        List<studios> GetStudios();

        studios GetStudio(int id);

        studios AddStudio(studios studio);

        studios UpdateStudio(studios studio);

        studios SoftDeleteStudio(studios studio);

        void DeleteStudio(studios studio);
    }
}
