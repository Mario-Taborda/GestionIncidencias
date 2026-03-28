using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Requests
{
    public class UpdateIncidenciaDto
    {
        public int Id { get; set; }
        public string Requerimiento { get; set; } = string.Empty;
        public string DescripcionProblema { get; set; } = string.Empty;
        public DateTime FechaIncidencia { get; set; } = DateTime.Now;
        public Prioridad Prioridad { get; set; }
        public int IdTipoIncidencia { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
        public int? IdTipoSolucion { get; set; }
        public string? DescripcionSolucion { get; set; } = string.Empty;
        public string UsuarioFuente { get; set; } = string.Empty;
        public string TipoFuente { get; set; } = string.Empty;
        public string? ImagenBase64 { get; set; }

    }
}
