using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebSite.Helper;

namespace WebSite.Areas.Laudo.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IRelatorioAppService _appService;
        private readonly IRitmoAppService _ritmoAppService;
        private readonly IConclusaoAppService _conclusaoAppService;

        public RelatorioController(IRelatorioAppService appService, IRitmoAppService ritmoAppService, IConclusaoAppService conclusaoAppService)
        {
            _appService = appService;
            _ritmoAppService = ritmoAppService;
            _conclusaoAppService = conclusaoAppService;
        }

        // GET: Laudo/Relatorio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Laudo/Relatorio/PercPorRitmoEConclusao
        [HttpGet]
        [CustomAuthorize]
        public ActionResult PercPorRitmoEConclusao(int? ritmoId, int? conclusaoId, string dtInicial, string dtFinal)
        {
            RelatorioRitmoConclusaoDto model = new RelatorioRitmoConclusaoDto { Laudos = new List<RelatorioRitmoConclusaoDetalhesDto>() };
            ViewBag.Titulo = "";

            if (ritmoId != null && conclusaoId != null)
            {
                RelatorioRitmoConclusaoFilterDto filter = new RelatorioRitmoConclusaoFilterDto
                {
                    RitmoId = (int)ritmoId,
                    ConclusaoId = (int)conclusaoId
                };
                if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
                {
                    filter.DtInicial = DateTime.ParseExact(dtInicial + " 00:01", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    filter.DtFinal = DateTime.ParseExact(dtFinal + " 23:59", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
                var m = _appService.RelatorioRitmoConclusao(filter);
                if (m != null)
                {
                    model = m;
                }

                var ritmo = _ritmoAppService.GetById((int)ritmoId);
                var conclusao = _conclusaoAppService.GetById((int)conclusaoId);

                ViewBag.Ritmo = ritmo.RitmoCodigo + " - " + ritmo.RitmoDescricao;
                ViewBag.RitmoId = ritmo.RitmoId;
                ViewBag.Conclusao = conclusao.ConclusaoCodigo + " - " + conclusao.ConclusaoDescricao;
                ViewBag.ConclusaoId = conclusao.ConclusaoId;
                ViewBag.Titulo = "Laudos com ritmo " + ritmo.RitmoDescricao + " e conclusão " + conclusao.ConclusaoDescricao;
                ViewBag.DtInicial = dtInicial;
                ViewBag.DtFinal = dtFinal;
            }

            return View(model);
        }

        // GET: Laudo/Relatorio/HistoricoPorPaciente
        [HttpGet]
        [CustomAuthorize]
        public ActionResult HistoricoPorPaciente(int? pacienteId)
        {
            RelatorioHistoricoPacienteFilterDto filter = new RelatorioHistoricoPacienteFilterDto { PacienteId = pacienteId };
            
            var model = _appService.RelatorioHistoricoPaciente(filter);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize]
        public ActionResult HistoricoRitmoConclusao(int? ritmoId, int? conclusaoId, string dtInicial, string dtFinal)
        {
            RelatorioRitmoConclusaoDto model = new RelatorioRitmoConclusaoDto { Laudos = new List<RelatorioRitmoConclusaoDetalhesDto>() };
            ViewBag.Titulo = "";

            if (ritmoId != null && conclusaoId != null)
            {
                RelatorioRitmoConclusaoFilterDto filter = new RelatorioRitmoConclusaoFilterDto
                {
                    RitmoId = (int) ritmoId,
                    ConclusaoId = (int) conclusaoId                    
                };
                if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
                {
                    filter.DtInicial = DateTime.ParseExact(dtInicial + " 00:01", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    filter.DtFinal = DateTime.ParseExact(dtFinal + " 23:59", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
                var m = _appService.RelatorioRitmoConclusao(filter);
                if (m != null)
                {
                    model = m;
                }

                var ritmo = _ritmoAppService.GetById((int)ritmoId);
                var conclusao = _conclusaoAppService.GetById((int)conclusaoId);

                ViewBag.Ritmo = ritmo.RitmoCodigo + " - " + ritmo.RitmoDescricao;
                ViewBag.RitmoId = ritmo.RitmoId;
                ViewBag.Conclusao = conclusao.ConclusaoCodigo + " - " + conclusao.ConclusaoDescricao;
                ViewBag.ConclusaoId = conclusao.ConclusaoId;
                ViewBag.Titulo = "Laudos com ritmo " + ritmo.RitmoDescricao + " e conclusão " + conclusao.ConclusaoDescricao;
                ViewBag.DtInicial = dtInicial;
                ViewBag.DtFinal = dtFinal;
            }

            return View(model);
        }
    }
}