using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }
}