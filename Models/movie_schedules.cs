using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dot_bioskop.Models
{
    [Table(name: "movie_schedules")]
    public class movie_schedules
    {
        [Key, Column(name: "id", TypeName = "bigint")]
        public int id { get; set; }
        [Required, Column(name: "movie_id", TypeName = "bigint")]
        public int movie_id { get; set; }
        [Required, Column(name: "studio_id", TypeName = "bigint")]
        public int studio_id { get; set; }
        [Required, Column(name: "start_time", TypeName = "varchar(255)")]
        public string start_time { get; set; }
        [Required, Column(name: "end_time", TypeName = "varchar(255)")]
        public string end_time { get; set; }
        [Required, Column(name: "price", TypeName = "double")]
        public double price { get; set; }
        [Required, Column(name: "date", TypeName = "datetime")]
        public DateTime date { get; set; }
        [Required, Column(name: "created_at", TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Column(name: "updated_at", TypeName = "datetime")]
        public DateTime? updated_at { get; set; }
        [Column(name: "deleted_at", TypeName = "datetime")]
        public DateTime? deleted_at { get; set; }

        [ForeignKey("id")]
        public movies movie { get; set; }

        [ForeignKey("id")]
        public studios studio { get; set; }
    }
}
