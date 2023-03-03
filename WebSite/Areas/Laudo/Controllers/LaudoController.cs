using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebSite.Helper;

namespace WebSite.Areas.Laudo.Controllers
{
    public class LaudoController : Controller
    {
        private readonly ILaudoAppService _appService;
        private readonly IConvenioAppService _convAppService;
        private readonly IMedicoAppService _medAppService;
        private readonly IConclusaoAppService _concAppService;
        private readonly IRitmoAppService _ritAppService;
        private readonly IPacienteAppService _pacAppService;

        // Constructor
        public LaudoController(ILaudoAppService appService, IConvenioAppService convAppService, IMedicoAppService medAppService,
            IRitmoAppService ritAppService, IConclusaoAppService concAppService, IPacienteAppService pacAppService)
        {
            _appService = appService;
            _convAppService = convAppService;
            _medAppService = medAppService;
            _ritAppService = ritAppService;
            _concAppService = concAppService;
            _pacAppService = pacAppService;
        }

        // GET: Laudo
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index(int? pageNumber, int? pacienteId, string dtInicial, string dtFinal)
        {
            IPagedList<LaudoDto> model;
            PacienteDto p = new PacienteDto();
            try
            {
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                LaudoFilterDto filter = new LaudoFilterDto
                {
                    LaudoPacienteId = pacienteId ?? null
                };
                if (!string.IsNullOrEmpty(dtInicial))
                {
                    filter.LaudoDtInicial = DateTime.ParseExact(dtInicial + " 00:01", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(dtFinal))
                {
                    filter.LaudoDtFinal = DateTime.ParseExact(dtFinal + " 23:59", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
                model = _appService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
                if (pacienteId != null)
                {
                    p = _pacAppService.GetById((int) pacienteId);
                }
            }
            catch (Exception ex)
            {
                model = new List<LaudoDto>().ToPagedList(1, 1);
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de laudos. " + ex.Message;
            }

            ViewBag.DtInicial = dtInicial;
            ViewBag.DtFinal = dtFinal;
            ViewBag.PacienteId = pacienteId;
            if (pacienteId != null) {
                ViewBag.PacienteId = pacienteId;
                ViewBag.PacienteNome = p.PacienteNome;
                ViewBag.PacienteDtNascimento = p.PacienteDataNascimento.ToString("dd/MM/yyyy");
            }

            return View(model);
        }

        // GET: Laudo/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            LaudoDto model = new LaudoDto { LaudoDtRealizacao = Util.HrBrasilia() };
            model.ListConvenios = new SelectList(_convAppService.List(new ConvenioFilterDto()), "ConvenioId", "ConvenioNome");
            model.ListMedicos = new SelectList(_medAppService.List(new MedicoFilterDto()), "MedicoId", "MedicoNome");
            model.ListRitmos = new SelectList(_ritAppService.List(new RitmoFilterDto()), "RitmoId", "RitmoDescricao");
            model.ListConclusoes = new SelectList(_concAppService.List(new ConclusaoFilterDto()), "ConclusaoId", "ConclusaoDescricao");
            return View(model);
        }

        // POST: Laudo/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(LaudoDto model, string dtLaudo)
        {
            try
            {
                //model.LaudoDtRealizacao = DateTime.ParseExact(dtLaudo, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                model.LaudoConclusoesId = model.LaudoConclusoesId.Remove(model.LaudoConclusoesId.Length - 1, 1);

                model.LaudoDtCadastro = Util.HrBrasilia();
                // salva em banco
                LaudoDto laudo =_appService.Create(model);

                // add mensagem de sucesso e retorna para Index
                TempData["success"] = "Laudo cadastrado com sucesso.";
                return RedirectToAction("Print", new {id = laudo.LaudoId});
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao cadastrar laudo. " + ex.Message;

                model.ListConvenios = new SelectList(_convAppService.List(new ConvenioFilterDto()), "ConvenioId", "ConvenioNome");
                model.ListMedicos = new SelectList(_medAppService.List(new MedicoFilterDto()), "MedicoId", "MedicoNome");
                model.ListRitmos = new SelectList(_ritAppService.List(new RitmoFilterDto()), "RitmoId", "RitmoDescricao");
                model.ListConclusoes = new SelectList(_concAppService.List(new ConclusaoFilterDto()), "ConclusaoId", "ConclusaoDescricao");
                return View(model);
            }
        }

        // GET: Laudo/Details/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                LaudoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do laudo. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Laudo/Edit/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                LaudoDto model = _appService.GetById(id);
                model.ListConvenios = new SelectList(_convAppService.List(new ConvenioFilterDto()), "ConvenioId", "ConvenioNome");
                model.ListMedicos = new SelectList(_medAppService.List(new MedicoFilterDto()), "MedicoId", "MedicoNome");
                model.ListRitmos = new SelectList(_ritAppService.List(new RitmoFilterDto()), "RitmoId", "RitmoDescricao");
                model.ListConclusoes = new SelectList(_concAppService.List(new ConclusaoFilterDto()), "ConclusaoId", "ConclusaoDescricao");
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do laudo. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Laudo/Edit
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(LaudoDto model)
        {
            try
            {
                model.LaudoConclusoesId = model.LaudoConclusoesId.Remove(model.LaudoConclusoesId.Length - 1, 1);

                // salva em banco
                bool editou = _appService.Update(model);

                if (editou)
                {
                    // add mensagem de sucesso e retorna para Index
                    TempData["success"] = "Laudo editado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro ao editar laudo.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao editar laudo. " + ex.Message;
            }

            return RedirectToAction("Edit", new { id = model.LaudoId });
        }

        // GET: Laudo/Delete/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            try
            {
                // deleta do banco
                bool deletou = _appService.Delete(id);
                if (deletou)
                {
                    TempData["success"] = "Laudo deletado com sucesso.";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar laudo.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao deletar laudo. " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: Laudo/Print
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Print(int id)
        {
            try
            {
                LaudoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar o laudo a ser impresso. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}