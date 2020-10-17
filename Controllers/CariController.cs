using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Caris.Where(x=>x.Durum==true).ToList();
            return View(values);
        }
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cari cari)
        {
            cari.Durum = true;
            c.Caris.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var result = c.Caris.Find(id);
            result.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cariler = c.Caris.Find(cari.CariId);
            cari.CariAd = cariler.CariAd;
            cari.CariSoyad = cariler.CariSoyad;
            cari.CariSehir = cariler.CariSehir;
            cari.CariMail = cariler.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var values = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cr = c.Caris.Where(x => x.CariId == id).
                Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(values);
        }
        
    }
}