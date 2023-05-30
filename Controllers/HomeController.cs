using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstResponsiveWebAppMorishita.Models;

namespace FirstResponsiveWebAppMorishita.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.AgeThisYear = 0;
            ViewBag.AgeToday = 0;
            ViewBag.Name = "";
            return View();
        }
        [HttpPost]
        public IActionResult Index(FutureResponse model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.AgeThisYear = model.AgeThisYear();
                ViewBag.AgeToday = model.CurrentAge();
                ViewBag.Name = model.Name;
            }
            else
            {
                ViewBag.AgeThisYear = 0;
                ViewBag.AgeToday = 0;
                ViewBag.Name = "";
            }
            return View(model);
        }
    }
}

