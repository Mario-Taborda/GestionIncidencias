using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionTipoSolucions.Bussiness.Interfaces
{
    public interface ITipoSolucionService
    {
        Task<TipoSolucionResponsesDto> GetTipoSolucionByIdASync(int id);
        Task<List<TipoSolucionResponsesDto>> GetAllTipoSolucionAsync();
        Task<TipoSolucionResponsesDto> CreateTipoSolucionAsync(TipoSolucionDto tipoSolucionDto);
        Task UpdateTipoSolucionAsync(UpdateTipoSolucionDto updateTipoSolucionDto);

    }
}
