using AutoMapper;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Services
{
    public class FlujoIncidenciaService(FlujoIncidenciaRespository flujoIncidenciaRespository, IMapper mapper) : IFlujoIncidenciaService
    {
        private readonly FlujoIncidenciaRespository _flujoIncidenciaRepository = flujoIncidenciaRespository;
        private readonly IMapper _mapper = mapper;
        public async Task<FlujoIncidenciasResponsesDto> CreateFlujoIncidenciaAsync(FlujoIncidenciasDto flujoIncidenciaDto)
        {
            var flujoincidencia = _mapper.Map<FlujoIncidencia>(flujoIncidenciaDto);
            var createFlujoIncidencia = await _flujoIncidenciaRepository.AddAsync(flujoincidencia);
            return _mapper.Map<FlujoIncidenciasResponsesDto>(createFlujoIncidencia);
        }

        public async Task<IEnumerable<FlujoIncidenciasResponsesDto>> GetAllFlujoIncidenciaAsync()
        {
            var flujoincidencia = await _flujoIncidenciaRepository.GetAllAsync();
            return _mapper.Map<List<FlujoIncidenciasResponsesDto>>(flujoincidencia);
        }

        public async Task<FlujoIncidenciasResponsesDto> GetFlujoIncidenciaByIdASync(int id)
        {
            var flujoincidencia = await _flujoIncidenciaRepository.GetByIdAsync(id);
            return _mapper.Map<FlujoIncidenciasResponsesDto>(flujoincidencia);
        }

        public async Task<FlujoIncidenciasResponsesDto>UpdateFlujoIncidenciaAsync(UpdateFlujoIncidenciaDto updateflujoIncidenciaDto)
        {
            var flujoincidencia = _mapper.Map<FlujoIncidencia>(updateflujoIncidenciaDto);
            var actulizado = await _flujoIncidenciaRepository.UpdateAsync(flujoincidencia);
            return _mapper.Map<FlujoIncidenciasResponsesDto>(actulizado);
        }
    }
}
