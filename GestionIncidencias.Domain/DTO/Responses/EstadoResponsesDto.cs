using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Responses
{
    public class EstadoResponsesDto
    {
        public int Id { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
