using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GestionIncidencias.Domain.Entities
{
    public class FlujoIncidencia
    {
        public int Id { get; set; }
        public DateTime? FechaMovimiento { get; set; } 
        public int? IdEncargado { get; set; }
        [ForeignKey("IdEncargado")]
        public Encargado? Encargado { get; set; } 
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public Estado? Estado { get; set; } 
        public int IdIncidencia { get; set; }
        [ForeignKey("IdIncidencia")]
        public Incidencia? Incidencia { get; set; } 

    }
}
