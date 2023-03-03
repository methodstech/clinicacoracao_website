// ----------------------------------------------------------------------------
// WebSite.HomeController.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
