using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
               
            }
            return View(urunler.ToList());
        }
        public ActionResult YeniUrun()
        {
            List<SelectListItem> value = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriId.ToString()

                                          }).ToList();
            ViewBag.value = value;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var value = c.Uruns.Find(id);
            value.Durum = false;
            //c.Uruns.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(Urun u)
        {
            c.Entry(u).State = EntityState.Modified;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> value = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriId.ToString()

                                          }).ToList();
            ViewBag.value = value;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunId);
            urn.UrunAd = u.UrunAd;
            urn.AlisFiyat = u.AlisFiyat;
            urn.Durum = u.Durum;
            urn.KategoriId = u.KategoriId;
            urn.Marka = u.Marka;
            urn.SatisFiyat = u.SatisFiyat;
            urn.Stok = u.Stok;
            urn.UrunGorsel = u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var values = c.Uruns.ToList();
            return View(values);
        }
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> value = (from x in c.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAd + " " + x.PersonelSoyad,
                                              Value = x.PersonelId.ToString()
                                          }).ToList();
            ViewBag.dgr = value;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr2 = deger1.SatisFiyat;
            ViewBag.dgr1 = deger1.UrunId;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            c.SatisHarekets.Add(p);
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }

    }
}