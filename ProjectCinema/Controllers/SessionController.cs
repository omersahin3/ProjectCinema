using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCinema.Data.Models;
using ProjectCinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Controllers
{
    public class SessionController : Controller
    {
        Context c = new Context();
        SessionRepository sessionRepository = new SessionRepository();
        public IActionResult Index()
        {
            sessionRepository.TList("Movie");
            return View(sessionRepository.TList("Saloon"));
        }
        [HttpGet]
        public IActionResult AddSession()
        {
            List<SelectListItem> value = (from x in c.Saloons.ToList()  
                                          select new SelectListItem
                                          {
                                              Text = x.SaloonName,
                                              Value = x.SaloonID.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from y in c.Movies.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.MovieName,
                                              Value = y.MovieID.ToString()
                                          }).ToList();
            ViewBag.v1 = value;
            ViewBag.v2 = value2;
            //var Mov = new List<MovieCategory> { };
            //ViewBag.Mov =  new SelectList(Mov, "SessionID", "Time", "SaloonID", "MovieCategoryID");
            return View();
        }
        [HttpPost]
        public IActionResult AddSession(Session s)
        {
            sessionRepository.TAdd(s);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveSession(int id)
        {
            sessionRepository.TRemove(new Session { SessionID = id });
            return RedirectToAction("Index");
        }
        public IActionResult GetSession(int id)
        {
            List<SelectListItem> value = (from y in c.Saloons.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.SaloonName,
                                              Value = y.SaloonID.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from z in c.Movies.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.MovieName,
                                               Value = z.MovieID.ToString()
                                           }).ToList();
            ViewBag.v2 = value2;
            ViewBag.v1 = value;
            var x = sessionRepository.GetT(id);
            return View("GetSession", x);
        }
        public IActionResult UpdateSession(Session s)
        {
            sessionRepository.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}
