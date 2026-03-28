using GestionIncidencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Interfaz
{
    public interface ITipoSolucionRepository
    {
        Task<TipoSolucion> GetByIdAsync(int id);
        Task<IEnumerable<TipoSolucion>> GetAllAsync();
        Task<TipoSolucion> AddAsync(TipoSolucion tipoSolucion);
        Task<TipoSolucion> UpdateAsync(TipoSolucion tipoSolucion);
    }
}
