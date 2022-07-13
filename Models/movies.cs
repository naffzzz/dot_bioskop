using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class movies
    {
        public int id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string poster { get; set; }
        public DateTime play_until { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
