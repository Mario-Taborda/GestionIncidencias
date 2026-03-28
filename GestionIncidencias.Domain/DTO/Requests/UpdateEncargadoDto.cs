using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Requests
{
    public class UpdateEncargadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
