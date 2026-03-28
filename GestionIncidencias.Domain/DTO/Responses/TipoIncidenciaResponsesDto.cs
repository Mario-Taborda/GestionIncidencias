using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Responses
{
    public class TipoIncidenciaResponsesDto
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; }
    }
}
