using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Business.Interface;
using PruebaApi.DTO.Request;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBLL _userBLL;

        public UsuarioController(IUsuarioBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioRequest requestUser)
        {
            var consumptionResponse = await _userBLL.Create(requestUser);

            if (consumptionResponse.Code == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(string name)
        {
            var consumptionResponse = await _userBLL.GetByUser(name);

            if (consumptionResponse.Code == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var consumptionResponse = await _userBLL.GetAll();

            if (consumptionResponse.Code == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }

        [HttpPost("GetUserLogin")]
        public async Task<IActionResult> GetUserLogin([FromBody] LoginRequest loginRequest)
        {
            var consumptionResponse = await _userBLL.GetUserLogin(loginRequest);

            if (consumptionResponse.Code == 200)
            {
                return Ok(consumptionResponse);
            }
            return BadRequest(consumptionResponse);
        }
    }
}
