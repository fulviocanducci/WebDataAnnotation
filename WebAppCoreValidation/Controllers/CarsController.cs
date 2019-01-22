using Microsoft.AspNetCore.Mvc;
using WebAppCoreValidation.Models;
namespace WebAppCoreValidation.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}