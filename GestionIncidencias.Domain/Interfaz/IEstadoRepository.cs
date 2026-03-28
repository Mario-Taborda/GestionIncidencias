using GestionIncidencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Interfaz
{
    public interface IEstadoRepository
    {
        Task<Estado?> GetByIdAsync(int id);
        Task<IEnumerable<Estado>> GetAllAsync();
        Task<Estado> AddAsync(Estado estado);
        Task<Estado?> UpdateAsync(Estado estado);
    }
}
