using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Interfaces
{
    public interface IEncargadoService
    {
        Task<EncargadoResponsesDto> GetEncargadoByIdASync(int id);
        Task<List<EncargadoResponsesDto>> GetAllEncargadoAsync();
        Task<EncargadoResponsesDto> CreateEncargadoAsync(EncargadoDto encargadoDto);
        Task UpdateEncargadoAsync(UpdateEncargadoDto updateencargadoDto);
    }
}
