using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Requests
{
    public class UpdateTipoSolucionDto
    {
       public int Id { get; set; }
       public string Descripcion { get; set; } = string.Empty;
    }
}
