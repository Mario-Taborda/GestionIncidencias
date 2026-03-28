using GestionIncidencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Interfaz
{
   public interface ITipoIncidenciaRepository
    {
        Task<TipoIncidencia> GetByIdAsync(int id);
        Task<IEnumerable<TipoIncidencia>> GetAllAsync();
        Task<TipoIncidencia> AddAsync(TipoIncidencia tipoIncidencia);
        Task<TipoIncidencia> UpdateAsync(TipoIncidencia tipoIncidencia);
    }
}
