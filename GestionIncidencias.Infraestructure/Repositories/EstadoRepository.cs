using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Domain.Interfaz;
using GestionIncidencias.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Infraestructure.Repositories
{
    public class EstadoRepository(AppDbContext context) : IEstadoRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<Estado> AddAsync(Estado estado)
        {
            await _context.Estado.AddAsync(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _context.Estado.AsNoTracking().ToListAsync();
        }

        public async Task<Estado?> GetByIdAsync(int id)
        {
            return await _context.Estado.FindAsync(id);
        }
        public async Task<Estado?> UpdateAsync(Estado estado)
        {
            var existingEstado = await _context.Estado.FindAsync(estado.Id);
            if (existingEstado == null) 
            {  
                return null;
            }
            _context.Entry(existingEstado).CurrentValues.SetValues(estado);
            await _context.SaveChangesAsync();
            return existingEstado;
        }
    }
}
