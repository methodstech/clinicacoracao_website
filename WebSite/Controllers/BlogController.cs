// ----------------------------------------------------------------------------
// WebSite.BlogController.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using AppServices.Dtos;
using AppServices.Filters;
using AppServices.Interfaces;
using PagedList;
using WebSite.Helper;

namespace WebSite.Controllers
{
    public class BlogController : Controller
    {
        public BlogController(IBlogPostAppService appService)
        {
            AppService = appService;
        }

        private IBlogPostAppService AppService { get; }

        // GET: Blog
        public ActionResult Index(int? pageNumber, string filtro)
        {
            IPagedList<BlogPostDto> model;
            try
            {
                if (filtro == "")
                {
                    filtro = null;
                }
                // Tenta buscar os dados no banco utilizando um filtro vazio (busca todos os registros)
                var filter = new BlogPostFilterDto {Filtro = filtro};
                model = AppService.List(filter).ToPagedList(pageNumber ?? 1, Configuration.PageSize);
            }
            catch (Exception ex)
            {
                model = new List<BlogPostDto>().ToPagedList(pageNumber ?? 1, 1);
                // Adiciona uma mensagem de erro
                TempData["error"] = "Erro ao carregar a lista de posts. " + ex.Message;
            }
            TempData["filtro"] = filtro;
            // retorna o model vazio com a mensagem de erro, ou o model com os dados
            return View(model);
        }

        // GET: Bloa/Create
        [HttpGet]
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(BlogPostDto model, HttpPostedFileBase file)
        {
            try
            {
                var fileType = file.ContentType.ToLower();

                if (fileType != "image/jpg" && fileType != "image/jpeg" && fileType != "image/png")
                {
                    ModelState.AddModelError("BpoImagePath", "A imagem deve ser do tipo JPEG ou PNG.");
                    return View(model);
                }

                var uploadPath = Server.MapPath("~/UploadedImage");
                var fileName = Util.HrBrasilia().ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
                var fullName = Path.Combine(uploadPath, fileName);
                file.SaveAs(fullName);

                model.BpoImagePath = fileName;
                model.BpoData = Util.HrBrasilia();

                AppService.Create(model);
                TempData["success"] = "Post criado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erro ao carregar a lista de posts. " + ex.Message;
            }

            return RedirectToAction("Create");
        }

        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            var model = new BlogPostDto();
            try
            {
                model = AppService.GetById(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erro ao carregar post. " + ex.Message;
            }
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Edit(BlogPostDto model, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    var fileType = file.ContentType.ToLower();

                    if (fileType != "image/jpg" && fileType != "image/jpeg" && fileType != "image/png")
                    {
                        ModelState.AddModelError("BpoImagePath", "A imagem deve ser do tipo JPEG ou PNG.");
                        return View(model);
                    }

                    var uploadPath = Server.MapPath("~/UploadedImage");
                    var fileName = Util.HrBrasilia().ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
                    var fullName = Path.Combine(uploadPath, fileName);
                    file.SaveAs(fullName);

                    model.BpoImagePath = fileName;
                }

                AppService.Update(model);
                TempData["success"] = "Post atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erro ao carregar post. " + ex.Message;
            }

            return RedirectToAction("Edit", new {id = model.BpoId});
        }

        // GET: Blog/Details/{id}
        public ActionResult Details(int id)
        {
            var model = new BlogPostDto();
            try
            {
                model = AppService.GetById(id);
                //model.BpoTexto = model.BpoTexto.Replace("\n", "<br />");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erro ao carregar a lista de posts. " + ex.Message;
            }
            return View(model);
        }

        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (AppService.Delete(id))
                {
                    TempData["success"] = "Post deletado com sucesso";
                }
                else
                {
                    TempData["error"] = "Erro ao deletar post";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erro ao carregar a lista de posts. " + ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
