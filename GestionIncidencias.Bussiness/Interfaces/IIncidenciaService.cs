using GestionIncidencias.Domain.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using GestionIncidencias.Bussiness.Interfaces;
using GestionIncidencias.Domain.DTO.Requests;


namespace GestionIncidencias.Bussiness.Interfaces
{
    public interface IIncidenciaService
    {
        Task<IncidenciaResponsesDto> GetIncidenciaByIdASync(int id);
        Task<List<IncidenciaResponsesDto>> GetAllIncidenciaAsync();
        Task<IncidenciaResponsesDto> GuardarIncidenciaAsync(IncidenciaDto incidenciaDto);
        Task<IncidenciaResponsesDto> ResponderIncidenciaAsync(IncidenciaResolverDto incidenciaResolverDto);
        Task UpdateIncidenciaAsync(UpdateIncidenciaDto updateIncidenciaDto);
    }
}
