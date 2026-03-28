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
    public class UsuarioService(UsuarioRepository usuarioRepository, IMapper mapper) : IUsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<UsuarioResponsesDto> CreateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var createUsuario = await _usuarioRepository.AddAsync(usuario);
            return _mapper.Map<UsuarioResponsesDto>(createUsuario);
        }

        public async Task<List<UsuarioResponsesDto>> GetAllUsuarioAsync()
        {
            var usuario = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<List<UsuarioResponsesDto>>(usuario);
        }

        public async Task<UsuarioResponsesDto> GetUsuarioByIdASync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioResponsesDto>(usuario);
        }

        public async Task UpdateUsuarioAsync(UpdateUsuarioDto updateusuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(updateusuarioDto);
            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
