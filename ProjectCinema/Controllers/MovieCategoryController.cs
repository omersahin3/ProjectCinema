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
    public class MovieCategoryController : Controller
    {
        Context c = new Context();
        MovieCategoryRepository movieCategoryRepository = new MovieCategoryRepository();
        public IActionResult Index()
        {
            movieCategoryRepository.TList("Category");
            return View(movieCategoryRepository.TList("Movie"));
        }
        [HttpGet]
        public IActionResult AddMovieCategory()
        {
            List<SelectListItem> value = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();

            ViewBag.v1 = value;
            return View();
        }
        [HttpPost]
        public IActionResult AddMovieCategory(MovieCategory m)
        {
            movieCategoryRepository.TAdd(m);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveMovieCategory(int id)
        {
            movieCategoryRepository.TRemove(new MovieCategory { MovieCategoryID = id });
            return RedirectToAction("Index");
        }
        public IActionResult GetMovieCategory(int id)
        {
            List<SelectListItem> value = (from y in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.CategoryName,
                                              Value = y.CategoryID.ToString()
                                          }).ToList();

            ViewBag.v1 = value;
            var x = movieCategoryRepository.GetT(id);
            return View("GetMovieCategory", x);
        }
        public IActionResult UpdateMovieCategory(MovieCategory m)
        {
            movieCategoryRepository.TUpdate(m);
            return RedirectToAction("Index");
        }
    }
}
