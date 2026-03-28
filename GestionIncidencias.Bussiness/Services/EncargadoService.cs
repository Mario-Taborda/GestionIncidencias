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
    public class EncargadoService(EncargadoRepository encargadoRepository, IMapper mapper) : IEncargadoService
    {
        private readonly EncargadoRepository _encargadoRepository = encargadoRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<EncargadoResponsesDto> CreateEncargadoAsync(EncargadoDto encargadoDto)
        {
            var encargado = _mapper.Map<Encargado>(encargadoDto);
            var createEncargado = await _encargadoRepository.AddAsync(encargado);
            return _mapper.Map<EncargadoResponsesDto>(createEncargado);
        }

        public async Task<List<EncargadoResponsesDto>> GetAllEncargadoAsync()
        {
            var encargado = await _encargadoRepository.GetAllAsync();
            return _mapper.Map<List<EncargadoResponsesDto>>(encargado);
        }

        public async Task<EncargadoResponsesDto> GetEncargadoByIdASync(int id)
        {
            var encargado = await _encargadoRepository.GetByIdAsync(id);
            return _mapper.Map<EncargadoResponsesDto>(encargado);
        }

        public async Task UpdateEncargadoAsync(UpdateEncargadoDto updateencargadoDto)
        {
            var encargado = _mapper.Map<Encargado>(updateencargadoDto);
            await _encargadoRepository.UpdateAsync(encargado);
        }
    }
}
