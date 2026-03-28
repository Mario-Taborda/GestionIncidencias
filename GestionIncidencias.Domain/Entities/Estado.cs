 using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Entities
{
    public class Estado
    {
        public int Id { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
