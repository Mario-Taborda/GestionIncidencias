using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionIncidencias.Domain.DTO.Requests
{
    public class IncidenciaDto
    {
        public string Requerimiento { get; set; } = string.Empty;
        public string DescripcionProblema { get; set; } = string.Empty;
        public DateTime FechaIncidencia { get; set; }

        [JsonPropertyName("IdPrioridad")]
        public int IdPrioridad { get; set; }

        [JsonPropertyName("IdTipoIncidencia")]
        public int IdTipoIncidencia { get; set; }

        [JsonPropertyName("IdUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("IdEstado")]
        public int IdEstado { get; set; }
        public string UsuarioFuente { get; set; } = string.Empty;
        public string TipoFuente { get; set; } = string.Empty;
        public string? ImagenBase64 { get; set; }
    }
}
