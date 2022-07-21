using System.Collections.Generic;
using System.Linq;
using dot_bioskop.Models;
using dot_bioskop.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace dot_bioskop.Datas
{
    public class SqlMovieTagsData
    {
        private MyDBContext _myDBContext;

        public SqlMovieTagsData(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public movie_tags AddMovieTag(movie_tags movie_tag)
        {
            _myDBContext.movie_tags.Add(movie_tag);
            _myDBContext.SaveChanges();
            return movie_tag;
        }

        public void DeleteMovieTag(movie_tags movie_tag)
        {
            _myDBContext.movie_tags.Remove(movie_tag);
            _myDBContext.SaveChanges();
        }

        public movie_tags GetMovieTag(int id)
        {
            var movie_tag = _myDBContext.movie_tags.Where(b => b.id == id).Include(x => x.tag).Include(y => y.movie).FirstOrDefault();
            return movie_tag;
        }

        public List<movie_tags> GetMovieTags()
        {
            return _myDBContext.movie_tags.Include(x => x.tag).Include(y => y.movie).ToList();
        }

        public movie_tags SoftDeleteMovieTag(movie_tags movie_tag)
        {
            var existingMovieTag = _myDBContext.movie_tags.Where(b => b.id == movie_tag.id).FirstOrDefault();
            if (existingMovieTag != null)
            {
                existingMovieTag.deleted_at = movie_tag.deleted_at;
                _myDBContext.movie_tags.Update(existingMovieTag);
                _myDBContext.SaveChanges();
            }
            return movie_tag;
        }

        public movie_tags UpdateMovieTag(movie_tags movie_tag)
        {
            var existingMovieTag = _myDBContext.movie_tags.Where(b => b.id == movie_tag.id).FirstOrDefault();
            if (existingMovieTag != null)
            {
                existingMovieTag.movie_id = movie_tag.movie_id;
                existingMovieTag.tag_id = movie_tag.tag_id;
                existingMovieTag.updated_at = movie_tag.updated_at;
                _myDBContext.movie_tags.Update(existingMovieTag);
                _myDBContext.SaveChanges();
            }
            return movie_tag;
        }
    }
}
