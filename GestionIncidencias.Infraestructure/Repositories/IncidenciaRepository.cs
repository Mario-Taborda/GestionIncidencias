using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Domain.Interfaz;
using GestionIncidencias.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionIncidencias.Infraestructure.Repository
{
    public class IncidenciaRepository(AppDbContext context) : IIncidenciaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Incidencia> AddAsync(Incidencia incidencia)
        {
            await _context.Incidencia.AddAsync(incidencia);
            await _context.SaveChangesAsync();
            return incidencia;
        }

        public async Task<IEnumerable<Incidencia>> GetAllAsync()
        {
            return await _context.Incidencia
                .AsNoTracking() 
                .Include(i => i.Usuario)
                .Include(i => i.Estado)
                .Include(i => i.TipoIncidencia)
                .ToListAsync();
        }

        public async Task<Incidencia?> GetIncidenciaByIdWithDetailsAsync(int id)
        {
            return await _context.Incidencia
                .AsNoTracking()
                .Include(i => i.Usuario)
                .Include(i => i.Estado)
                .Include(i => i.TipoIncidencia)
                .Include(i => i.TipoSolucion)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Incidencia> UpdateAsync(Incidencia incidencia)
        {
            _context.Entry(incidencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return incidencia;
        }
    }
}