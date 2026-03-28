using GestionIncidencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Interfaz
{
    public interface IFlujoIncidenciaRepository
    {
        Task<FlujoIncidencia> GetByIdAsync(int id);
        Task<IEnumerable<FlujoIncidencia>> GetAllAsync();
        Task<FlujoIncidencia> AddAsync(FlujoIncidencia flujoIncidencia);
        Task<FlujoIncidencia> UpdateAsync(FlujoIncidencia flujoIncidencia);
    }
}
