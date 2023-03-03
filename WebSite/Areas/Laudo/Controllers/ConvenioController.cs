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
    public class ConvenioController : Controller
    {
        private readonly IConvenioAppService _appService;

        public ConvenioController(IConvenioAppService appService)
        {
            _appService = appService;
        }

        // GET: Convenio
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index(int? pageNumber)
        {
            IEnumerable<ConvenioDto> model;
            try
            {
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                ConvenioFilterDto filter = new ConvenioFilterDto();
                model = _appService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
            }
            catch (Exception ex)
            {
                model = new List<ConvenioDto>();
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de convênios. " + ex.Message;
            }
            // retorna o model vazio com a mensagem de erro, ou o model com os dados
            return View(model);
        }

        // GET: Convenio/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Convenio/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(ConvenioDto model)
        {
            try
            {
                // se o model não estiver válido, retorna para view
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.ConvenioDtCadastro = Util.HrBrasilia();
                // salva em banco
                _appService.Create(model);

                // add mensagem de sucesso e retorna para Index
                TempData["success"] = "Convênio cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao cadastrar convênio. " + ex.Message;
                return View(model);
            }
        }

        // GET: Convenio/Details/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                ConvenioDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do convênio. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Convenio/Edit/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                ConvenioDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do convênio. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Convenio/Edit
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(ConvenioDto model)
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
                    TempData["success"] = "Convênio editado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro ao editar convênio.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao editar convênio. " + ex.Message;
            }
            return View(model);
        }

        // GET: Convenio/Delete/{id}
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
                    TempData["success"] = "Convênio deletado com sucesso.";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar convênio.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao deletar convênio. " + ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
