using Microsoft.AspNetCore.Mvc;
using ProjectCinema.Data.Models;
using ProjectCinema.Repositories;
using System;
using System.Linq;

namespace ProjectCinema.Controllers
{
    public class SaloonController : Controller
    {
        SaloonRepository saloonRepository = new SaloonRepository();
        ChairRepository chairRepository = new ChairRepository();
        Context c = new Context();
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
            c.Saloons.Add(s);
            c.SaveChanges();
            int id = s.SaloonID;
            for (int i = 0; i < s.LineArmChairNumber; i++)
            {

                for (int j = 0; j < s.ColumnArmChairNumber; j++)
                {
                    var chair = new Chair(); 
                    chair.Status = true;
                    chair.SaloonID = id;
                    c.Chairs.Add(chair);
                    c.SaveChanges();
                }
             }
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
