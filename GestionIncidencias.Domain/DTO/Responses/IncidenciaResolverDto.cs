using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Responses
{
    public class IncidenciaResolverDto
    {
        public int Id { get; set; }
        public int IdTipoIncidencia { get; set; }
        public string Descripcionsolucion { get; set; } = string.Empty;
        public int IdTipoSolucion { get; set; }
        public int IdEstado { get; set; }
        public int? IdEncargado { get; set; }
    }
}
