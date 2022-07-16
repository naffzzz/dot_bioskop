using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }
        public int is_admin { get; set; }
        public string activation_key { get; set; }
        public int is_confirmed { get; set; }
        public DateTime created_at{ get; set; }
        public DateTime? updated_at{ get; set; }
        public DateTime? deleted_at { get; set; }

    }
}
