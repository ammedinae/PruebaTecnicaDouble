using PruebaApi.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infraestructure.InternalService.Interface
{
    public interface IApiBLL
    {
        HttpResponseMessage ConsumptionPost(InfraestructureRequest infraestructureRequest);
        HttpResponseMessage ConsumptionGet(string? parameter, string url);
    }
}
