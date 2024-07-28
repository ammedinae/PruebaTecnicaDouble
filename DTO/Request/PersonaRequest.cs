using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO.Request
{
    public class PersonaRequest
    {
        [StringLength(100)]
        [Required(ErrorMessage = "Nombres es obligatorio")]
        public string Nombres { get; set; } = null!;
        [StringLength(100)]
        [Required(ErrorMessage = "Apellido es obligatorio")]
        public string Apellidos { get; set; } = null!;
        [Required(ErrorMessage = "Numero Identificación es obligatorio")]
        public int NumeroIdentificacion { get; set; }
        [Required(ErrorMessage = "Email es obligatorio")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Formato de email inválido")]
        [StringLength(200)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Tipo Identificación es obligatorio")]
        [StringLength(30)]
        public string TipoIdentificacion { get; set; } = null!;
        [StringLength(50)]
        public string? IdentificacionTipo { get; set; } 
        [StringLength(200)]
        public string? NombresApellidos { get; set; }
    }
}
