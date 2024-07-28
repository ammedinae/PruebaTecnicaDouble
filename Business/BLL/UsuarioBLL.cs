using PruebaApi.Business.Interface;
using PruebaApi.Business.AutoMapper;
using PruebaApi.DataAccess.Context;
using PruebaApi.DataAccess.Models;
using PruebaApi.DTO.Common;
using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using PruebaApi.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PruebaApi.Business.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly AppDbContext _db;
        public UsuarioBLL()
        {
            _db = new AppDbContext();
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> Create(UsuarioRequest model)
        {
            try
            {
                model.Pass = Encrypt.EncryptToSHA256(model.Pass);
                Usuario entity = ConvertMapping<UsuarioRequest, UsuarioResponse, Usuario, object>.ConvertToEntity(model);
                _db.Set<Usuario>().Add(entity);
                await _db.SaveChangesAsync();
                UsuarioResponse modelResponse = ConvertMapping< UsuarioRequest, UsuarioResponse, Usuario, object>.ConvertToResponseModel(entity);

                if (model != null)
                {
                    return GenericResponse<UsuarioResponse>.ResponseOK(modelResponse);
                }
                else
                {
                    return GenericResponse<UsuarioResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> GetByUser(string usuario)
        {
            try
            {
                Usuario? entity = await _db.Set<Usuario>()
                    .FirstOrDefaultAsync(x => x.Usuario1.ToUpper() == usuario.ToUpper());

                UsuarioResponse modeloResponse = ConvertMapping<object, UsuarioResponse, Usuario, long>.ConvertToResponseModel(entity);
                if (modeloResponse != null)
                {
                    return GenericResponse<UsuarioResponse>.ResponseOK(modeloResponse);
                }
                else
                {
                    return GenericResponse<UsuarioResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<UsuarioResponse>>> GetAll()
        {
            try
            {
                List<Usuario> entityList = await _db.Set<Usuario>().ToListAsync();

                List<UsuarioResponse> modeloResponseList = ConvertMapping<object, UsuarioResponse, Usuario, long>.ConvertToResponseModelList(entityList);
                if (modeloResponseList.Count > 0)
                {
                    return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseOK(modeloResponseList);
                }
                else
                {
                    return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<UsuarioResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<UsuarioResponse>> GetUserLogin(LoginRequest model)
        {
            try
            {
                Usuario? entity = await _db.Set<Usuario>()
                    .FirstOrDefaultAsync(x => x.Usuario1.ToUpper() == model.Usuario1.ToUpper() && x.Pass == model.Pass);

                UsuarioResponse modelResponse = ConvertMapping<object, UsuarioResponse, Usuario, long>.ConvertToResponseModel(entity);

                if (model != null)
                {
                    return GenericResponse<UsuarioResponse>.ResponseOK(modelResponse);
                }
                else
                {
                    return GenericResponse<UsuarioResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<UsuarioResponse>.ResponseError(ex.Message);
            }
        }
    }
}
