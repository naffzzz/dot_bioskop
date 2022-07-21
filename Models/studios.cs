using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dot_bioskop.Models
{
    [Table(name: "studios")]
    public class studios
    {
        [Key, Column(name: "id", TypeName = "bigint")]
        public int id { get; set; }
        [Required, Column(name: "studio_number", TypeName = "bigint")]
        public int studio_number { get; set; }
        [Required, Column(name: "seat_capacity", TypeName = "bigint")]
        public int seat_capacity { get; set; }
        [Required, Column(name: "created_at", TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Column(name: "updated_at", TypeName = "datetime")]
        public DateTime? updated_at { get; set; }
        [Column(name: "deleted_at", TypeName = "datetime")]
        public DateTime? deleted_at { get; set; }
    }
}
