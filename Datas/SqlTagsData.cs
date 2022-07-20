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

        public tags AddTag(tags tag)
        {
            _myDBContext.tags.Add(tag);
            _myDBContext.SaveChanges();
            return tag;
        }

        public void DeleteTag(tags tag)
        {
            _myDBContext.tags.Remove(tag);
            _myDBContext.SaveChanges();
        }

        public tags GetTag(int id)
        {
            var tag = _myDBContext.tags.Where(b => b.id == id).FirstOrDefault(); 
            return tag;
        }

        public List<tags> GetTags()
        {
            return _myDBContext.tags.ToList();
        }

        public tags SoftDeleteTag(tags tag)
        {
            var existingTag = _myDBContext.tags.Where(b => b.id == tag.id).FirstOrDefault();
            if (existingTag != null)
            {
                existingTag.deleted_at = tag.deleted_at;
                _myDBContext.tags.Update(existingTag);
                _myDBContext.SaveChanges();
            }
            return tag;
        }

        public tags UpdateTag(tags tag)
        {
            var existingTag = _myDBContext.tags.Where(b => b.id == tag.id).FirstOrDefault();
            if (existingTag != null)
            {
                existingTag.name = tag.name;
                existingTag.updated_at = tag.updated_at;
                _myDBContext.tags.Update(existingTag);
                _myDBContext.SaveChanges();
            }
            return tag;
        }
    }
}
