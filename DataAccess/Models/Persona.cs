using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaApi.DataAccess.Models
{
    public partial class Persona
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Nombres { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Apellidos { get; set; } = null!;
        public int NumeroIdentificacion { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string TipoIdentificacion { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string IdentificacionTipo { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string NombresApellidos { get; set; } = null!;
    }
}
