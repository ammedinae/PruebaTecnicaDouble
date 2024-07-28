using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO.Response
{
    public class PersonaResponse
    {
        public long Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int NumeroIdentificacion { get; set; }
        public string Email { get; set; } = null!;
        public string TipoIdentificacion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string IdentificacionTipo { get; set; } = null!;
        public string NombresApellidos { get; set; } = null!;
    }
}
