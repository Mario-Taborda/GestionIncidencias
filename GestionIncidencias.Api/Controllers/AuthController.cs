using Microsoft.AspNetCore.Mvc;
using GestionIncidencias.Domain.DTO;
using GestionIncidencias.Domain.DTO.Requests; 
using GestionIncidencias.Bussiness.Interfaces; 

namespace GestionIncidencias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool esValido = await _usuarioService.ValidarCredencialesAsync(loginDto.Email, loginDto.Password);

            if (esValido)
            {
                return Ok(new
                {
                    Mensaje = "¡Bienvenido al sistema!",
                    Token = "AQUI_IRA_EL_TOKEN_DE_SEGURIDAD"
                });
            }

            return Unauthorized(new { Mensaje = "Correo o contraseña incorrectos." });
        }
        [HttpPost("registro")]
        public async Task<IActionResult> Registrar([FromBody] RegistroDTO registroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string passwordEncriptada = BCrypt.Net.BCrypt.HashPassword(registroDto.Password);

                var nuevoUsuario = new UsuarioDto
                {
                    Nombre = registroDto.Nombre,
                    Apellido = registroDto.Apellido,
                    Area = registroDto.Area,
                    Email = registroDto.Email,
                    PasswordHash = passwordEncriptada,
                    Activo = true
                };
                await _usuarioService.CreateUsuarioAsync(nuevoUsuario);
                return Ok(new { Mensaje = "¡Usuario registrado exitosamente!" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al guardar el usuario", Detalle = ex.Message });
            }
        }
    }
}