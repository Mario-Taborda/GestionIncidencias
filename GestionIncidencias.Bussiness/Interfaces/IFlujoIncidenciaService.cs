using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionIncidencias.Bussiness.Interfaces
{
    public interface IFlujoIncidenciaService
    {
        Task<FlujoIncidenciasResponsesDto> GetFlujoIncidenciaByIdASync(int id);
        Task<IEnumerable<FlujoIncidenciasResponsesDto>> GetAllFlujoIncidenciaAsync();
        Task<FlujoIncidenciasResponsesDto> CreateFlujoIncidenciaAsync(FlujoIncidenciasDto flujoIncidenciaDto);
        Task<FlujoIncidenciasResponsesDto> UpdateFlujoIncidenciaAsync(UpdateFlujoIncidenciaDto updateflujoIncidenciaDto);
    }
}
