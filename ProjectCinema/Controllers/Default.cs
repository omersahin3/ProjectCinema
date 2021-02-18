using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Controllers
{
    public class Default : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Salon()
        {
            return View();
        }
    }
}
