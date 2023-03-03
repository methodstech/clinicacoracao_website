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
    public class ConclusaoController : Controller
    {
        private readonly IConclusaoAppService _appService;

        public ConclusaoController(IConclusaoAppService appService)
        {
            _appService = appService;
        }

        // GET: Conclusao
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index(int? pageNumber)
        {
            IEnumerable<ConclusaoDto> model;
            try
            {
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                ConclusaoFilterDto filter = new ConclusaoFilterDto();
                model = _appService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
            }
            catch (Exception ex)
            {
                 model = new List<ConclusaoDto>().ToPagedList(pageNumber ?? 1, Configuration.PageSize);
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de conclusões. " + ex.Message;
            }
            // retorna o model vazio com a mensagem de erro, ou o model com os dados
            return View(model);
        }

        // GET: Conclusao/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conclusao/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(ConclusaoDto model)
        {
            try
            {
                // se o model não estiver válido, retorna para view
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.ConclusaoDtCadastro = Util.HrBrasilia();
                // salva em banco
                _appService.Create(model);

                // add mensagem de sucesso e retorna para Index
                TempData["success"] = "Conclusão cadastrada com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao cadastrar conclusão. " + ex.Message;
                return View(model);
            }
        }

        // GET: Conclusao/Details/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                ConclusaoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes da conclusão. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Conclusao/Edit/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                ConclusaoDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes da conclusão. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Conclusao/Edit
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(ConclusaoDto model)
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
                    TempData["success"] = "Conclusão editada com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro ao editar conclusão.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao editar conclusão. " + ex.Message;
            }
            return View(model);
        }

        // GET: Conclusao/Delete/{id}
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
                    TempData["success"] = "Conclusão deletada com sucesso.";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar conclusão.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao deletar conclusão. " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        // Retorna uma lista de conclusões filtrando pelo termo passado por parâmetro
        // É utilizado na chamada ajax
        [CustomAuthorize]
        public JsonResult GetConclusoes(string term = "")
        {
            ConclusaoFilterDto filter = new ConclusaoFilterDto();
            if (!string.IsNullOrEmpty(term))
            {
                if (Regex.IsMatch(term, @"^\d+$"))
                {
                    filter.ConclusaoCodigo = term;
                }
                else
                {
                    filter.ConclusaoDescricao = term;
                }
            }
            IEnumerable<ConclusaoDto> conclusoes = _appService.List(filter);
            return Json(conclusoes, JsonRequestBehavior.AllowGet);
        }
    }
}