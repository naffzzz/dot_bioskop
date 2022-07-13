using dot_bioskop.Models;
using System;
using System.Collections.Generic;

namespace dot_bioskop.Services
{
    public class TagsService : ITagsService
    {
        private List<tags> _tagsItem;

        public TagsService()
        {
            _tagsItem = new List<tags>();
        }

        public List<tags> GetTags()
        {
            return _tagsItem;
        }

        public tags AddTags(tags tag)
        {
            _tagsItem.Add(tag);
            return tag;
        }

        public tags UpdateTags(int id, tags tag)
        {
            for (var index = _tagsItem.Count - 1; index >= 0; index--)
            {
                if (_tagsItem[index].id == id)
                {
                    _tagsItem[index] = tag;
                }
            }
            return tag;
        }

        public string DeleteTags(int id)
        {
            for (var index = _tagsItem.Count - 1; index >= 0; index--)
            {
                if (_tagsItem[index].id == id)
                {
                    _tagsItem.RemoveAt(index);
                }
            }

            return id.ToString();
        }
    }
}
