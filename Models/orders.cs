using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    public class orders
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int payment_method { get; set; }
        public double total_item_price { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }


        [ForeignKey("id")]
        public users user { get; set; }
    }
}
