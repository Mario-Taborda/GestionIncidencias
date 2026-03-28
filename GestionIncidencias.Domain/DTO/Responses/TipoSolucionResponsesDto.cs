using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Responses
{
    public class TipoSolucionResponsesDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
