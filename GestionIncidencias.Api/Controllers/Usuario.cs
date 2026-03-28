using AutoMapper;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Bussiness.Services;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using GestionIncidencias.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace GestionIncidencias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController(IUsuarioService usuarioService, IMapper mapper) : ControllerBase
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UsuarioResponsesDto>>> GetUsuario()
        {
            var usuario = await _usuarioService.GetAllUsuarioAsync();
            return Ok(usuario);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdASync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UsuarioDto>(usuario));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> /*Create*/CrearUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdUsuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
            var responsesDto = _mapper.Map<UsuarioResponsesDto>(createdUsuario);

            return CreatedAtAction(nameof(GetById), new { id = createdUsuario.Id }, responsesDto);
        }
        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> /*Update*/ObtenerUsuario(int Id, [FromBody] UpdateUsuarioDto updateusuarioDto)
        {
            if (Id != updateusuarioDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _usuarioService.UpdateUsuarioAsync(updateusuarioDto);
            return NoContent();

        }
    }
}




