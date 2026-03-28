using AutoMapper;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Infraestructure.Data;
using GestionIncidencias.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionIncidencias.Bussiness.Services
{
    public class IncidenciaService(IncidenciaRepository incidenciaRepository, IMapper mapper, AppDbContext context) : IIncidenciaService
    {
        private readonly IncidenciaRepository _incidenciaRepository = incidenciaRepository;
        private readonly IMapper _mapper = mapper;
        private readonly AppDbContext _context = context;
        public async Task<IncidenciaResponsesDto> GuardarIncidenciaAsync(IncidenciaDto incidenciaDto)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                await ValidarEntidadesExistentes(incidenciaDto);
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var nuevaIncidencia = _mapper.Map<Incidencia>(incidenciaDto);
                    nuevaIncidencia.FechaIncidencia = DateTime.Now;
            
                    var incidenciaCreada = await _incidenciaRepository.AddAsync(nuevaIncidencia);
                    await _context.SaveChangesAsync();

                    var flujo = new FlujoIncidencia
                    {
                        IdIncidencia = incidenciaCreada.Id, 
                        IdEstado = incidenciaCreada.IdEstado,
                        IdEncargado = null, 
                        FechaMovimiento = DateTime.Now,
                    };

                    _context.FlujoIncidencia.Add(flujo);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return _mapper.Map<IncidenciaResponsesDto>(incidenciaCreada);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }
        public async Task<IncidenciaResponsesDto> ResponderIncidenciaAsync(IncidenciaResolverDto responderIncidenciaDto)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var incidencia = await _context.Incidencia.FindAsync(responderIncidenciaDto.Id);
                    if (incidencia == null) throw new KeyNotFoundException("Incidencia no Encontrada.");

                    incidencia.IdTipoIncidencia = responderIncidenciaDto.IdTipoIncidencia;
                    incidencia.DescripcionSolucion = responderIncidenciaDto.Descripcionsolucion;
                    incidencia.IdTipoSolucion = responderIncidenciaDto.IdTipoSolucion;
                    incidencia.IdEstado = responderIncidenciaDto.IdEstado;

                    var flujo = new FlujoIncidencia
                    {
                        IdIncidencia = incidencia.Id,
                        IdEstado = incidencia.IdEstado,
                        IdEncargado = responderIncidenciaDto.IdEncargado,
                        FechaMovimiento = DateTime.Now,
                    };

                    _context.FlujoIncidencia.Add(flujo);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _context.ChangeTracker.Clear();

                    var incidenciacompleta = await _incidenciaRepository.GetIncidenciaByIdWithDetailsAsync(incidencia.Id);
                    return _mapper.Map<IncidenciaResponsesDto>(incidenciacompleta);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }
        private async Task ValidarEntidadesExistentes(IncidenciaDto dto)
        {
            if (!await _context.Usuario.AnyAsync(u => u.Id == dto.IdUsuario))
                throw new KeyNotFoundException($"El usuario con ID {dto.IdUsuario} no existe.");

            if (!await _context.TipoIncidencia.AnyAsync(d => d.Id == dto.IdTipoIncidencia))
                throw new KeyNotFoundException($"El TipoIncidencia con ID {dto.IdTipoIncidencia} no existe.");

            if (!await _context.Estado.AnyAsync(e => e.Id == dto.IdEstado))
                throw new KeyNotFoundException($"El Estado con ID {dto.IdEstado} no existe.");
        }
        public async Task<List<IncidenciaResponsesDto>> GetAllIncidenciaAsync()
        {
            var incidencias = await _incidenciaRepository.GetAllAsync();
            return _mapper.Map<List<IncidenciaResponsesDto>>(incidencias);
        }
        public async Task<IncidenciaResponsesDto> GetIncidenciaByIdASync(int id)
        {
            var incidencia = await _incidenciaRepository.GetIncidenciaByIdWithDetailsAsync(id);
            return _mapper.Map<IncidenciaResponsesDto>(incidencia);
        }
        public async Task UpdateIncidenciaAsync(UpdateIncidenciaDto updateIncidenciaDto)
        {
            var incidenciaExistente = await _context.Incidencia.FindAsync(updateIncidenciaDto.Id);
            if (incidenciaExistente == null) throw new KeyNotFoundException();

            _mapper.Map(updateIncidenciaDto, incidenciaExistente);
            await _incidenciaRepository.UpdateAsync(incidenciaExistente);
        }
    }   
}