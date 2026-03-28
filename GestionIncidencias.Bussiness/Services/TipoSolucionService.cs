using AutoMapper;
using GestionTipoSolucions.Bussiness.Interfaces;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Services
{
    public class TipoSolucionService(TipoSolucionRepository tipoSolucionRepository, IMapper mapper) : ITipoSolucionService
    {
       private readonly TipoSolucionRepository _TipoSolucionRepository = tipoSolucionRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<TipoSolucionResponsesDto> CreateTipoSolucionAsync(TipoSolucionDto tipoSolucionDto)
        {
            var tipoSolucion = _mapper.Map<TipoSolucion>(tipoSolucionDto);
            var createTipoSolucion = await _TipoSolucionRepository.AddAsync(tipoSolucion);
            return _mapper.Map<TipoSolucionResponsesDto>(createTipoSolucion);
        }

        public async Task<List<TipoSolucionResponsesDto>> GetAllTipoSolucionAsync()
        {
            var tipoSolucion = await _TipoSolucionRepository.GetAllAsync();
            return _mapper.Map<List<TipoSolucionResponsesDto>>(tipoSolucion);
        }
        public async Task<TipoSolucionResponsesDto> GetTipoSolucionByIdASync(int id)
        {
            var tipoSolucion = await _TipoSolucionRepository.GetByIdAsync(id);
            return _mapper.Map<TipoSolucionResponsesDto>(tipoSolucion);
        }
        public async Task UpdateTipoSolucionAsync(UpdateTipoSolucionDto updateTipoSolucionDto)
        {
            var tipoSolucion = _mapper.Map<TipoSolucion>(updateTipoSolucionDto);
            await _TipoSolucionRepository.UpdateAsync(tipoSolucion); 
        }
    }
}
