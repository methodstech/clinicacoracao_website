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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _appService;

        public UsuarioController(IUsuarioAppService appService)
        {
            _appService = appService;
        }

        // GET: Usuario
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Index(int? pageNumber)
        {
            IEnumerable<UsuarioDto> model;
            try
            {
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                UsuarioFilterDto filter = new UsuarioFilterDto();
                model = _appService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
            }
            catch (Exception ex)
            {
                model = new List<UsuarioDto>();
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de usuário. " + ex.Message;
            }
            // retorna o model vazio com a mensagem de erro, ou o model com os dados
            return View(model);
        }

        // GET: Usuario/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(UsuarioDto model)
        {
            try
            {
                if (model.UsuarioSenha != model.ConfirmarSenha)
                {
                    TempData["error"] = "Campo senha e confirmar senha devem ser iguais.";
                    return View(model);
                }

                model.UsuarioDtCadastro = Util.HrBrasilia();
                // salva em banco
                _appService.Create(model);

                // add mensagem de sucesso e retorna para Index
                TempData["success"] = "Usuário cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao cadastrar usuário. " + ex.Message;
                return View(model);
            }
        }

        // GET: Usuario/Details/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                UsuarioDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do usuário. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Usuario/Edit/{id}
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                UsuarioDto model = _appService.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao carregar detalhes do usuário. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Usuario/Edit
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(UsuarioDto model)
        {
            try
            {
                if (model.UsuarioSenha != model.ConfirmarSenha)
                {
                    TempData["error"] = "Campo senha e confirmar senha devem ser iguais.";
                    return View(model);
                }

                // salva em banco
                bool editou = _appService.Update(model);

                if (editou)
                {
                    // add mensagem de sucesso e retorna para Index
                    TempData["success"] = "Usuário editado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro ao editar usuário.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e mantem na mesma página
                TempData["error"] = "Erro ao editar usuário. " + ex.Message;
            }
            return View(model);
        }

        // GET: Usuario/Delete/{id}
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
                    TempData["success"] = "Usuário deletado com sucesso.";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar usuário.";
                }
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro e retorna para Index
                TempData["error"] = "Erro ao deletar usuário. " + ex.Message;
            }
            return RedirectToAction("Index");
        }

    }
}