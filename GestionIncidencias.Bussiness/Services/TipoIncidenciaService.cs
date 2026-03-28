using AutoMapper;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Infraestructure.Repositories;
using GestionTipoIncidencias.Bussiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Services
{
    public class TipoIncidenciaService(TipoIncidenciaRepository tipoIncidenciaRepository, IMapper mapper) : ITipoIncidenciaService
    {
        private readonly TipoIncidenciaRepository _tipoIncidenciaRepository = tipoIncidenciaRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<TipoIncidenciaResponsesDto> CreateTipoIncidenciaAsync(TipoIncidenciaDto tipoIncidenciaDto)
        {
            var tipoIncidencia = _mapper.Map<TipoIncidencia>(tipoIncidenciaDto);
            var createTipoIncidencia = await _tipoIncidenciaRepository.AddAsync(tipoIncidencia);
            return _mapper.Map<TipoIncidenciaResponsesDto>(createTipoIncidencia);
        }

        public async Task<List<TipoIncidenciaResponsesDto>> GetAllTipoIncidenciaAsync()
        {
            var tipoIncidencia = await _tipoIncidenciaRepository.GetAllAsync();
            return _mapper.Map<List<TipoIncidenciaResponsesDto>>(tipoIncidencia);
        }

        public async Task<TipoIncidenciaResponsesDto> GetTipoIncidenciaByIdASync(int id)
        {
            var tipoIncidencia = await _tipoIncidenciaRepository.GetByIdAsync(id);
            return _mapper.Map<TipoIncidenciaResponsesDto>(tipoIncidencia);
        }

        public async Task UpdateTipoIncidenciaAsync(UpdateTipoIncidenciaDto updateTipoIncidenciaDto)
        {
            var tipoIncidencia = _mapper.Map<TipoIncidencia>(updateTipoIncidenciaDto);
            await _tipoIncidenciaRepository.UpdateAsync(tipoIncidencia);
        }
    }
}
