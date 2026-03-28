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
    public class EncargadoRepository(AppDbContext context) : IEncargadoRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<Encargado> AddAsync(Encargado encargado)
        {
            await _context.Encargado.AddAsync(encargado);
            await _context.SaveChangesAsync();
            return encargado;
        }
        public async Task<IEnumerable<Encargado>> GetAllAsync()
        {
            return await _context.Encargado.ToListAsync();
        }

        public async Task<Encargado> GetByIdAsync(int id)
        {
            var encargado = await _context.Encargado.FindAsync(id);
            return encargado!;
        }

        public async Task<Encargado> UpdateAsync(Encargado encargado)
        {
            _context.Encargado.Update(encargado);
            await _context.SaveChangesAsync();
            return encargado;
        }
    }
}
