using GestionIncidencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Interfaz
{
    public interface IEncargadoRepository
    {
        Task<Encargado> GetByIdAsync(int id);
        Task<IEnumerable<Encargado>> GetAllAsync();
        Task<Encargado> AddAsync(Encargado encargado);
        Task<Encargado> UpdateAsync(Encargado encargado);
    }
}
