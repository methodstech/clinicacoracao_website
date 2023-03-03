using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using WebSite.Helper;

namespace WebSite.Areas.Laudo.Controllers
{
    public class RitmoController : Controller
    {
        private readonly IRitmoAppService _appService;

        public RitmoController(IRitmoAppService appService)
        {
            _appService = appService;
        }

        // GET: Ritmo
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index(int? pageNumber)
        {
            IEnumerable<RitmoDto> model;
            try
            {
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                RitmoFilterDto filter = new RitmoFilterDto();
                model = _appService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
            }
            catch (Exception ex)
            {
                model = new List<RitmoDto>();
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de ritmos. " + ex.Message;
            }
            // retorna o model vazio com a mensagem de erro, ou o model com os dados
            return View(model);
        }

        // GET: Ritmo/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ritmo/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(RitmoDto model)
        {
            try
            {
                // se o model não estiver válido, retorna para view
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // salva em banco
                _appService.Create(model);

                // add mensagem de sucesso e retorna para Index
                TempData["success"] = "Ritmo cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao cadastrar ritmo. " + ex.Message;
                return View(model);
            }
        }

        // GET: Ritmo/Details/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                RitmoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do ritmo. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Ritmo/Edit/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                RitmoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do ritmo. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Ritmo/Edit
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(RitmoDto model)
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
                    TempData["success"] = "Ritmo editado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro ao editar ritmo.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao editar ritmo. " + ex.Message;
            }
            return View(model);
        }

        // GET: Ritmo/Delete/{id}
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
                    TempData["success"] = "Ritmo deletado com sucesso.";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar ritmo.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao deletar ritmo. " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        // Retorna uma lista de ritmos filtrando pelo termo passado por parâmetro
        // É utilizado na chamada ajax
        [CustomAuthorize]
        public JsonResult GetRitmos(string term = "")
        {
            RitmoFilterDto filter = new RitmoFilterDto();
            if (!string.IsNullOrEmpty(term))
            {
                if (Regex.IsMatch(term, @"^\d+$"))
                {
                    filter.RitmoCodigo = int.Parse(term);
                }
                else
                {
                    filter.RitmoDescricao = term;
                }
            }
            IEnumerable<RitmoDto> ritmos = _appService.List(filter);
            return Json(ritmos, JsonRequestBehavior.AllowGet);
        }
    }
}