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

    public class FlujoIncidenciaController(FlujoIncidenciaService flujoIncidenciaService) : ControllerBase
    {
        private readonly FlujoIncidenciaService _flujoIncidenciaService = flujoIncidenciaService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FlujoIncidencia>>> GetFlujoIncidencia()
        {
            var FlujoIncidencia = await _flujoIncidenciaService.GetAllFlujoIncidenciaAsync();
            return Ok(FlujoIncidencia);
        }
        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int Id)
        {
            var flujoIncidencia = await _flujoIncidenciaService.GetFlujoIncidenciaByIdASync(Id);
            if (flujoIncidencia == null)
            {
                return NotFound();
            }
            return Ok(flujoIncidencia);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> /*Create*/CrearFlujoIncidencia([FromBody] FlujoIncidenciasDto flujoIncidenciaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdFlujoIncidencia = await _flujoIncidenciaService.CreateFlujoIncidenciaAsync(flujoIncidenciaDto);
                return CreatedAtAction(nameof(GetById), new { id = createdFlujoIncidencia.Id }, createdFlujoIncidencia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el flujo de incidencia: {ex.Message}");
            }
        }
        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> /*Update*/ObtenerFlujoIncidencia(int Id, [FromBody] UpdateFlujoIncidenciaDto updateFlujoIncidenciaDto)
        {
            if (Id != updateFlujoIncidenciaDto.Id)
            {
                return BadRequest("El Id de la Url no Coinciden");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             var result = await _flujoIncidenciaService.UpdateFlujoIncidenciaAsync(updateFlujoIncidenciaDto);

            if (result == null)
            {
                return NotFound($"No Se Encontro el Flujo con Id {Id}");
            }

            return NoContent();

        }
    }
}




