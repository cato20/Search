using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Search.Models;
namespace Search.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResultSearch(string txtSearch)
        {

            ServiceSearch s = new ServiceSearch();
            string txtFormat = s.formatText(txtSearch);
            string Json = s.getJSON(txtFormat);
            var model = s.readingJSON(Json);
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}