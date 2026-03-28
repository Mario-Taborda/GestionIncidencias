using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata.Ecma335;

namespace GestionIncidencias.Domain.Entities
{
    public class Incidencia
    {
        public int Id { get; set; }
        public string Requerimiento { get; set; } = string.Empty;
        public string DescripcionProblema { get; set; } = string.Empty;
        public string?  ImagenBase64 { get; set; }
        public DateTime FechaIncidencia { get; set; } = DateTime.Now;
        public Prioridad Prioridad { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("IdTipoIncidencia")]
        public int? IdTipoIncidencia { get; set; }
        public TipoIncidencia? TipoIncidencia { get; set; }
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado? Estado { get; set; }
        public int? IdTipoSolucion { get; set; }

        [ForeignKey("IdTipoSolucion")]
        public TipoSolucion? TipoSolucion { get; set; }
        public string? DescripcionSolucion { get; set; } = string.Empty;
        public string UsuarioFuente { get; set; } = string.Empty;
        public string TipoFuente { get; set; } = string.Empty;

    }
}
