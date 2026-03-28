using GestionIncidencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Interfaz
{
    public interface IIncidenciaRepository

    {
        Task<Incidencia?> GetIncidenciaByIdWithDetailsAsync(int id);
        Task<IEnumerable<Incidencia>> GetAllAsync();
        Task<Incidencia> AddAsync(Incidencia incidencia);
        Task<Incidencia> UpdateAsync(Incidencia incidencia);
    }
}
