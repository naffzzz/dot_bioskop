using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class movie_tags
    {
        public int id { get; set; }
        public int movie_id { get; set; }
        public int tag_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
