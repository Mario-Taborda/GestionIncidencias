using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Entities
{
    public class TipoIncidencia
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; }

    }
}