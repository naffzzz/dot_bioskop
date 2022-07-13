using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class StudiosService : IStudiosService
    {
        private List<studios> _studiosItem;

        public StudiosService()
        {
            _studiosItem = new List<studios>();
        }

        public List<studios> GetStudios()
        {
            return _studiosItem;
        }

        public studios AddStudios(studios studio)
        {
            _studiosItem.Add(studio);
            return studio;
        }

        public studios UpdateStudios(int id, studios studio)
        {
            for (var index = _studiosItem.Count - 1; index >= 0; index--)
            {
                if (_studiosItem[index].id == id)
                {
                    _studiosItem[index] = studio;
                }
            }
            return studio;
        }

        public string DeleteStudios(int id)
        {
            for (var index = _studiosItem.Count - 1; index >= 0; index--)
            {
                if (_studiosItem[index].id == id)
                {
                    _studiosItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
