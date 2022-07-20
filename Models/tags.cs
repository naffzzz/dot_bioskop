using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Models
{
    [Table(name: "tags")]
    public class tags
    {
        [Key, Column(name: "id", TypeName = "bigint")]
        public int id { get; set; }
        [Required, Column(name: "name", TypeName = "varchar(100)")]
        public string name { get; set; }
        [Required, Column(name: "created_at", TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Column(name: "updated_at", TypeName = "datetime")]
        public DateTime? updated_at { get; set; }
        [Column(name: "deleted_at", TypeName = "datetime")]
        public DateTime? deleted_at { get; set; }
    }
}
