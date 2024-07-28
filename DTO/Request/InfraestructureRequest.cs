using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO.Request
{
    public class InfraestructureRequest
    {
        public Dictionary<string, string> Body { get; set; }
        public string Url { get; set; }
    }
}
