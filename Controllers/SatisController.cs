using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satış
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SatisHarekets.ToList();
            return View(values);
        }
        public ActionResult YeniSatis()
        {
            List<SelectListItem> value = (from x in c.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunId.ToString()
                                          }).ToList();


            List<SelectListItem> value2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();


            List<SelectListItem> value3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.value = value;
            ViewBag.value2 = value2;
            ViewBag.value3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            c.SatisHarekets.Add(s);
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> value = (from x in c.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunId.ToString()
                                          }).ToList();


            List<SelectListItem> value2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();


            List<SelectListItem> value3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.value = value;
            ViewBag.value2 = value2;
            ViewBag.value3 = value3;
            var values = c.SatisHarekets.Find(id);
            return View("SatisGetir", values);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var deger = c.SatisHarekets.Find(s.SatisId);
            deger.CariId = s.CariId;
            deger.Adet = s.Adet;
            deger.Fiyat = s.Fiyat;
            deger.PersonelId = s.PersonelId;
            deger.Tarih = s.Tarih;
            deger.ToplamTutar = s.ToplamTutar;
            deger.UrunId = s.UrunId;
            c.SaveChanges();
            return RedirectToAction("Index");
                
        }
        public ActionResult SatisDetay(int id)
        {
            var values = c.SatisHarekets.Where(x => x.SatisId == id).ToList();
            return View(values);

        }
    }
}