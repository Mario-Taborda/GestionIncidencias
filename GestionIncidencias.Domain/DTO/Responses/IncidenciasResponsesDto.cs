using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using GestionIncidencias.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace GestionIncidencias.Domain.DTO.Responses
{
   public class IncidenciaResponsesDto
    {
        public int Id { get; set; }
        public string Requerimiento { get; set; } = string.Empty;
        public string DescripcionProblema { get; set; } = string.Empty;
        public string FechaIncidencia { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Prioridad Prioridad { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string TipoIncidencia { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Fuente { get; set; } = string.Empty;
        public string? SolucionTecnica { get; set; }
        public string? DescripcionSolucion { get; set; }
        public string? ImagenBase64 { get; set; }
    }
}
