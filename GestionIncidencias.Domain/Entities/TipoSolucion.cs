using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Entities
{
    public class TipoSolucion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public TipoResolucionIncidencia Incidencia { get; set; }
    }
}
