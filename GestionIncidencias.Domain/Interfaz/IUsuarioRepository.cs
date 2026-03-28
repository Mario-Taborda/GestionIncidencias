using GestionIncidencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Domain.Interfaz
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
    }
}
