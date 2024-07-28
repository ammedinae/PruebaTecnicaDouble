using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Business.Interface
{
    public interface IUsuarioServiceBLL
    {
        Task<GenericResponse<UsuarioResponse>> Create(UsuarioRequest model);
        Task<GenericResponse<UsuarioResponse>> GetByUser(string userName);
        Task<GenericResponse<IEnumerable<UsuarioResponse>>> GetAllUser();
        Task<GenericResponse<UsuarioResponse>> GetUserLogin(LoginRequest loginRequest);
    }
}
