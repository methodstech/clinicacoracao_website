using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebSite.Helper;

namespace WebSite.Areas.Laudo.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteAppService _appService;

        // Constructor
        public PacienteController(IPacienteAppService appService)
        {
            _appService = appService;
        }

        // GET: Paciente
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index(int? pageNumber)
        {
            IEnumerable<PacienteDto> model;
            try
            {
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                PacienteFilterDto filter = new PacienteFilterDto();
                model = _appService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
            }
            catch (Exception ex)
            {
                model = new List<PacienteDto>();
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de pacientes. " + ex.Message;
            }
            // retorna o model vazio com a mensagem de erro, ou o model com os dados
            return View(model);
        }

        // GET: Paciente/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(PacienteDto model)
        {
            try
            {
                model.PacienteDtCadastro = Util.HrBrasilia();
                // salva em banco
                _appService.Create(model);

                // add mensagem de sucesso e retorna para Index
                TempData["success"] = "Paciente cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao cadastrar paciente. " + ex.Message;
                return View(model);
            }
        }

        // POST: Paciente/Create2
        [HttpPost]
        [CustomAuthorize]
        public JsonResult Create2(PacienteDto model, string dt)
        {
            PacienteDto p = null;
            try
            {
                model.PacienteDataNascimento = DateTime.ParseExact(dt, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                model.PacienteDtCadastro = Util.HrBrasilia();
                // salva em banco
                p = _appService.Create(model);
                return Json(new { result = "ok", data = p }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", data = "Erro: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Paciente/Details/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                PacienteDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do paciente. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Paciente/Edit/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                PacienteDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do paciente. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Paciente/Edit
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(PacienteDto model)
        {
            try
            {
                // se o model não estiver válido, retorna para view
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // salva em banco
                bool editou = _appService.Update(model);

                if (editou)
                {
                    // add mensagem de sucesso e retorna para Index
                    TempData["success"] = "Paciente editado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro ao editar paciente.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao editar paciente. " + ex.Message;
            }
            return View(model);
        }

        // GET: Paciente/Delete/{id}
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
                    TempData["success"] = "Paciente deletado com sucesso.";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar paciente.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao deletar paciente. " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        // Retorna uma lista de clientes filtrando pelo termo passado por parâmetro
        // É utilizado na chamada ajax
        [CustomAuthorize]
        public JsonResult GetPacientes(string term = "")
        {
            PacienteFilterDto filter = new PacienteFilterDto();
            if (!string.IsNullOrEmpty(term))
            {
                filter.PacienteNome = term;
            }
            IEnumerable<PacienteDto> pacientes = _appService.List(filter);
            return Json(pacientes, JsonRequestBehavior.AllowGet);
        }
    }
}
