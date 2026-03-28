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

    public class TipoIncidenciaController(TipoIncidenciaService tipoIncidenciaService) : ControllerBase
    {
        private readonly TipoIncidenciaService _tipoIncidenciaService = tipoIncidenciaService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TipoIncidencia>>> GetTipoIncidencia()
        {
            var tipoIncidencia = await _tipoIncidenciaService.GetAllTipoIncidenciaAsync();
            return Ok(tipoIncidencia);
        }
        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int Id)
        {
            var tipoIncidencia = await _tipoIncidenciaService.GetTipoIncidenciaByIdASync(Id);
            if (tipoIncidencia == null)
            {
                return NotFound();
            }
            return Ok(tipoIncidencia);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> /*Create*/CrearTipoIncidencia([FromBody] TipoIncidenciaDto tipoIncidenciaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTipoIncidencia = await _tipoIncidenciaService.CreateTipoIncidenciaAsync(tipoIncidenciaDto);
            return CreatedAtAction(nameof(GetById), new { id = createdTipoIncidencia.Id }, createdTipoIncidencia);
        }
        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> /*Update*/ObtenerTipoIncidencia(int Id, [FromBody] UpdateTipoIncidenciaDto updateTipoIncidenciaDto)
        {
            if (Id != updateTipoIncidenciaDto.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _tipoIncidenciaService.UpdateTipoIncidenciaAsync(updateTipoIncidenciaDto);
            return NoContent();

        }
    }
}



