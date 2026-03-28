using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Domain.Interfaz;
using GestionIncidencias.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Infraestructure.Repositories
{
    public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<Usuario> AddAsync(Usuario usuario)
        {
           await _context.Usuario.AddAsync(usuario);
           await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }
        public async Task<Usuario> GetByIdAsync(int id)
        {
           var usuario = await _context.Usuario.FindAsync(id);
            return usuario!;
        }
        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
           _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
