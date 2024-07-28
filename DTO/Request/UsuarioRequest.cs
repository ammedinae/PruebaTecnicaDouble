using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO.Request
{
    public class UsuarioRequest
    {
        [Column("Usuario")]
        [StringLength(50)]
        [Required(ErrorMessage = "Usuario es obligatorio")]
        public string Usuario1 { get; set; } = null!;
        [StringLength(100)]
        [Required(ErrorMessage = "Password es obligatorio")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{10,}$", ErrorMessage = "El password debe contener al menos 1 mayúscula, 1 números, 1 caracter especial, y tener al menos 10 caracteres.")]
        public string Pass { get; set; } = null!;
    }
}
