using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Requests
{
    public class UpdateEstadoDto
    {
        public int Id { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
