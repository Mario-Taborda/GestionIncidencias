using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionIncidencias.Domain.Entities
{
    public class Empresa
    {
        [Key]
        public string NitEmp { get; set; } = string.Empty; 
        public int Codigo { get; set; } 
        public string Nombre { get; set; } = string.Empty; 
        public string? Sigla { get; set; } 
        public string? Representante { get; set; } 
        public string? NomRep { get; set; } 
        public string? Direccion { get; set; } 
        public string? Telefono { get; set; } 
        public string? Fax { get; set; } 
        public string? Modem { get; set; } 
        public int? ApaAer { get; set; } 
        public string? Email { get; set; } 
        public int? NumTra { get; set; } 
        public int? PerJuridica { get; set; } 
        public int? EscPub { get; set; } 
        public string? CodigoRegi { get; set; } 
        public short? CodigoZona { get; set; } 
        public short? ActividadTipo { get; set; } 
        public short Estado { get; set; } 
        public DateTime FecMat { get; set; } 
        public DateTime? FecRet { get; set; } 
        public DateTime? FecConst { get; set; } 
        public bool? CenCosObligatorio { get; set; }
        public string? MailFacturacion { get; set; } 
        public string? CelularFacturacion { get; set; } 
        public string? ContactoFacturacion { get; set; } 
        public short? DctoTipoRep { get; set; } 
        public DateTime? FecExpRep { get; set; } 
        public string? ExpedicionRegiRep { get; set; } 
        public string? TelefonoRep { get; set; } 
        public string? CelularRep { get; set; } 
        public string? MailRep { get; set; } 
        public string? DireccionRep { get; set; } 
        public bool? RepEsSocio { get; set; } 
        public bool? RepEsPersonaPolExp { get; set; } 
        public short? SectorEconomico { get; set; } 
        public short? NaturalezaJuridica { get; set; } 
        public short? TipoDeSociedad { get; set; } 
        public short? ClasificacionEmpresa { get; set; } 
        public int? NroSocios { get; set; } 
        public int? NroEmpAdmon { get; set; } 
        public int? NroEmpOper { get; set; } 
        public int? NroEmpConInd { get; set; } 
        public int? NroEmpConFij { get; set; } 
        public int? NroEmpOtroCon { get; set; } 
        public short? TipoSede { get; set; } 
        public decimal? VentasAnuales { get; set; }
        public decimal? GastosAnuales { get; set; }
        public decimal? Activos { get; set; }
        public decimal? Pasivos { get; set; }
        public decimal? Patrimonio { get; set; }
        public decimal? CapSocial { get; set; }
        public decimal? IngMensuales { get; set; }
        public decimal? EgrMensuales { get; set; }
        public decimal? IngNoOperMensuales { get; set; }
        public decimal? EgrNoOperMensuales { get; set; }
        public short? Periodo { get; set; } 
        public bool? OperMonExt { get; set; } 
        public short? IntOperMonExt { get; set; } 
        public bool? CtasMonExt { get; set; } 
        public string? BancoMonExt { get; set; } 
        public string? CtaMonExt { get; set; } 
        public string? MonExt { get; set; }
        public short? DctoTipoContacto { get; set; } 
        public string? DctoContacto { get; set; } 
        public string? NombreContacto { get; set; } 
        public string? TelefonoContacto { get; set; } 
        public string? ExtContacto { get; set; } 
        public string? CelularContacto { get; set; } 
        public string? MailContacto { get; set; } 
        public short? CargoContacto { get; set; } 
        public int? IdUsuario { get; set; } 
    }
}
