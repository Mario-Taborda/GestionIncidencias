using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponsesDto> GetUsuarioByIdASync(int id);
        Task<List<UsuarioResponsesDto>> GetAllUsuarioAsync();
        Task<UsuarioResponsesDto> CreateUsuarioAsync(UsuarioDto usuarioDto);
        Task UpdateUsuarioAsync(UpdateUsuarioDto updateusuarioDto);
        Task<bool> ValidarCredencialesAsync(string email, string password);
        Task<bool> ActualizarPasswordAsync(string email, string nuevaPasswordHash);
    }
}
