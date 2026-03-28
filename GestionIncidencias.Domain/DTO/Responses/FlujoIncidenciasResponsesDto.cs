using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Responses
{
    public class FlujoIncidenciasResponsesDto
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string NombreEncargado { get; set; } = string.Empty;
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
        public int IdIncidencia { get; set; }

    }
}
