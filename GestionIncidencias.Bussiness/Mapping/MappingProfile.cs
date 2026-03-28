using AutoMapper;
using GestionIncidencias.Domain.DTO.Requests;
using GestionIncidencias.Domain.DTO.Responses;
using GestionIncidencias.Domain.Entities;
using GestionIncidencias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace GestionIncidencias.Bussiness.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IncidenciaDto, Incidencia>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.FechaIncidencia, opt => opt.MapFrom(src => DateTime.Now))
           .ForMember(dest => dest.Prioridad, opt => opt.MapFrom(src => (Prioridad)src.IdPrioridad))
           .ForMember(dest => dest.IdTipoIncidencia, opt => opt.MapFrom(src => src.IdTipoIncidencia))
           .ForMember(dest => dest.IdEstado, opt => opt.MapFrom(src => src.IdEstado))
           .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
           .ForMember(dest => dest.IdTipoSolucion, opt => opt.Ignore())
           .ForMember(dest => dest.DescripcionSolucion, opt => opt.Ignore());

            CreateMap<Incidencia, IncidenciaResponsesDto>()                
           .ForMember(dest => dest.FechaIncidencia, opt => opt.MapFrom(src => src.FechaIncidencia))
           .ForMember(dest => dest.TipoIncidencia,opt => opt.MapFrom(src => src.TipoIncidencia != null ? src.TipoIncidencia.Tipo.ToString() : "Sin Tipo"))
           .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario != null ? $"{src.Usuario.Nombre}{src.Usuario.Apellido}" : "Sin Usuario"))
           .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado != null ? src.Estado.Solicitud.ToString() : "Sin estado"));
          
            CreateMap<IncidenciaResolverDto, Incidencia>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateIncidenciaDto, Incidencia>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Usuario, UsuarioDto>()
           .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.Id));

            CreateMap<UsuarioDto, Usuario>()
           .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateUsuarioDto, Usuario>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUsuario));
            CreateMap<Usuario, UsuarioResponsesDto>();

            CreateMap<FlujoIncidenciasDto, FlujoIncidencia>();
            CreateMap<UpdateFlujoIncidenciaDto, FlujoIncidencia>();
            CreateMap<FlujoIncidencia, FlujoIncidenciasResponsesDto>()
           .ForMember(dest => dest.NombreEncargado, opt => opt.MapFrom(src => src.Encargado != null ? src.Encargado.Nombre : "Sin Encargado"))
           .ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => src.Estado != null ? src.Estado.Solicitud.ToString() : "Sin Tipo de Solución"));

            CreateMap<EncargadoDto, Encargado>();
            CreateMap<UpdateEncargadoDto, Encargado>();
            CreateMap<Encargado, EncargadoResponsesDto>();

            CreateMap<TipoSolucionDto, TipoSolucion>();
            CreateMap<UpdateTipoSolucionDto, TipoSolucion>();
            CreateMap<TipoSolucion, TipoSolucionResponsesDto>();

            CreateMap<EstadoDto, Estado>();
            CreateMap<Estado, EstadoResponsesDto>();
            CreateMap<UpdateEstadoDto, Estado>();

            CreateMap<TipoIncidenciaDto, TipoIncidencia>();
            CreateMap<TipoIncidencia, TipoIncidenciaResponsesDto>();
            CreateMap<UpdateTipoIncidenciaDto, TipoIncidencia>();
        }
    }
}
