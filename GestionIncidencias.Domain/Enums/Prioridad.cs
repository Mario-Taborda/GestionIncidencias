using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionIncidencias.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]   
    public enum Prioridad
    {
        Alta = 1,
        Media = 2,
        Baja = 3,
    }
}
