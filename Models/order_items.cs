using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class order_items
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int movie_schedule_id { get; set; }
        public int qty { get; set; }
        public double price { get; set; }
        public double sub_total_price { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
