using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreValidation.Models;

namespace WebAppCoreValidation.Controllers
{
    public class PeoplesController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<People>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(People people)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }
    }
}