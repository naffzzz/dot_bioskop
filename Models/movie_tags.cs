using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    [Table(name: "movie_tags")]
    public class movie_tags
    {
        [Key, Column(name: "id", TypeName = "bigint")]
        public int id { get; set; }
        [Required, Column(name: "movie_id", TypeName = "bigint")]
        public int movie_id { get; set; }
        [Required, Column(name: "tag_id", TypeName = "bigint")]
        public int tag_id { get; set; }
        [Required, Column(name: "created_at", TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Column(name: "updated_at", TypeName = "datetime")]
        public DateTime? updated_at { get; set; }
        [Column(name: "deleted_at", TypeName = "datetime")]
        public DateTime? deleted_at { get; set; }

        [ForeignKey("id")]
        public tags tag { get; set; }

        [ForeignKey("id")]
        public movies movie { get; set; }
    }
}
