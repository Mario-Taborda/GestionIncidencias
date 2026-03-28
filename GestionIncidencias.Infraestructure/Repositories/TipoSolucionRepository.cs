using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Domain.Interfaz;
using GestionIncidencias.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Infraestructure.Repositories
{
    public class TipoSolucionRepository(AppDbContext context) : ITipoSolucionRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<TipoSolucion> AddAsync(TipoSolucion tipoSolucion)
        {
            await _context.TipoSolucion.AddAsync(tipoSolucion);
            await _context.SaveChangesAsync();
            return tipoSolucion;
        }
        public async Task<IEnumerable<TipoSolucion>> GetAllAsync()
        {
            return await _context.TipoSolucion.ToListAsync();
        }

        public async Task<TipoSolucion> GetByIdAsync(int id)
        {
            var tipoSolucion = await _context.TipoSolucion.FindAsync(id);
            return tipoSolucion!;
        }

        public async Task<TipoSolucion> UpdateAsync(TipoSolucion tipoSolucion)
        {
            _context.TipoSolucion.Update(tipoSolucion);
            await _context.SaveChangesAsync();
            return tipoSolucion;

        }
    }
}


