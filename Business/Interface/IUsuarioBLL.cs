using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Business.Interface
{
    public interface IUsuarioBLL
    {
        Task<GenericResponse<UsuarioResponse>> Create(UsuarioRequest model);
        Task<GenericResponse<UsuarioResponse>> GetByUser(string usuario);
        Task<GenericResponse<IEnumerable<UsuarioResponse>>> GetAll();
        Task<GenericResponse<UsuarioResponse>> GetUserLogin(LoginRequest model);
    }
}
