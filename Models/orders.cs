using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    [Table(name: "orders")]
    public class orders
    {
        [Key, Column(name: "id", TypeName = "bigint")]
        public int id { get; set; }
        [Required, Column(name: "user_id", TypeName = "bigint")]
        public int user_id { get; set; }
        [Required, Column(name: "payment_method", TypeName = "int")]
        public int payment_method { get; set; }
        [Required, Column(name: "total_item_price", TypeName = "double")]
        public double total_item_price { get; set; }
        [Required, Column(name: "created_at", TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Column(name: "updated_at", TypeName = "datetime")]
        public DateTime? updated_at { get; set; }
        [Column(name: "deleted_at", TypeName = "datetime")]
        public DateTime? deleted_at { get; set; }


        [ForeignKey("id")]
        public users user { get; set; }
    }
}

