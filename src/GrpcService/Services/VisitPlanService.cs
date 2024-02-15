using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Google.Protobuf.Collections;
using Grpc.Core;
using MediatR;
using System.Collections.Generic;

namespace GrpcService.Services
{
    public class VisitPlanService : VisitPlans.VisitPlansBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VisitPlanService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task GetPaginatedData
            (IAsyncStreamReader<GetVisitPlanWithPaginationQuery> requestStream, 
            IServerStreamWriter<PaginatedData> responseStream, 
            ServerCallContext context)
        {
            var count = 0;
            while (await requestStream.MoveNext() && 
                !context.CancellationToken.IsCancellationRequested)
            {
                count++;
                var query = new KOF.RouteMap.Application.VisitPlan.Queries.GetVisitPlanWithPagination.GetVisitPlanWithPaginationQuery
                {
                    PageNumber = requestStream.Current.PageNumber,
                    PageSize = requestStream.Current.PageSize
                };

                var pageResponse = await _mediator.Send(query);

                var response = new PaginatedData
                {
                    PageNumber = pageResponse.PageNumber,
                    HasNextPage = pageResponse.HasNextPage,
                    HasPreviousPage = pageResponse.HasPreviousPage,
                    TotalCount = pageResponse.TotalCount,
                    TotalPages = pageResponse.TotalPages
                };

                pageResponse.Items.ForEach(item =>
                {
                    response.Items.Add(new VisitPlanItem
                    {
                        Agrupamiento = item.Agrupamiento ?? "",
                        NroCliente = item.NroCliente ?? "",
                        NombreCliente = item.NombreCliente ?? "",
                        NombreCliente2 = item.NombreCliente2 ?? "",
                        NombreCliente3 = item.NombreCliente3 ?? "",
                        ConcBusq = item.ConcBusq ?? "",
                        OrganizacaoVendas = item.OrganizacaoVendas ?? "",
                        CanalDistribucion = item.CanalDistribucion ?? "",
                        Sector = item.Sector ?? "",
                        EstatusCliente = item.EstatusCliente ?? "",
                        FechaAltaSistema = item.FechaAltaSistema ?? "",
                        CreadoPor = item.CreadoPor ?? "",
                        ModalidadVentas = item.ModalidadVentas ?? "",
                        IdPlanVisita = item.IDPlanVisita ?? "",
                        InicioVigenciaPlan = item.InicioVigenciaPlan ?? "",
                        FinVigenciaPlan = item.FinVigenciaPlan ?? "",
                        Ruta = item.Ruta ?? "",
                        TipoPlanVisita = item.TipoPlanVisita ?? "",
                        MetodoVenta = item.MetodoVenta ?? "",
                        InactivoVisitaPlan = item.InactivoVisitaPlan ?? "",
                        Ritmo = item.Ritmo ?? "",
                        FechaInicioContacto = item.FechaInicioContacto ?? "",
                        FechaFinalContacto = item.FechaFinalContacto ?? "",
                        VisitaLunes = item.VisitaLunes ?? "",
                        LunDe = item.Lun_de ?? "",
                        LunA = item.Lun_a ?? "",
                        VisitaMartes = item.VisitaMartes ?? "",
                        MarDe = item.Mar_de ?? "",
                        MarA = item.Mar_a ?? "",
                        VisitaMiercoles = item.VisitaMiercoles ?? "",
                        MieDe = item.Mie_de ?? "",
                        MieA = item.Mie_a ?? "",
                        VisitaJueves = item.VisitaJueves ?? "",
                        JueDe = item.Jue_de ?? "",
                        JueA = item.Jue_a ?? "",
                        VisitaViernes = item.VisitaViernes ?? "",
                        VieDe = item.Vie_de ?? "",
                        VieA = item.Vie_a ?? "",
                        VisitaSabado = item.VisitaSabado ?? "",
                        SabDe = item.Sab_de ?? "",
                        SabA = item.Sab_a ?? "",
                        VisitaDomingo = item.VisitaDomingo ?? "",
                        DomDe = item.Dom_de ?? "",
                        DomA = item.Dom_a ?? "",
                        DiaDe = item.Dia_de ?? "",
                        MesDe = item.Mes_de ?? "",
                        AnioDe = item.Anio_de ?? "",
                        DiaA = item.Dia_a ?? "",
                        MesA = item.Mes_a ?? "",
                        VisitasProg = item.VisitasProg ?? "",
                        FrecuenciaVisita = item.FrecuenciaVisita ?? "",
                        SplitPedidosPe = item.SplitPedidosPE ?? "",
                        PrevEspecializada = item.PrevEspecializada ?? "",
                        Calle = item.Calle ?? "",
                        ContinuacionCalle = item.ContinuacionCalle ?? "",
                        Colonia = item.Colonia ?? "",
                        NoExterno = item.NoExterno ?? "",
                        NoInterno = item.NoInterno ?? "",
                        EntreCalle = item.EntreCalle ?? "",
                        YCalle = item.yCalle ?? "",
                        Delegacion = item.Delegacion ?? "",
                        Cp = item.CP ?? "",
                        Baja = item.Baja ?? "",
                        CalleDomfiscal = item.CalleDomfiscal ?? "",
                        Email = item.Email ?? "",
                        Pais = item.Pais ?? "",
                        PoblacionDomfiscal = item.PoblacionDomfiscal ?? "",
                        NoDomfiscal = item.NoDomfiscal ?? "",
                        Region = item.Region ?? "",
                        DescRegion = item.DescRegion ?? "",
                        RegionDomfiscal = item.RegionDomfiscal ?? "",
                        ColoniaDomfiscal = item.ColoniaDomfiscal ?? "",
                        ClaseImpuesto = item.ClaseImpuesto ?? "",
                        NifCuitRfc = item.NIF_CUIT_RFC ?? "",
                        Imp2 = item.Imp2 ?? "",
                        TipoCobro = item.TipoCobro ?? "",
                        TipoNif = item.TipoNIF ?? "",
                        ViasPago = item.ViasPago ?? "",
                        CuentaAsociada = item.CuentaAsociada ?? "",
                        GrupoImputacion = item.GrupoImputacion ?? "",
                        GrupoTesoreria = item.GrupoTesoreria ?? "",
                        EsquemaCliente = item.EsquemaCliente ?? "",
                        NoCteAnt = item.NoCteAnt ?? "",
                        CoordX = item.Coord_X ?? "",
                        CoordY = item.Coord_Y ?? "",
                        GpoCuentas = item.GpoCuentas ?? "",
                        Localidad = item.localidad ?? "",
                        PersonaContacto = item.PersonaContacto ?? "",
                        NombrePersConta = item.NombrePersConta ?? "",
                        ApellidoPersCon = item.ApellidoPersCon ?? "",
                        Telefono = item.Telefono ?? "",
                        TelWhatsapp = item.TelWhatsapp ?? "",
                        TelefonMovil = item.TelefonMovil ?? "",
                        Fax = item.Fax ?? "",
                        TelExt = item.TelExt ?? "",
                        TelefonoPersContac = item.TelefonoPersContac ?? "",
                        Estado = item.Estado ?? "",
                        DescripcionEstado = item.DescripcionEstado ?? "",
                        RevenueMap = item.RevenueMap ?? "",
                        RegionKof = item.RegionKOF ?? "",
                        DescripcionRegionKof = item.DescripcionRegionKOF ?? "",
                        ZonaVentasUo = item.ZonaVentas_UO ?? "",
                        GerenciaVentas = item.GerenciaVentas ?? "",
                        JefaturaVentas = item.JefaturaVentas ?? "",
                        RegionDistribucion = item.RegionDistribucion ?? "",
                        CentroSuministro = item.CentroSuministro ?? "",
                        CondicionExpedic = item.CondicionExpedic ?? "",
                        TipoServicio = item.TipoServicio ?? "",
                        DescripcionTipoSer = item.DescripcionTipoSer ?? "",
                        ZonaTransporte = item.ZonaTransporte ?? "",
                        IdMulticentroMultiruta = item.IDMulticentroMultiruta ?? "",
                        PrioEntrega = item.PrioEntrega ?? "",
                        ClaseDocVentas = item.ClaseDocVentas ?? "",
                        CondPago = item.CondPago ?? "",
                        BloqueoPedido = item.BloqueoPedido ?? "",
                        BloqPedVtaSe = item.BloqPedVtaSe ?? "",
                        BloqEntregaTodasAreas = item.BloqEntregaTodasAreas ?? "",
                        BloqEntVtaSe = item.BloqEntVtaSe ?? "",
                        BloqFacturatodasAreas = item.BloqFacturatodasAreas ?? "",
                        BloqFacVtaSe = item.BloqFacVtaSe ?? "",
                        BloqSoporteVentas = item.BloqSoporteVentas ?? "",
                        TipoDetallista = item.TipoDetallista ?? "",
                        DescripcionTipoDet = item.DescripcionTipoDet ?? "",
                        Condicion = item.Condicion ?? "",
                        DescripcionCondicio = item.DescripcionCondicio ?? "",
                        ClienteIcekof = item.ClienteICEKOF ?? "",
                        CtaClave = item.CtaClave ?? "",
                        Cadena = item.Cadena ?? "",
                        ContratodePreferen = item.ContratodePreferen ?? "",
                        UnidadNegocio = item.UnidadNegocio ?? "",
                        SubUnidadNegocio = item.SubUnidadNegocio ?? "",
                        GrupoCanal = item.GrupoCanal ?? "",
                        DescGrupoCanal = item.DescGrupoCanal ?? "",
                        Canal = item.Canal ?? "",
                        DescCanal = item.DescCanal ?? "",
                        CanalKof = item.CanalKOF ?? "",
                        DescCanalKof = item.DescCanalKOF ?? "",
                        Gec = item.GEC ?? "",
                        DescGec = item.DescGEC ?? "",
                        NivSocioeconomico = item.NivSocioeconomico ?? "",
                        DescripcionNse = item.DescripcionNSE ?? "",
                        NivSocPlanchado = item.NivSocPlanchado ?? "",
                        DescripciponNsep = item.DescripciponNSEP ?? "",
                        NivelMargen = item.NivelMargen ?? "",
                        SegPrecios = item.SegPrecios ?? "",
                        DescSegPrec = item.DescSegPrec ?? "",
                        SegDescuentos = item.SegDescuentos ?? "",
                        DescSegDesc = item.DescSegDesc ?? "",
                        SegPortafolio = item.SegPortafolio ?? "",
                        DescSegPort = item.DescSegPort ?? "",
                        SegPropuestaValor = item.SegPropuestaValor ?? "",
                        DescSegPdv = item.DescSegPDV ?? "",
                        SegPeliculaExito = item.SegPeliculaExito ?? "",
                        DescSegPde = item.DescSegPDE ?? "",
                        SegExhibicion = item.SegExhibicion ?? "",
                        DescSegExh = item.DescSegExh ?? "",
                        SegComunicacion = item.SegComunicacion ?? "",
                        DescSegCom = item.DescSegCom ?? "",
                        OcasionConsumo = item.OcasionConsumo ?? "",
                        DescOcasionConsumo = item.DescOcasionConsumo ?? "",
                        Foco = item.Foco ?? "",
                        DescCategoriaFoco = item.DescCategoriaFoco ?? "",
                        GerReg = item.GerReg ?? "",
                        LimiteCred = item.LimiteCred ?? "",
                        ClusterAnalytics = item.ClusterAnalytics ?? "",
                        DescClusterAnalytics = item.DescClusterAnalytics ?? "",
                        It = item.IT ?? "",
                        DescIt = item.DescIT ?? "",
                        NivelColaboracion = item.NivelColaboracion ?? "",
                        Imagen = item.Imagen ?? "",
                        Delivery = item.Delivery ?? "",
                        Enrejado = item.Enrejado ?? "",
                        Tamano = item.Tamano ?? "",
                        DescTamano = item.DescTamano ?? "",
                        Localidad1 = item.Localidad1 ?? "",
                        FeBaja = item.Fe_baja ?? "",
                        Ciudad2 = item.Ciudad2 ?? "",
                        Distrito = item.Distrito ?? "",
                        Secuencia = item.Secuencia ?? "",
                        NumeroIdentificacionFiscal = item.NumeroIdentificacionFiscal ?? "",
                        IdLoc = item.IdLoc ?? "",
                        DatosAdicionales = item.DatosAdicionales ?? "",
                        DomicilFiscal = item.DomicilFiscal ?? "",
                        Mcdonalds = item.McDonalds ?? "",
                        MaterialUnico = item.MaterialUnico ?? "",
                        InVoice = item.InVoice ?? "",
                        ClienteEdi = item.ClienteEDI ?? "",
                        IndicadorCompen = item.IndicadorCompen ?? "",
                        IndicadorAyudan = item.IndicadorAyudan ?? "",
                        IndicadorRutDir = item.IndicadorRutDir ?? "",
                        FechaAlta = item.FechaAlta ?? "",
                        Telvendedor = item.Telvendedor ?? "",
                        NombreTelvendedor = item.NombreTelvendedor ?? "",
                        JefeTelvendedor = item.JefeTelvendedor ?? "",
                        NombreJefeTelvendedor = item.NombreJefeTelvendedor ?? "",
                        IntensidadCompetitiva = item.IntensidadCompetitiva ?? "",
                        ShareKof = item.ShareKof ?? "",
                        TamanoFisico = item.TamanoFisico ?? "",
                        BloqueoPromociones = item.BloqueoPromociones ?? "",
                        DescBloqueoPromo = item.DescBloqueoPromo ?? "",
                        DescShareKof = item.DescShareKof ?? "",
                        DescIntensidadComp = item.DescIntensidadComp ?? "",
                        CallPrevenda = item.CallPrevenda ?? "",
                        SectorIndustrial = item.SectorIndustrial ?? "",
                        PrestamoPalletChapatex = item.PrestamoPalletChapatex ?? ""
                    });
                });
                await responseStream.WriteAsync(response);
            }
        }
    }
}

