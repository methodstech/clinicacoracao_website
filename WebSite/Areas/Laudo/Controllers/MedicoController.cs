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
    public class MedicoController : Controller
    {
        private readonly IMedicoAppService _appService;

        // Constructor
        public MedicoController(IMedicoAppService appService)
        {
            _appService = appService;
        }

        // GET: Medico
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index(int? pageNumber)
        {
            IEnumerable<MedicoDto> model;
            try
            {
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                MedicoFilterDto filter = new MedicoFilterDto();
                model = _appService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
            }
            catch (Exception ex)
            {
                model = new List<MedicoDto>();
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de médicos. " + ex.Message;
            }
            // retorna o model vazio com a mensagem de erro, ou o model com os dados
            return View(model);
        }

        // GET: Medico/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Medico/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(MedicoDto model)
        {
            try
            {
                // se o model não estiver válido, retorna para view
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.MedicoDtCadastro = Util.HrBrasilia();
                // salva em banco
                _appService.Create(model);

                // add mensagem de sucesso e retorna para Index
                TempData["success"] = "Médico cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao cadastrar médico. " + ex.Message;
                return View(model);
            }
        }

        // POST: Medico/Create2
        [HttpPost]
        [CustomAuthorize]
        public JsonResult Create2(MedicoDto model)
        {
            MedicoDto m = null;
            try
            {
                model.MedicoDtCadastro = Util.HrBrasilia();
                // salva em banco
                m = _appService.Create(model);
                return Json(new { result = "ok", data = m }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", data = "Erro: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Medico/Details/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                MedicoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do médico. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Medico/Edit/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                MedicoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do médico. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Medico/Edit
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(MedicoDto model)
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
                    TempData["success"] = "Médico editado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro ao editar médico.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao editar médico. " + ex.Message;
            }
            return View(model);
        }

        // GET: Medico/Delete/{id}
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
                    TempData["success"] = "Médico deletado com sucesso.";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar médico.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao deletar médico. " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        // Retorna uma lista de médicos filtrando pelo termo passado por parâmetro
        // É utilizado na chamada ajax
        [CustomAuthorize]
        public JsonResult GetMedicos(string term = "")
        {
            MedicoFilterDto filter = new MedicoFilterDto();
            if (!string.IsNullOrEmpty(term))
            {
                filter.MedicoNome = term;
            }
            IEnumerable<MedicoDto> medicos = _appService.List(filter);
            return Json(medicos, JsonRequestBehavior.AllowGet);
        }
    }
}
