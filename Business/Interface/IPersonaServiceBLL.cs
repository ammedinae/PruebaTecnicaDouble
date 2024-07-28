using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Business.Interface
{
    public interface IPersonaServiceBLL
    {
        Task<GenericResponse<PersonaResponse>> Create(PersonaRequest model);
        Task<GenericResponse<PersonaResponse>> GetByPerson(int identificacion);
        Task<GenericResponse<IEnumerable<PersonaResponse>>> GetAllPerson();
    }
}
