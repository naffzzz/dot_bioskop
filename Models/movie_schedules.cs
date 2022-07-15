using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class movie_schedules
    {
        public int id { get; set; }
        public int movie_id { get; set; }
        public int studio_id { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public double price { get; set; }
        public DateTime date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }

        [ForeignKey("id")]
        public movies movie { get; set; }

        [ForeignKey("id")]
        public studios studio { get; set; }
    }
}
