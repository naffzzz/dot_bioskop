using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class logins
    {
        public string email { get; set; }
        public string password { get; set; }
        public int is_admin { get; set; }
        public string activation_key { get; set; }

    }
}
