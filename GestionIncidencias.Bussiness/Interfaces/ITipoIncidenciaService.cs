using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionTipoIncidencias.Bussiness.Interfaces
{
    public interface ITipoIncidenciaService
    {
        Task<TipoIncidenciaResponsesDto> GetTipoIncidenciaByIdASync(int id);
        Task<List<TipoIncidenciaResponsesDto>> GetAllTipoIncidenciaAsync();
        Task<TipoIncidenciaResponsesDto> CreateTipoIncidenciaAsync(TipoIncidenciaDto tipoIncidenciaDto);
        Task UpdateTipoIncidenciaAsync(UpdateTipoIncidenciaDto updateTipoIncidenciaDto);

    }
}
