using Microsoft.AspNetCore.Mvc;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Domain.DTO;
using GestionIncidencias.Domain.DTO.Requests;
using System.Threading.Tasks;

namespace GestionIncidencias.Api.Controllers
{
    public class PeticionRecuperarDto
    {
        public string Email { get; set; } = string.Empty;
    }
    public class RestablecerPasswordDto
    {
        public string Email { get; set; } = string.Empty;
        public string NuevaPassword { get; set; } = string.Empty;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEmailService _emailService;

        public AuthController(IUsuarioService usuarioService, IEmailService emailService)
        {
            _usuarioService = usuarioService;
            _emailService = emailService;
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
        [HttpPost("recuperar")]
        public async Task<IActionResult> RecuperarPassword([FromBody] PeticionRecuperarDto peticion)
        {

            string email = peticion.Email;

            string asunto = "Recuperación de Acceso - Gestión de Incidencias";
            string mensajeHtml = $@"
            <div style='font-family: Arial; border: 1px solid #dee2e6; padding: 20px; border-radius: 10px;'>
                <h2 style='color: #dc3545;'>Restablecer Contraseña</h2>
                <p>Hola, hemos recibido una solicitud para recuperar tu acceso al sistema.</p>
                <p>Haz clic en el siguiente botón para continuar:</p>
                <a href='https://localhost:7133/nueva-clave' 
                   style='background-color: #dc3545; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px; display: inline-block;'>
                   Restablecer mi contraseña
                </a>
                <hr style='border: 0; border-top: 1px solid #eee; margin: 20px 0;'>
                <p style='font-size: 0.8rem; color: #6c757d;'>Si no solicitaste este cambio, puedes ignorar este correo.</p>
            </div>";

            try
            {
                await _emailService.EnviarCorreoAsync(email, asunto, mensajeHtml);
                return Ok(new { Mensaje = "Correo enviado exitosamente" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPut("restablecer-clave")]
        public async Task<IActionResult> RestablecerClave([FromBody] RestablecerPasswordDto dto)
        {
            try
            {
                string passwordEncriptada = BCrypt.Net.BCrypt.HashPassword(dto.NuevaPassword);
                bool exito = await _usuarioService.ActualizarPasswordAsync(dto.Email, passwordEncriptada);

                if (exito)
                    return Ok(new { Mensaje = "Contraseña actualizada exitosamente." });
                else
                    return NotFound(new { Mensaje = "No se encontró un usuario con ese correo." });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}