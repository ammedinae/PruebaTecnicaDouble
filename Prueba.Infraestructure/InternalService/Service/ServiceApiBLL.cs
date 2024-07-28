using Newtonsoft.Json;
using Prueba.Infraestructure.InternalService.Interface;
using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infraestructure.InternalService.Service
{
    public class ServiceApiBLL : IServiceApiBLL
    {
        private readonly IApiBLL _iApiBLL;
        public ServiceApiBLL(IApiBLL iApiBLL)
        {
            _iApiBLL = iApiBLL;
        }

        #region Usuario
        public virtual async Task<GenericResponse<UsuarioResponse>> SaveUsuario(UsuarioRequest usuarioRequest, string url)
        {
            try
            {
                string Mensaje = string.Empty;
                InfraestructureRequest infraestructureRequest = new()
                {
                    Body = new Dictionary<string, string>
                    {
                        {"Usuario1", usuarioRequest.Usuario1},
                        {"Pass", usuarioRequest.Pass},
                    },
                    Url = url,
                };

                var responseConsumption = _iApiBLL.ConsumptionPost(infraestructureRequest);
                if (responseConsumption.IsSuccessStatusCode)
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    UsuarioResponse response = JsonConvert.DeserializeObject<UsuarioResponse>(jsonContent);
                    return GenericResponse<UsuarioResponse>.ResponseOK(response);
                }
                else
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    Mensaje = JsonConvert.DeserializeObject<MensajeResponse>(jsonContent).Message;
                    return GenericResponse<UsuarioResponse>.ResponseValidation(Mensaje);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> GetByUser(string userName, string url)
        {
            try
            {
                string Mensaje = string.Empty;
                var responseConsumption = _iApiBLL.ConsumptionGet($"name={userName}", url);
                if (responseConsumption.IsSuccessStatusCode)
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    UsuarioResponse response = JsonConvert.DeserializeObject<UsuarioResponse>(jsonContent);
                    return GenericResponse<UsuarioResponse>.ResponseOK(response);
                }
                else
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    Mensaje = JsonConvert.DeserializeObject<MensajeResponse>(jsonContent).Message;
                    return GenericResponse<UsuarioResponse>.ResponseValidation(Mensaje);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<UsuarioResponse>>> GetAllUser(string url)
        {
            try
            {
                string Mensaje = string.Empty;
                var responseConsumption = _iApiBLL.ConsumptionGet(null, url);
                if (responseConsumption.IsSuccessStatusCode)
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    var jsonResult = JsonConvert.DeserializeObject<GenericResponse<List<UsuarioResponse>>>(jsonContent).Data;
                    return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseOK(jsonResult);
                }
                else
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    Mensaje = JsonConvert.DeserializeObject<MensajeResponse>(jsonContent).Message;
                    return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseValidation(Mensaje);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> GetUserLogin(LoginRequest loginRequest, string url)
        {
            try
            {
                string Mensaje = string.Empty;
                InfraestructureRequest infraestructureRequest = new()
                {
                    Body = new Dictionary<string, string>
                    {
                        {"Usuario1", loginRequest.Usuario1},
                        {"Pass", loginRequest.Pass},
                    },
                    Url = url,
                };

                var responseConsumption = _iApiBLL.ConsumptionPost(infraestructureRequest);
                if (responseConsumption.IsSuccessStatusCode)
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    UsuarioResponse response = JsonConvert.DeserializeObject<UsuarioResponse>(jsonContent);
                    return GenericResponse<UsuarioResponse>.ResponseOK(response);
                }
                else
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    Mensaje = JsonConvert.DeserializeObject<MensajeResponse>(jsonContent).Message;
                    return GenericResponse<UsuarioResponse>.ResponseValidation(Mensaje);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }
        #endregion

        #region Persona
        public virtual async Task<GenericResponse<PersonaResponse>> SavePersona(PersonaRequest personaRequest, string url)
        {
            try
            {
                string Mensaje = string.Empty;
                InfraestructureRequest infraestructureRequest = new()
                {
                    Body = new Dictionary<string, string>
                    {
                        {"Nombres", personaRequest.Nombres},
                        {"Apellidos", personaRequest.Apellidos},
                        {"NumeroIdentificacion", personaRequest.NumeroIdentificacion.ToString()},
                        {"Email", personaRequest.Email},
                        {"TipoIdentificacion", personaRequest.TipoIdentificacion},
                        {"IdentificacionTipo", personaRequest.IdentificacionTipo},
                        {"NombresApellidos", personaRequest.NombresApellidos},
                    },
                    Url = url,
                };

                var responseConsumption = _iApiBLL.ConsumptionPost(infraestructureRequest);
                if (responseConsumption.IsSuccessStatusCode)
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    PersonaResponse response = JsonConvert.DeserializeObject<PersonaResponse>(jsonContent);
                    return GenericResponse<PersonaResponse>.ResponseOK(response);
                }
                else
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    Mensaje = JsonConvert.DeserializeObject<MensajeResponse>(jsonContent).Message;
                    return GenericResponse<PersonaResponse>.ResponseValidation(Mensaje);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<PersonaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<PersonaResponse>> GetByPersona(int identificacion, string url)
        {
            try
            {
                string Mensaje = string.Empty;
                var responseConsumption = _iApiBLL.ConsumptionGet($"identificacion={identificacion}", url);
                if (responseConsumption.IsSuccessStatusCode)
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    PersonaResponse response = JsonConvert.DeserializeObject<PersonaResponse>(jsonContent);
                    return GenericResponse<PersonaResponse>.ResponseOK(response);
                }
                else
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    Mensaje = JsonConvert.DeserializeObject<MensajeResponse>(jsonContent).Message;
                    return GenericResponse<PersonaResponse>.ResponseValidation(Mensaje);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<PersonaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<PersonaResponse>>> GetAllPersona(string url)
        {
            try
            {
                string Mensaje = string.Empty;
                var responseConsumption = _iApiBLL.ConsumptionGet(null, url);
                if (responseConsumption.IsSuccessStatusCode)
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    var jsonResult = JsonConvert.DeserializeObject<GenericResponse<List<PersonaResponse>>>(jsonContent).Data;
                    return GenericResponse<IEnumerable<PersonaResponse>>.ResponseOK(jsonResult);
                }
                else
                {
                    var jsonContent = responseConsumption.Content.ReadAsStringAsync().Result;
                    Mensaje = JsonConvert.DeserializeObject<MensajeResponse>(jsonContent).Message;
                    return GenericResponse<IEnumerable<PersonaResponse>>.ResponseValidation(Mensaje);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<IEnumerable<PersonaResponse>>.ResponseError(ex.Message);
            }
        }
        #endregion

    }
}
