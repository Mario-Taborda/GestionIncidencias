using Microsoft.AspNetCore.Mvc;
using GestionIncidencias.Domain.DTO;

namespace GestionIncidencias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (loginDto.Email == "admin@empresa.com" && loginDto.Password == "123456")
            {
                return Ok(new
                {
                    Mensaje = "¡Bienvenido al sistema de Gestión de Incidencias!",
                    Token = "AQUI_IRA_EL_TOKEN_DE_SEGURIDAD"
                });
            }
            return Unauthorized(new { Mensaje = "Correo o contraseña incorrectos." });
        }
    }
}