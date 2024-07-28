using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prueba.Infraestructure.InternalService.Interface;
using PruebaApi.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infraestructure.InternalService.Service
{
    public class ApiBLL : IApiBLL
    {
        public HttpResponseMessage ConsumptionPost(InfraestructureRequest infraestructureRequest)
        {
            HttpResponseMessage Response = new();
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string url = infraestructureRequest.Url;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(infraestructureRequest.Body),Encoding.UTF8,"application/json");
            Response = client.PostAsync(url, jsonContent).Result;
            //Response = client.PostAsync(UrlValidar, new FormUrlEncodedContent(infraestructureRequest.Body)).Result;
            return Response;
        }

        public HttpResponseMessage ConsumptionGet(string? parameter, string url)
        {
            HttpResponseMessage Response = new();
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string urlSer = string.Empty;
            if (parameter is not null)
                urlSer = $"{url}?{parameter}";
            else
                urlSer = url;
            Response = client.GetAsync(urlSer).Result;
            return Response;
        }
    }
}
