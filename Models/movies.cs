using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dot_bioskop.Models
{
    [Table(name: "movies")]
    public class movies
    {
        [Key, Column(name: "id", TypeName = "int")]
        public int id { get; set; }
        [Required, Column(name: "title", TypeName = "varchar(255)")]
        public string title { get; set; }
        [Required, Column(name: "overview", TypeName = "text")]
        public string overview { get; set; }
        [Required, Column(name: "poster", TypeName = "varchar(255)")]
        public string poster { get; set; }
        [Required, Column(name: "play_until", TypeName = "datetime")]
        public DateTime play_until { get; set; }
        [Required, Column(name: "created_at", TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Column(name: "updated_at", TypeName = "datetime")]
        public DateTime? updated_at { get; set; }
        [Column(name: "deleted_at", TypeName = "datetime")]
        public DateTime? deleted_at { get; set; }
    }
}
