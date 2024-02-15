﻿using KOF.RouteMap.Application.Common.Mappings;
using ProtoBuf;
namespace KOF.RouteMap.Application.VisitPlan.Queries.GetVisitPlanWithPagination;

[ProtoContract]
public class VisitPlanDto : IMapFrom<Domain.Entities.VisitPlan>
{
    [ProtoMember(1)] public string? NroCliente { get; set; }
    [ProtoMember(2)] public string? NombreCliente { get; set; }
    [ProtoMember(3)] public string? NombreCliente2 { get; set; }
    [ProtoMember(4)] public string? NombreCliente3 { get; set; }
    [ProtoMember(5)] public string? ConcBusq { get; set; }
    [ProtoMember(6)] public string? OrganizacaoVendas { get; set; }
    [ProtoMember(7)] public string? CanalDistribucion { get; set; }
    [ProtoMember(8)] public string? Sector { get; set; }
    [ProtoMember(9)] public string? EstatusCliente { get; set; }
    [ProtoMember(10)] public string? FechaAltaSistema { get; set; }
    [ProtoMember(11)] public string? CreadoPor { get; set; }
    [ProtoMember(12)] public string? ModalidadVentas { get; set; }
    [ProtoMember(13)] public string? IDPlanVisita { get; set; }
    [ProtoMember(14)] public string? InicioVigenciaPlan { get; set; }
    [ProtoMember(15)] public string? FinVigenciaPlan { get; set; }
    [ProtoMember(16)] public string? Ruta { get; set; }
    [ProtoMember(17)] public string? TipoPlanVisita { get; set; }
    [ProtoMember(18)] public string? MetodoVenta { get; set; }
    [ProtoMember(19)] public string? InactivoVisitaPlan { get; set; }
    [ProtoMember(20)] public string? Ritmo { get; set; }
    [ProtoMember(21)] public string? FechaInicioContacto { get; set; }
    [ProtoMember(22)] public string? FechaFinalContacto { get; set; }
    [ProtoMember(23)] public string? VisitaLunes { get; set; }
    [ProtoMember(24)] public string? Lun_de { get; set; }
    [ProtoMember(25)] public string? Lun_a { get; set; }
    [ProtoMember(26)] public string? VisitaMartes { get; set; }
    [ProtoMember(27)] public string? Mar_de { get; set; }
    [ProtoMember(28)] public string? Mar_a { get; set; }
    [ProtoMember(29)] public string? VisitaMiercoles { get; set; }
    [ProtoMember(30)] public string? Mie_de { get; set; }
    [ProtoMember(31)] public string? Mie_a { get; set; }
    [ProtoMember(32)] public string? VisitaJueves { get; set; }
    [ProtoMember(33)] public string? Jue_de { get; set; }
    [ProtoMember(34)] public string? Jue_a { get; set; }
    [ProtoMember(35)] public string? VisitaViernes { get; set; }
    [ProtoMember(36)] public string? Vie_de { get; set; }
    [ProtoMember(37)] public string? Vie_a { get; set; }
    [ProtoMember(38)] public string? VisitaSabado { get; set; }
    [ProtoMember(39)] public string? Sab_de { get; set; }
    [ProtoMember(40)] public string? Sab_a { get; set; }
    [ProtoMember(41)] public string? VisitaDomingo { get; set; }
    [ProtoMember(42)] public string? Dom_de { get; set; }
    [ProtoMember(43)] public string? Dom_a { get; set; }
    [ProtoMember(44)] public string? Dia_de { get; set; }
    [ProtoMember(45)] public string? Mes_de { get; set; }
    [ProtoMember(46)] public string? Anio_de { get; set; }
    [ProtoMember(47)] public string? Dia_a { get; set; }
    [ProtoMember(48)] public string? Mes_a { get; set; }
    [ProtoMember(49)] public string? VisitasProg { get; set; }
    [ProtoMember(50)] public string? FrecuenciaVisita { get; set; }
    [ProtoMember(51)] public string? SplitPedidosPE { get; set; }
    [ProtoMember(52)] public string? PrevEspecializada { get; set; }
    [ProtoMember(53)] public string? Calle { get; set; }
    [ProtoMember(54)] public string? ContinuacionCalle { get; set; }
    [ProtoMember(55)] public string? Colonia { get; set; }
    [ProtoMember(56)] public string? NoExterno { get; set; }
    [ProtoMember(57)] public string? NoInterno { get; set; }
    [ProtoMember(58)] public string? EntreCalle { get; set; }
    [ProtoMember(59)] public string? yCalle { get; set; }
    [ProtoMember(60)] public string? Delegacion { get; set; }
    [ProtoMember(61)] public string? CP { get; set; }
    [ProtoMember(62)] public string? Baja { get; set; }
    [ProtoMember(63)] public string? CalleDomfiscal { get; set; }
    [ProtoMember(64)] public string? Email { get; set; }
    [ProtoMember(65)] public string? Pais { get; set; }
    [ProtoMember(66)] public string? PoblacionDomfiscal { get; set; }
    [ProtoMember(67)] public string? NoDomfiscal { get; set; }
    [ProtoMember(68)] public string? Region { get; set; }
    [ProtoMember(69)] public string? DescRegion { get; set; }
    [ProtoMember(70)] public string? RegionDomfiscal { get; set; }
    [ProtoMember(71)] public string? ColoniaDomfiscal { get; set; }
    [ProtoMember(72)] public string? ClaseImpuesto { get; set; }
    [ProtoMember(73)] public string? NIF_CUIT_RFC { get; set; }
    [ProtoMember(74)] public string? Imp2 { get; set; }
    [ProtoMember(75)] public string? TipoCobro { get; set; }
    [ProtoMember(76)] public string? TipoNIF { get; set; }
    [ProtoMember(77)] public string? ViasPago { get; set; }
    [ProtoMember(78)] public string? CuentaAsociada { get; set; }
    [ProtoMember(79)] public string? GrupoImputacion { get; set; }
    [ProtoMember(80)] public string? GrupoTesoreria { get; set; }
    [ProtoMember(81)] public string? EsquemaCliente { get; set; }
    [ProtoMember(82)] public string? NoCteAnt { get; set; }
    [ProtoMember(83)] public string? Coord_X { get; set; }
    [ProtoMember(84)] public string? Coord_Y { get; set; }
    [ProtoMember(85)] public string? GpoCuentas { get; set; }
    [ProtoMember(86)] public string? localidad { get; set; }
    [ProtoMember(87)] public string? PersonaContacto { get; set; }
    [ProtoMember(88)] public string? NombrePersConta { get; set; }
    [ProtoMember(89)] public string? ApellidoPersCon { get; set; }
    [ProtoMember(90)] public string? Telefono { get; set; }
    [ProtoMember(91)] public string? TelWhatsapp { get; set; }
    [ProtoMember(92)] public string? TelefonMovil { get; set; }
    [ProtoMember(93)] public string? Fax { get; set; }
    [ProtoMember(94)] public string? TelExt { get; set; }
    [ProtoMember(95)] public string? TelefonoPersContac { get; set; }
    [ProtoMember(96)] public string? Estado { get; set; }
    [ProtoMember(97)] public string? DescripcionEstado { get; set; }
    [ProtoMember(98)] public string? RevenueMap { get; set; }
    [ProtoMember(99)] public string? RegionKOF { get; set; }
    [ProtoMember(100)] public string? DescripcionRegionKOF { get; set; }
    [ProtoMember(101)] public string? ZonaVentas_UO { get; set; }
    [ProtoMember(102)] public string? GerenciaVentas { get; set; }
    [ProtoMember(103)] public string? JefaturaVentas { get; set; }
    [ProtoMember(104)] public string? RegionDistribucion { get; set; }
    [ProtoMember(105)] public string? CentroSuministro { get; set; }
    [ProtoMember(106)] public string? CondicionExpedic { get; set; }
    [ProtoMember(107)] public string? TipoServicio { get; set; }
    [ProtoMember(108)] public string? DescripcionTipoSer { get; set; }
    [ProtoMember(109)] public string? ZonaTransporte { get; set; }
    [ProtoMember(110)] public string? IDMulticentroMultiruta { get; set; }
    [ProtoMember(111)] public string? PrioEntrega { get; set; }
    [ProtoMember(112)] public string? ClaseDocVentas { get; set; }
    [ProtoMember(113)] public string? CondPago { get; set; }
    [ProtoMember(114)] public string? BloqueoPedido { get; set; }
    [ProtoMember(115)] public string? BloqPedVtaSe { get; set; }
    [ProtoMember(116)] public string? BloqEntregaTodasAreas { get; set; }
    [ProtoMember(117)] public string? BloqEntVtaSe { get; set; }
    [ProtoMember(118)] public string? BloqFacturatodasAreas { get; set; }
    [ProtoMember(119)] public string? BloqFacVtaSe { get; set; }
    [ProtoMember(120)] public string? BloqSoporteVentas { get; set; }
    [ProtoMember(121)] public string? TipoDetallista { get; set; }
    [ProtoMember(122)] public string? DescripcionTipoDet { get; set; }
    [ProtoMember(123)] public string? Condicion { get; set; }
    [ProtoMember(124)] public string? DescripcionCondicio { get; set; }
    [ProtoMember(125)] public string? ClienteICEKOF { get; set; }
    [ProtoMember(126)] public string? CtaClave { get; set; }
    [ProtoMember(127)] public string? Cadena { get; set; }
    [ProtoMember(128)] public string? ContratodePreferen { get; set; }
    [ProtoMember(129)] public string? UnidadNegocio { get; set; }
    [ProtoMember(130)] public string? SubUnidadNegocio { get; set; }
    [ProtoMember(131)] public string? GrupoCanal { get; set; }
    [ProtoMember(132)] public string? DescGrupoCanal { get; set; }
    [ProtoMember(133)] public string? Canal { get; set; }
    [ProtoMember(134)] public string? DescCanal { get; set; }
    [ProtoMember(135)] public string? CanalKOF { get; set; }
    [ProtoMember(136)] public string? DescCanalKOF { get; set; }
    [ProtoMember(137)] public string? GEC { get; set; }
    [ProtoMember(138)] public string? DescGEC { get; set; }
    [ProtoMember(139)] public string? NivSocioeconomico { get; set; }
    [ProtoMember(140)] public string? DescripcionNSE { get; set; }
    [ProtoMember(141)] public string? NivSocPlanchado { get; set; }
    [ProtoMember(142)] public string? DescripciponNSEP { get; set; }
    [ProtoMember(143)] public string? NivelMargen { get; set; }
    [ProtoMember(144)] public string? SegPrecios { get; set; }
    [ProtoMember(145)] public string? DescSegPrec { get; set; }
    [ProtoMember(146)] public string? SegDescuentos { get; set; }
    [ProtoMember(147)] public string? DescSegDesc { get; set; }
    [ProtoMember(148)] public string? SegPortafolio { get; set; }
    [ProtoMember(149)] public string? DescSegPort { get; set; }
    [ProtoMember(150)] public string? SegPropuestaValor { get; set; }
    [ProtoMember(151)] public string? DescSegPDV { get; set; }
    [ProtoMember(152)] public string? SegPeliculaExito { get; set; }
    [ProtoMember(153)] public string? DescSegPDE { get; set; }
    [ProtoMember(154)] public string? SegExhibicion { get; set; }
    [ProtoMember(155)] public string? DescSegExh { get; set; }
    [ProtoMember(156)] public string? SegComunicacion { get; set; }
    [ProtoMember(157)] public string? DescSegCom { get; set; }
    [ProtoMember(158)] public string? OcasionConsumo { get; set; }
    [ProtoMember(159)] public string? DescOcasionConsumo { get; set; }
    [ProtoMember(160)] public string? Foco { get; set; }
    [ProtoMember(161)] public string? DescCategoriaFoco { get; set; }
    [ProtoMember(162)] public string? GerReg { get; set; }
    [ProtoMember(163)] public string? LimiteCred { get; set; }
    [ProtoMember(164)] public string? ClusterAnalytics { get; set; }
    [ProtoMember(165)] public string? DescClusterAnalytics { get; set; }
    [ProtoMember(166)] public string? IT { get; set; }
    [ProtoMember(167)] public string? DescIT { get; set; }
    [ProtoMember(168)] public string? NivelColaboracion { get; set; }
    [ProtoMember(169)] public string? Imagen { get; set; }
    [ProtoMember(170)] public string? Delivery { get; set; }
    [ProtoMember(171)] public string? Enrejado { get; set; }
    [ProtoMember(172)] public string? Tamano { get; set; }
    [ProtoMember(173)] public string? DescTamano { get; set; }
    [ProtoMember(174)] public string? Localidad1 { get; set; }
    [ProtoMember(175)] public string? Fe_baja { get; set; }
    [ProtoMember(176)] public string? Ciudad2 { get; set; }
    [ProtoMember(177)] public string? Distrito { get; set; }
    [ProtoMember(178)] public string? Secuencia { get; set; }
    [ProtoMember(179)] public string? NumeroIdentificacionFiscal { get; set; }
    [ProtoMember(180)] public string? IdLoc { get; set; }
    [ProtoMember(181)] public string? DatosAdicionales { get; set; }
    [ProtoMember(182)] public string? DomicilFiscal { get; set; }
    [ProtoMember(183)] public string? McDonalds { get; set; }
    [ProtoMember(184)] public string? MaterialUnico { get; set; }
    [ProtoMember(185)] public string? InVoice { get; set; }
    [ProtoMember(186)] public string? ClienteEDI { get; set; }
    [ProtoMember(187)] public string? IndicadorCompen { get; set; }
    [ProtoMember(188)] public string? IndicadorAyudan { get; set; }
    [ProtoMember(189)] public string? IndicadorRutDir { get; set; }
    [ProtoMember(190)] public string? Agrupamiento { get; set; }
    [ProtoMember(191)] public string? FechaAlta { get; set; }
    [ProtoMember(192)] public string? Telvendedor { get; set; }
    [ProtoMember(193)] public string? NombreTelvendedor { get; set; }
    [ProtoMember(194)] public string? JefeTelvendedor { get; set; }
    [ProtoMember(195)] public string? NombreJefeTelvendedor { get; set; }
    [ProtoMember(196)] public string? IntensidadCompetitiva { get; set; }
    [ProtoMember(197)] public string? ShareKof { get; set; }
    [ProtoMember(198)] public string? TamanoFisico { get; set; }
    [ProtoMember(199)] public string? BloqueoPromociones { get; set; }
    [ProtoMember(200)] public string? DescBloqueoPromo { get; set; }
    [ProtoMember(201)] public string? DescShareKof { get; set; }
    [ProtoMember(202)] public string? DescIntensidadComp { get; set; }
    [ProtoMember(203)] public string? CallPrevenda { get; set; }
    [ProtoMember(204)] public string? SectorIndustrial { get; set; }
    [ProtoMember(205)] public string? PrestamoPalletChapatex { get; set; }
}