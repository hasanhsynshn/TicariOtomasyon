using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Uruns.Where(x => x.UrunId == 2).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayId==2).ToList();
            return View(cs);
        }
    }
}