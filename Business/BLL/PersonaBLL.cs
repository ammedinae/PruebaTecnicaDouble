using Microsoft.EntityFrameworkCore;
using PruebaApi.Business.AutoMapper;
using PruebaApi.Business.Interface;
using PruebaApi.DataAccess.Context;
using PruebaApi.DataAccess.Models;
using PruebaApi.DTO.Common;
using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Business.BLL
{
    public class PersonaBLL : IPersonaBLL
    {
        private readonly AppDbContext _db;
        public PersonaBLL()
        {
            _db = new AppDbContext();
        }

        public virtual async Task<GenericResponse<PersonaResponse>> Create(PersonaRequest model)
        {
            try
            {
                if (model.IdentificacionTipo is null) model.IdentificacionTipo = $"{model.NumeroIdentificacion} {model.TipoIdentificacion}";
                if (model.NombresApellidos is null) model.NombresApellidos = $"{model.Nombres} {model.Apellidos}";

                Persona entity = ConvertMapping<PersonaRequest, PersonaResponse, Persona, object>.ConvertToEntity(model);
                _db.Set<Persona>().Add(entity);
                await _db.SaveChangesAsync();
                PersonaResponse modelResponse = ConvertMapping<PersonaRequest, PersonaResponse, Persona, object>.ConvertToResponseModel(entity);

                if (model != null)
                {
                    return GenericResponse<PersonaResponse>.ResponseOK(modelResponse);
                }
                else
                {
                    return GenericResponse<PersonaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<PersonaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<PersonaResponse>> GetById(int id)
        {
            try
            {
                Persona? entity = await _db.Set<Persona>()
                    .FirstOrDefaultAsync(x => x.NumeroIdentificacion == id);

                PersonaResponse modeloResponse = ConvertMapping<object, PersonaResponse, Persona, long>.ConvertToResponseModel(entity);
                if (modeloResponse != null)
                {
                    return GenericResponse<PersonaResponse>.ResponseOK(modeloResponse);
                }
                else
                {
                    return GenericResponse<PersonaResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<PersonaResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<PersonaResponse>>> GetAll()
        {
            try
            {
                List<Persona> entityList = await _db.Set<Persona>().ToListAsync();
                List<PersonaResponse> modeloResponseList = ConvertMapping<object, PersonaResponse, Persona, long>.ConvertToResponseModelList(entityList);
                if (modeloResponseList.Count > 0)
                {
                    return GenericResponse<IEnumerable<PersonaResponse>>.ResponseOK(modeloResponseList);
                }
                else
                {
                    return GenericResponse<IEnumerable<PersonaResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<PersonaResponse>>.ResponseError(ex.Message);
            }
        }
    }    
}
