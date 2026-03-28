using AutoMapper;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Domain.Interfaz;
using GestionIncidencias.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Services
{
    public class EstadoService(EstadoRepository estadoRepository, IMapper mapper) : IEstadoService
    {
        private readonly EstadoRepository _estadoRepository = estadoRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<EstadoResponsesDto> CreateEstadoAsync(EstadoDto estadoDto)
        {
            var estado = _mapper.Map<Estado>(estadoDto);
            var createEstado = await _estadoRepository.AddAsync(estado);
            return _mapper.Map<EstadoResponsesDto>(createEstado);
        }

        public async Task<List<EstadoResponsesDto>> GetAllEstadoAsync()
        {
            var estado = await _estadoRepository.GetAllAsync();
            return _mapper.Map<List<EstadoResponsesDto>>(estado);
        }

        public async Task<EstadoResponsesDto> GetEstadoByIdASync(int id)
        {
            var estado = await _estadoRepository.GetByIdAsync(id);
            return _mapper.Map<EstadoResponsesDto>(estado);
        }

        public async Task UpdateEstadoAsync(UpdateEstadoDto updateestadoDto)
        {
            var estado = _mapper.Map<Estado>(updateestadoDto);
            await _estadoRepository.UpdateAsync(estado);
        }
    }
}
