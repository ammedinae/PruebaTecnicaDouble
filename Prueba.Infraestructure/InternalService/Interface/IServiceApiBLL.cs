using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infraestructure.InternalService.Interface
{
    public interface IServiceApiBLL
    {
        Task<GenericResponse<UsuarioResponse>> SaveUsuario(UsuarioRequest usuarioRequest, string url);
        Task<GenericResponse<UsuarioResponse>> GetByUser(string userName, string url);
        Task<GenericResponse<IEnumerable<UsuarioResponse>>> GetAllUser(string url);
        Task<GenericResponse<UsuarioResponse>> GetUserLogin(LoginRequest loginRequest, string url);
        Task<GenericResponse<PersonaResponse>> SavePersona(PersonaRequest personaRequest, string url);
        Task<GenericResponse<PersonaResponse>> GetByPersona(int identificacion, string url);
        Task<GenericResponse<IEnumerable<PersonaResponse>>> GetAllPersona(string url);
    }
}
