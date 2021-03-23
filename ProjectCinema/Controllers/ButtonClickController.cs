using Microsoft.AspNetCore.Mvc;
using ProjectCinema.Data.Models;
using ProjectCinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Controllers
{
    public class ButtonClickController : Controller
    {
        SaloonRepository saloonRepository = new SaloonRepository();
        static List<Button> buttons = new List<Button>();
        static List<Chair> Chairs = new List<Chair>();
        Context c = new Context();
        ChairRepository chairRepository = new ChairRepository();
        TicketRepository ticketRepository = new TicketRepository();
        public IActionResult Index()
        {
            return View(saloonRepository.TList());
        }
        public IActionResult GetSaloon(int id)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons.Add(new Button(true));
                }
            }
            return View("GetSaloon", buttons);
        }
        public IActionResult GetSaloon2(int id)
        {
            var column = c.Saloons.Where(x => x.SaloonID == id).Select(y => y.ColumnArmChairNumber).FirstOrDefault();
            var line = c.Saloons.Where(x => x.SaloonID == id).Select(y => y.LineArmChairNumber).FirstOrDefault();
            ViewBag.c1 = line;
            ViewBag.c2 = column;
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    buttons.Add(new Button(true));
                }
            }
            return View("GetSaloon2", buttons);
        }
        public IActionResult GetSaloon3(int id)
        {
            var column = c.Saloons.Where(x => x.SaloonID == id).Select(y => y.ColumnArmChairNumber).FirstOrDefault();
            var line = c.Saloons.Where(x => x.SaloonID == id).Select(y => y.LineArmChairNumber).FirstOrDefault();
            ViewBag.c1 = line;
            ViewBag.c2 = column;
            int chair = c.Chairs.Where(x => x.SaloonID == id).OrderBy(z => z.ChairID).Select(y => y.ChairID).FirstOrDefault();
            ViewBag.v1 = chair;
            var values = c.Chairs.Where(x => x.SaloonID == id).ToList();
            return View("GetSaloon3", values);
        }
        public IActionResult HandleButtonClick(string mine)
        {
            int buttonNumber = Int32.Parse(mine);
            buttons[buttonNumber].State = !buttons[buttonNumber].State;
            return View("GetSaloon", buttons);
        }
        [HttpGet("changestatus_chair/{id}")]
        public IActionResult changeStatusChair(int id)
        {
            Chair chair = chairRepository.GetT(id);
            string message = null;
           if(chair.Status == true)
            {
                message = "Koltuk durumu pasif.";
                chair.Status = false;
            }
            else
            {
                message = "Koltuk durumu aktif";
                chair.Status = true;
            }
            try
            {
                chairRepository.TUpdate(chair);
                return Ok(message);
            }catch(Exception e)
            {
                return NotFound("başarısız");
            }
            
        }
        [HttpGet("ticketstatus_chair/{id}")]
        public IActionResult ticket(int id)
        {
            Chair chair = chairRepository.GetT(id);
            string message = null;
            if (chair.Status == true)
            {
                chair.Status = false;
            }
            else
            {
            }
            try
            {
                chairRepository.TUpdate(chair);
                return Ok(message);
            }
            catch (Exception e)
            {
                return NotFound("başarısız");
            }

        }
        [HttpPost("AddTickettt/{id}/{id2}")]
        public IActionResult AddTickettt(int id, int id2)
        {
            Chair chair = chairRepository.GetT(id2);
            if (chair.Status == true)
            {
                Ticket s = new Ticket();
                s.SessionID = id;
                s.ChairID = id2;
                ticketRepository.TAdd(s);
                chair.Status = false;
            }
            else
            {
            }
            try
            {
            }
            catch (Exception e)
            {
                return NotFound("başarısız");
            }
            return RedirectToAction("Index");
        }
    }
}
