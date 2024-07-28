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
    public class UsuarioServiceBLL : IUsuarioServiceBLL
    {
        private readonly IServiceApiBLL _serviceApiBLL;
        readonly IConfiguration _configuration;

        public UsuarioServiceBLL(IServiceApiBLL serviceApiBLL, IConfiguration configuration)
        {
            _serviceApiBLL = serviceApiBLL;
            _configuration = configuration;
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> Create(UsuarioRequest model)
        {
            try
            {
                string urlService = _configuration.GetSection("EndPoinst:CreateUser").Value;
                var result = await _serviceApiBLL.SaveUsuario(model, urlService);
                if (result.Code == 200)
                {
                    return GenericResponse<UsuarioResponse>.ResponseOK(result.Data);
                }
                else
                {
                    return GenericResponse<UsuarioResponse>.ResponseValidation(result.Message);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> GetByUser(string userName)
        {
            try
            {
                string urlService = _configuration.GetSection("EndPoinst:GetByUser").Value;
                var result = await _serviceApiBLL.GetByUser(userName, urlService);
                if (result.Code == 200)
                {
                    return GenericResponse<UsuarioResponse>.ResponseOK(result.Data);
                }
                else
                {
                    return GenericResponse<UsuarioResponse>.ResponseValidation(result.Message);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<UsuarioResponse>>> GetAllUser()
        {
            try
            {
                string urlService = _configuration.GetSection("EndPoinst:GetAllUser").Value;
                var result = await _serviceApiBLL.GetAllUser(urlService);
                if (result.Code == 200)
                {
                    return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseOK(result.Data);
                }
                else
                {
                    return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseValidation(result.Message);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> GetUserLogin(LoginRequest loginRequest)
        {
            try
            {
                string urlService = _configuration.GetSection("EndPoinst:GetUserLogin").Value;
                var result = await _serviceApiBLL.GetUserLogin(loginRequest, urlService);
                if (result.Code == 200)
                {
                    return GenericResponse<UsuarioResponse>.ResponseOK(result.Data);
                }
                else
                {
                    return GenericResponse<UsuarioResponse>.ResponseValidation(result.Message);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }
    }
}
