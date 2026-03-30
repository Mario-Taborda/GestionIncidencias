using GestionIncidencias.Bussiness.Interfaces;
using ClosedXML.Excel;
using System.IO;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionIncidencias.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class IncidenciaController : ControllerBase
    {
        private readonly IIncidenciaService _incidenciaService;
        public IncidenciaController(IIncidenciaService incidenciaService)
        {
            _incidenciaService = incidenciaService;
        }
        [Authorize]
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<IncidenciaResponsesDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetIncidencia()
        {
            var incidencias = await _incidenciaService.GetAllIncidenciaAsync();
            return Ok(incidencias);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IncidenciaResponsesDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var incidencia = await _incidenciaService.GetIncidenciaByIdASync(id);

            if (incidencia == null)
                return NotFound(new { Message = $"Incidencia con Id {id} no encontrada." });

            return Ok(incidencia);
        }
        [Authorize]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IncidenciaResponsesDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearIncidencia([FromBody] IncidenciaDto incidenciaDto)
        {
            try
            {
                var createdIncidencia = await _incidenciaService.GuardarIncidenciaAsync(incidenciaDto);
                return CreatedAtAction(nameof(GetById), new { id = createdIncidencia.Id }, createdIncidencia);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Error = "Error interno al procesar la solicitud.", Info = ex.Message });
            }
        }

        [HttpPut("responder")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResponderIncidencia([FromBody] IncidenciaResolverDto resolverDto)
        {
            try
            {
                await _incidenciaService.ResponderIncidenciaAsync(resolverDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "No se pudo procesar la respuesta técnica.", Error = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateIncidencia(int id, [FromBody] UpdateIncidenciaDto updateIncidenciaDto)
        {
            if (id != updateIncidenciaDto.Id)
                return BadRequest(new { Message = "El ID de la URL no coincide con el cuerpo de la solicitud." });
            try
            {
                await _incidenciaService.UpdateIncidenciaAsync(updateIncidenciaDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Error al actualizar la incidencia", Detalle = ex.Message });
            }
        }
    

    [HttpGet("exportar")]
        [AllowAnonymous]
        public async Task<IActionResult> ExportarExcel()
        {
            try
            {
       
                var incidencias = await _incidenciaService.GetAllIncidenciaAsync();
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Historial Incidencias");

                worksheet.Cell(1, 1).Value = "N° Ticket";
                worksheet.Cell(1, 2).Value = "Fecha Reporte";
                worksheet.Cell(1, 3).Value = "Usuario Solicitante";
                worksheet.Cell(1, 4).Value = "Tipo Reportado";
                worksheet.Cell(1, 5).Value = "Prioridad";
                worksheet.Cell(1, 6).Value = "Estado Final";

                var headerRange = worksheet.Range("A1:F1");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.DarkBlue;
                headerRange.Style.Font.FontColor = XLColor.White;
                int fila = 2;
                foreach (var inc in incidencias)
                {
                    worksheet.Cell(fila, 1).Value = inc.Id;
                    worksheet.Cell(fila, 2).Value = inc.FechaIncidencia != default ? Convert.ToDateTime(inc.FechaIncidencia).ToString("dd/MM/yyyy HH:mm") : "";
                    worksheet.Cell(fila, 3).Value = inc.NombreUsuario;
                    worksheet.Cell(fila, 4).Value = inc.TipoIncidencia;
                    worksheet.Cell(fila, 5).Value = inc.Prioridad.ToString();
                    worksheet.Cell(fila, 6).Value = inc.Estado;

                    fila++;
                }
                worksheet.Columns().AdjustToContents();

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte_TI_Incidencias.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error al generar el Excel", Detalle = ex.Message });
            }
        }
    }
    }
