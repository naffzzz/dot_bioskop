using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Interfaces;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Datas
{
    public class SqlTagsData : ITagsData
    {
        private MyDBContext _myDBContext;

        public SqlTagsData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public tags AddTag(tags movie_schedule)
        {
            _myDBContext.tags.Add(movie_schedule);
            _myDBContext.SaveChanges();
            return movie_schedule;
        }

        public void DeleteTag(tags movie_schedule)
        {
            _myDBContext.tags.Remove(movie_schedule);
            _myDBContext.SaveChanges();
        }

        public tags GetTag(int id)
        {
            var movie_schedule = _myDBContext.tags.Find(id);
            return movie_schedule;
        }

        public List<tags> GetTags()
        {
            return _myDBContext.tags.ToList();
        }

        public tags UpdateTag(tags tag)
        {
            var existingTag = _myDBContext.tags.Find(tag.id);
            if(existingTag != null)
            {
                existingTag.name = tag.name;
                _myDBContext.tags.Update(existingTag);
                _myDBContext.SaveChanges();
            }
            return tag;
        }
    }
}
