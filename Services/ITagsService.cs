using dot_bioskop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Services
{
    public interface ITagsService
    {
        public List<tags> GetTags();

        public tags AddTags(tags tag);

        public tags UpdateTags(int id, tags tag);

        public string DeleteTags(int id);
    }
}
