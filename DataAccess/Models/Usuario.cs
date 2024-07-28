using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaApi.DataAccess.Models
{
    public partial class Usuario
    {
        [Key]
        public long Id { get; set; }
        [Column("Usuario")]
        [StringLength(50)]
        [Unicode(false)]
        public string Usuario1 { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Pass { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime FechaDeCreacion { get; set; }
    }
}
