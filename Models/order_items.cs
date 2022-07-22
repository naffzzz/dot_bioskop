using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dot_bioskop.Models
{
    [Table(name: "order_items")]
    public class order_items
    {
        [Key, Column(name: "id", TypeName = "int")]
        public int id { get; set; }
        [Required, Column(name: "order_id", TypeName = "int")]
        public int order_id { get; set; }
        [Required, Column(name: "movie_schedule_id", TypeName = "int")]
        public int movie_schedule_id { get; set; }
        [Required, Column(name: "qty", TypeName = "int")]
        public int qty { get; set; }
        [Required, Column(name: "price", TypeName = "double")]
        public double price { get; set; }
        [Required, Column(name: "sub_total_price", TypeName = "double")]
        public double sub_total_price { get; set; }
        [Required, Column(name: "created_at", TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Column(name: "updated_at", TypeName = "datetime")]
        public DateTime? updated_at { get; set; }
        [Column(name: "deleted_at", TypeName = "datetime")]
        public DateTime? deleted_at { get; set; }

        [ForeignKey("id")]
        public movie_schedules movie_schedule { get; set; }

        [ForeignKey("id")]
        public orders order{ get; set; }
    }
}
