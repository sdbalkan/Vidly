using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.DomainModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Matrix" };
            var customers = new List<Customer>()
            {
                new Customer { Name = "Sedat" },
                new Customer { Name = "Pınar" }
            };

            var model = new RandomViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            return View(model);
        }

        [Route("Movie/Filter/{year:int}/{month:range(1,12)}")]
        public ActionResult FilterByYearMonth(int year, int month)
        {
            return Content("year = " + year + ", month = " + month);
        }
    }
}