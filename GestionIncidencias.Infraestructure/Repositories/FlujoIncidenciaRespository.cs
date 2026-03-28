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
    public class FlujoIncidenciaRespository(AppDbContext context) : IFlujoIncidenciaRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<FlujoIncidencia> AddAsync(FlujoIncidencia flujoIncidencia)
        {
            await _context.FlujoIncidencia.AddAsync(flujoIncidencia);
            await _context.SaveChangesAsync();
            return await GetByIdAsync (flujoIncidencia.Id);
        }
        public async Task<IEnumerable<FlujoIncidencia>> GetAllAsync()
        {
            return await _context.FlujoIncidencia
            .Include(f => f.Encargado)
            .Include(f => f.Estado)
            .Include(f => f.Incidencia)
            .AsNoTracking()
            .ToListAsync();
        }
        public async Task<FlujoIncidencia> GetByIdAsync(int id)
        {
            var flujo = await _context.FlujoIncidencia
                .Include(f => f.Encargado)
                .Include(f => f.Estado)
                .Include(f => f.Incidencia)
                .FirstOrDefaultAsync(f => f.Id == id);

            return flujo!;
        }
        public async Task<FlujoIncidencia> UpdateAsync(FlujoIncidencia flujoIncidencia)
        {
            var existing = await _context.FlujoIncidencia.FindAsync(flujoIncidencia.Id);
            if (existing == null) return null!;

            _context.Entry(existing).CurrentValues.SetValues(flujoIncidencia);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
