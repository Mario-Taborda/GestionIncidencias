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

    public class TipoSolucionController(TipoSolucionService tipoSolucionService) : ControllerBase
    {
        private readonly TipoSolucionService _tipoSolucionService = tipoSolucionService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TipoSolucion>>> GetTipoSolucion()
        {
            var tipoSolucion = await _tipoSolucionService.GetAllTipoSolucionAsync();
            return Ok(tipoSolucion);
        }
        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int Id)
        {
            var tipoSolucion = await _tipoSolucionService.GetTipoSolucionByIdASync(Id);
            if (tipoSolucion == null)
            {
                return NotFound();
            }
            return Ok(tipoSolucion);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> /*Create*/CrearTipoSolucion([FromBody] TipoSolucionDto tipoSolucionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTipoSolucion = await _tipoSolucionService.CreateTipoSolucionAsync(tipoSolucionDto);
            return CreatedAtAction(nameof(GetById), new { id = createdTipoSolucion.Id }, createdTipoSolucion);
        }
        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> /*Update*/ObtenerTipoSolucion(int Id, [FromBody] UpdateTipoSolucionDto updateTipoSolucionDto)
        {
            if (Id != updateTipoSolucionDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _tipoSolucionService.UpdateTipoSolucionAsync(updateTipoSolucionDto);
            return NoContent();

        }
    }
}



