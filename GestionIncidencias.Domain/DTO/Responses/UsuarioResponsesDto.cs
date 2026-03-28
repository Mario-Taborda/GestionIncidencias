using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.DTO.Responses
{
   public class UsuarioResponsesDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }
}
