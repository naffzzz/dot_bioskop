using System.Collections.Generic;
using dot_bioskop.Models;

namespace dot_bioskop.Interfaces
{
    public interface ITagsData
    {
        List<tags> GetTags();

        tags GetTag(int id);

        tags AddTag(tags tag);

        tags UpdateTag(tags tag);

        tags SoftDeleteTag(tags tag);

        void DeleteTag(tags tag);
    }
}
