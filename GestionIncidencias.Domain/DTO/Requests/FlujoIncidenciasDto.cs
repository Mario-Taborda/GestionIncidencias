using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Requests
{
    public class FlujoIncidenciasDto
    {
        public DateTime FechaMovimiento { get; set; }
        public int IdEncargado { get; set; }
        public int IdEstado { get; set; }
        public int IdIncidencia { get; set; }
    }
}
