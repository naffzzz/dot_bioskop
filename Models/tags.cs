using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class tags
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
