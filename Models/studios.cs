using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class studios
    {
        public int id { get; set; }
        public int studio_number { get; set; }
        public int seat_capacity { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
