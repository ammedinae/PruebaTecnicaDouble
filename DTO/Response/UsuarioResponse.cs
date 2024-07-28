using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO.Response
{
    public class UsuarioResponse
    {
        public long Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public DateTime FechaDeCreacion { get; set; }
    }
}
