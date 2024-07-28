using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Business.Interface;
using PruebaApi.DTO.Request;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaBLL _personaBLL;

        public PersonaController(IPersonaBLL personaBLL)
        {
            _personaBLL = personaBLL;
        }

        [HttpPost("CreatePerson")]
        public async Task<IActionResult> CreatePerson([FromBody] PersonaRequest requestPerson)
        {
            var consumptionResponse = await _personaBLL.Create(requestPerson);

            if (consumptionResponse.Code == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }

        [HttpGet("GetByPerson")]
        public async Task<IActionResult> GetByPerson(int identificacion)
        {
            var consumptionResponse = await _personaBLL.GetById(identificacion);

            if (consumptionResponse.Code == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }

        [HttpGet("GetAllPerson")]
        public async Task<IActionResult> GetAllPerson()
        {
            var consumptionResponse = await _personaBLL.GetAll();

            if (consumptionResponse.Code == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }
    }
}
