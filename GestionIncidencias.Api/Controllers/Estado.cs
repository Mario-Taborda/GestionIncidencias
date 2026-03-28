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

    public class EstadoController(EstadoService estadoService) : ControllerBase
    {
        private readonly EstadoService _estadoService = estadoService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstado()
        {
            var estado = await _estadoService.GetAllEstadoAsync();
            return Ok(estado);
        }
        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int Id)
        {
            var estado = await _estadoService.GetEstadoByIdASync(Id);
            if (estado == null)
            {
                return NotFound();
            }
            return Ok(estado);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> /*Create*/CrearEstado([FromBody] EstadoDto estadoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdEstado = await _estadoService.CreateEstadoAsync(estadoDto);
            return CreatedAtAction(nameof(GetById), new { id = createdEstado.Id }, createdEstado);
        }
        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> /*Update*/ObtenerEstado(int Id, [FromBody] UpdateEstadoDto updateestadoDto)
        {
            if (Id != updateestadoDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _estadoService.UpdateEstadoAsync(updateestadoDto);
            return NoContent();

        }
    }
}




