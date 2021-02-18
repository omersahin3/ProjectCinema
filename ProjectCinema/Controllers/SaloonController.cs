using Microsoft.AspNetCore.Mvc;
using ProjectCinema.Data.Models;
using ProjectCinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Controllers
{
    public class SaloonController : Controller
    {
        SaloonRepository saloonRepository = new SaloonRepository();
        public IActionResult Index()
        {
            return View(saloonRepository.TList());
        }
        [HttpGet]
        public IActionResult AddSaloon()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSaloon(Saloon s)
        {
            saloonRepository.TAdd(s);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveSaloon(int id)
        {
            saloonRepository.TRemove(new Saloon { SaloonID = id });
            return RedirectToAction("Index");
        }
        public IActionResult GetSaloon(int id)
        {
            var x = saloonRepository.GetT(id);
            return View("GetSaloon", x);
        }
        public IActionResult UpdateSaloon(Saloon s)
        {
            saloonRepository.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}
