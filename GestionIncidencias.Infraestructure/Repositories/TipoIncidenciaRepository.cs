using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Domain.Interfaz;
using GestionIncidencias.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Infraestructure.Repositories
{
    public class TipoIncidenciaRepository(AppDbContext context) : ITipoIncidenciaRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<TipoIncidencia> AddAsync(TipoIncidencia TipoIncidencia)
        {
            await _context.TipoIncidencia.AddAsync(TipoIncidencia);
            await _context.SaveChangesAsync();
            return TipoIncidencia;
        }
        public async Task<IEnumerable<TipoIncidencia>> GetAllAsync()
        {
            return await _context.TipoIncidencia.ToListAsync();
        }

        public async Task<TipoIncidencia> GetByIdAsync(int id)
        {
            var TipoIncidencia = await _context.TipoIncidencia.FindAsync(id);
            return TipoIncidencia!;
        }

        public async Task<TipoIncidencia> UpdateAsync(TipoIncidencia TipoIncidencia)
        {
            _context.TipoIncidencia.Update(TipoIncidencia);
            await _context.SaveChangesAsync();
            return TipoIncidencia;

        }
    }
}


