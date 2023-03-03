// ----------------------------------------------------------------------------
// ContactController.cs
// WebSite
// Created by Paulo Gemniczak on 12/01/2018
// Copyright © 2018 Method's Informática LTDA. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Web.Mvc;
using MethodsEmail;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        public ActionResult Index(Contato model)
        {
            try
            {
                var email = new Email
                {
                    Assunto = "Contato - Clínica do Coração SL",
                    Corpo = "Nome: " + model.Nome + "\nE-mail: " + model.Email + "\nTelefone: " + model.Telefone + "\nMensagem:\n" + model.Mensagem
                };
                email.AdicionarEnderecoDestino("contato@clinicadocoracaosl.com.br");
                email.Enviar();
                TempData["alert"] = "Mensagem enviada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["alert"] = "Erro ao enviar mensagem: " + exception.Message;
                return RedirectToAction("Index");
            }
        }

        public JsonResult EnviarEmail(Contato model)
        {
            try
            {
                var email = new Email
                {
                    Assunto = "Contato do Site",
                    Corpo = "Nome: " + model.Nome + "\nE-mail: " + model.Email + "\nTelefone: " + model.Telefone + "\nMensagem:\n" + model.Mensagem
                };
                email.AdicionarEnderecoDestino("contato@clinicadocoracaosl.com.br");
                email.Enviar();
                return Json("Mensagem enviada com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                TempData["alert"] = "Erro ao enviar mensagem: " + exception.Message;
                return Json("Erro: " + exception.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}