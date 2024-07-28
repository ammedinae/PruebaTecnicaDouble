using Microsoft.Extensions.Configuration;
using Prueba.Infraestructure.InternalService.Interface;
using PruebaApi.Business.Interface;
using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Business.BLL
{
    public class PersonaServiceBLL : IPersonaServiceBLL
    {
        private readonly IServiceApiBLL _serviceApiBLL;
        readonly IConfiguration _configuration;

        public PersonaServiceBLL(IServiceApiBLL serviceApiBLL, IConfiguration configuration)
        {
            _serviceApiBLL = serviceApiBLL;
            _configuration = configuration;
        }

        public virtual async Task<GenericResponse<PersonaResponse>> Create(PersonaRequest model)
        {
            try
            {
                string urlService = _configuration.GetSection("EndPoinst:CreatePerson").Value;
                var result = await _serviceApiBLL.SavePersona(model, urlService);
                if (result.Code == 200)
                {
                    return GenericResponse<PersonaResponse>.ResponseOK(result.Data);
                }
                else
                {
                    return GenericResponse<PersonaResponse>.ResponseValidation(result.Message);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<PersonaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<PersonaResponse>> GetByPerson(int identificacion)
        {
            try
            {
                string urlService = _configuration.GetSection("EndPoinst:GetByPerson").Value;
                var result = await _serviceApiBLL.GetByPersona(identificacion, urlService);
                if (result.Code == 200)
                {
                    return GenericResponse<PersonaResponse>.ResponseOK(result.Data);
                }
                else
                {
                    return GenericResponse<PersonaResponse>.ResponseValidation(result.Message);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<PersonaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<PersonaResponse>>> GetAllPerson()
        {
            try
            {
                string urlService = _configuration.GetSection("EndPoinst:GetAllPerson").Value;
                var result = await _serviceApiBLL.GetAllPersona(urlService);
                if (result.Code == 200)
                {
                    return GenericResponse<IEnumerable<PersonaResponse>>.ResponseOK(result.Data);
                }
                else
                {
                    return GenericResponse<IEnumerable<PersonaResponse>>.ResponseValidation(result.Message);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<PersonaResponse>>.ResponseError(ex.Message);
            }
        }
    }
}
