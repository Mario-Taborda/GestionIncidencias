using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Enums
{
    public enum TipoResolucionIncidencia
    {
        Definitiva = 1,      
        Workaround = 2,        
        CambioConfiguracion = 3, 
        SustitucionHardware = 4, 
        ReparacionDatos = 5,  
        Capacitacion = 6,
        Sustitucion = 7,
    }
}
    