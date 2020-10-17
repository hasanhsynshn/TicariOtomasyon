using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Caris.Count().ToString();
            ViewBag.result = value;
            var value2 = c.Uruns.Count().ToString();
            ViewBag.result2 = value2;
            var value3 = c.Kategoris.Count().ToString();
            ViewBag.result3 = value3;
            var value4 = (from x in c.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.result4 = value4;
            var toDOlist = c.Yapilacaks.ToList();
            return View(toDOlist);
        }
    }
}