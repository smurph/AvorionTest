using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvorionTest.Models;

namespace AvorionTest.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.MyCustomProperty = "blah blah blah";

            using (var db = new ApplicationDbContext())
            {
                ViewBag.NamesStartingWithA = String.Join(", ", db.TradeGoods.Where(g => g.Name.StartsWith("A")).Select(g => g.Name));
            }

            return View();
        }
    }
}