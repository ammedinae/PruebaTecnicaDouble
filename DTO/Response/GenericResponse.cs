using PruebaApi.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO.Response
{
    public class GenericResponse<TEntity>
    {
        public static string GetMessageException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetMessageException(ex.InnerException);
            }
            else
            {
                return ex.Message;
            }
        }

        public int Code { get; set; }

        public string? Message { get; set; }

        public TEntity? Data { get; set; }

        public static GenericResponse<TEntity> ResponseOK(TEntity data, string message = ConstansApp.Messages.OK)
        {
            return new GenericResponse<TEntity>
            {
                Code = ConstansApp.ApiCodes.OK,
                Message = message,
                Data = data
            };
        }

        public static GenericResponse<TEntity> ResponseValidation(string message)
        {
            return new GenericResponse<TEntity>
            {
                Code = ConstansApp.ApiCodes.ControlledError,
                Message = message,
                Data = default
            };
        }

        public static GenericResponse<TEntity> ResponseError(string message = ConstansApp.Messages.UnexpectedError)
        {
            return new GenericResponse<TEntity>
            {
                Code = ConstansApp.ApiCodes.UnexpectedError,
                Message = message,
                Data = default
            };
        }

        public static GenericResponse<TEntity> ResponseError(Exception ex)
        {
            return new GenericResponse<TEntity>
            {
                Code = ConstansApp.ApiCodes.UnexpectedError,
                Message = GetMessageException(ex),
                Data = default
            };
        }

        public static GenericResponse<TEntity> NoData(string message = ConstansApp.Messages.NoData)
        {
            return new GenericResponse<TEntity>
            {
                Code = ConstansApp.ApiCodes.UnexpectedError,
                Message = message,
                Data = default
            };
        }
    }
}
