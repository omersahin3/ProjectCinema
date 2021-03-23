using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectCinema.Data.Models;
using ProjectCinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Controllers
{
    public class TicketController : Controller
    {
        TicketRepository ticketRepository = new TicketRepository();
        ChairRepository chairRepository = new ChairRepository();
        SessionRepository sessionRepository = new SessionRepository();
        Context c = new Context();
        public IActionResult Index()
        {
            return View(ticketRepository.TList("Session"));
        }
        [HttpGet]
        public IActionResult AddTicket()
        {
            List<SelectListItem> value = (from x in c.Sessions.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Time,
                                              Value = x.SessionID.ToString()
                                          }).ToList();
            ViewBag.v1 = value;
            return View();
        }
        [HttpPost]
        public IActionResult AddTicket(Ticket s)
        {
            ticketRepository.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddTicket2()
        {
            List<SelectListItem> value = (from x in c.Sessions.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Time,
                                              Value = x.SessionID.ToString()
                                          }).ToList();
            ViewBag.v1 = value;
            return View();
        }
        [HttpPost]
        public IActionResult AddTicket2(Ticket s)
        {
            var x = s.SessionID;// SessionID geçici olarak tutuluyor kaydetmiyorum.
            return RedirectToAction("GetSaloon3", new { id = x });
        }
        public IActionResult GetSaloon3(int id)
        {
            ViewBag.v2 = id;
            var salid = c.Sessions.Where(x => x.SessionID == id).Select(y => y.SaloonID).FirstOrDefault();
            var column = c.Saloons.Where(x => x.SaloonID == salid).Select(y => y.ColumnArmChairNumber).FirstOrDefault();
            var line = c.Saloons.Where(x => x.SaloonID == salid).Select(y => y.LineArmChairNumber).FirstOrDefault();
            ViewBag.c1 = line;
            ViewBag.c2 = column;
            int chair = c.Chairs.Where(x => x.SaloonID == salid).OrderBy(z => z.ChairID).Select(y => y.ChairID).FirstOrDefault();
            ViewBag.v1 = chair;
            var values = c.Chairs.Where(x => x.SaloonID == salid).ToList();
            return View("GetSaloon3", values);
        }
        public IActionResult RemoveTicket(int id)
        {
            ticketRepository.TRemove(new Ticket { TicketID = id });
            return RedirectToAction("Index");
        }
        public IActionResult GetTicket(int id)
        {
            List<SelectListItem> value = (from y in c.Sessions.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.Time,
                                              Value = y.SessionID.ToString()
                                          }).ToList();
            ViewBag.v1 = value;
            var x = ticketRepository.GetT(id); 
            return View("GetTicket", x);
        }
        public IActionResult UpdateTicket(Ticket s)
        {
            ticketRepository.TUpdate(s);
            return RedirectToAction("Index");
        }
        public IActionResult GetSaloon(int id)
        {
            ViewBag.v2 = id;
            var salid = c.Chairs.Where(x => x.ChairID == id).Select(y => y.SaloonID).FirstOrDefault();
            var column = c.Saloons.Where(x => x.SaloonID == salid).Select(y => y.ColumnArmChairNumber).FirstOrDefault();
            var line = c.Saloons.Where(x => x.SaloonID == salid).Select(y => y.LineArmChairNumber).FirstOrDefault();
            ViewBag.c1 = line;
            ViewBag.c2 = column;
            int chair = c.Chairs.Where(x => x.SaloonID == salid).OrderBy(z => z.ChairID).Select(y => y.ChairID).FirstOrDefault();
            ViewBag.v1 = salid;
            var values = c.Chairs.Where(x => x.SaloonID == salid).ToList();
            return View("GetSaloon", values);
        }
    }
}

