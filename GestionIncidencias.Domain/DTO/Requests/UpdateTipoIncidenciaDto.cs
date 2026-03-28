using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Requests
{
   public class UpdateTipoIncidenciaDto
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; }
    }
}
