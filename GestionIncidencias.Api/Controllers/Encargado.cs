using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Bussiness.Services;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace GestionIncidencias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EncargadoController(EncargadoService encargadoService) : ControllerBase
    {
        private readonly EncargadoService _encargadoService = encargadoService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Encargado>>> GetEncargado()
        {
            var encargado = await _encargadoService.GetAllEncargadoAsync();
            return Ok(encargado);
        }
        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int Id)
        {
            var encargado = await _encargadoService.GetEncargadoByIdASync(Id);
            if (encargado == null)
            {
                return NotFound();
            }
            return Ok(encargado);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> /*Create*/CrearEncargado([FromBody] EncargadoDto encargadoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdEncargado = await _encargadoService.CreateEncargadoAsync(encargadoDto);
            return CreatedAtAction(nameof(GetById), new { id = createdEncargado.Id }, createdEncargado);
        }
        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> /*Update*/ObtenerEncargado(int Id, [FromBody] UpdateEncargadoDto updateEncargadoDto)
        {
            if (Id != updateEncargadoDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _encargadoService.UpdateEncargadoAsync(updateEncargadoDto);
            return NoContent();

        }
    }
}




