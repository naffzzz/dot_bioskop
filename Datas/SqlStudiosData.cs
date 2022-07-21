using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;

namespace dot_bioskop.Datas
{
    public class SqlStudiosData
    {
        private MyDBContext _myDBContext;

        public SqlStudiosData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public studios AddStudio(studios studio)
        {
            _myDBContext.studios.Add(studio);
            _myDBContext.SaveChanges();
            return studio;
        }

        public void DeleteStudio(studios studio)
        {
            _myDBContext.studios.Remove(studio);
            _myDBContext.SaveChanges();
        }

        public studios GetStudio(int id)
        {
            var studio = _myDBContext.studios.Where(b => b.id == id).FirstOrDefault();
            return studio;
        }

        public List<studios> GetStudios()
        {
            return _myDBContext.studios.ToList();
        }

        public studios SoftDeleteStudio(studios studio)
        {
            var existingStudio = _myDBContext.studios.Where(b => b.id == studio.id).FirstOrDefault();
            if (existingStudio != null)
            {
                existingStudio.deleted_at = studio.deleted_at;
                _myDBContext.studios.Update(existingStudio);
                _myDBContext.SaveChanges();
            }
            return studio;
        }

        public studios UpdateStudio(studios studio)
        {
            var existingStudio = _myDBContext.studios.Where(b => b.id == studio.id).FirstOrDefault();
            if (existingStudio != null)
            {
                existingStudio.studio_number = studio.studio_number;
                existingStudio.seat_capacity = studio.seat_capacity;
                existingStudio.updated_at = studio.updated_at;
                _myDBContext.studios.Update(existingStudio);
                _myDBContext.SaveChanges();
            }
            return studio;
        }
    }
}
