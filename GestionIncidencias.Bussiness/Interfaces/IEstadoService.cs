using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Interfaces
{
    public interface IEstadoService
    {
        Task<EstadoResponsesDto> GetEstadoByIdASync(int id);
        Task<List<EstadoResponsesDto>> GetAllEstadoAsync();
        Task<EstadoResponsesDto> CreateEstadoAsync(EstadoDto estadoDto);
        Task UpdateEstadoAsync(UpdateEstadoDto updateestadoDto);
    }
}
