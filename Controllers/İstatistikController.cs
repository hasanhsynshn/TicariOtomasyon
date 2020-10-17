using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Caris.Count().ToString();
            ViewBag.d1 = value1;
            var value2 = c.Uruns.Count().ToString();
            ViewBag.d2 = value2;
            var value3 = c.Personels.Count().ToString();
            ViewBag.d3 = value3;
            var value4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = value4;
            var value5 = c.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = value5;
            var value6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = value6;
            var value7 = c.Uruns.Count(x => x.Stok<=20).ToString();
            ViewBag.d7 = value7;
            var value8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.SatisFiyat).FirstOrDefault();
            ViewBag.d8 = value8;
            var value9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.Marka).FirstOrDefault();
            ViewBag.d9 = value9;
            var value10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = value10;
            var value11 = c.Uruns.Count(x => x.UrunAd == "Fırın").ToString();
            ViewBag.d11 = value11;
            var value12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(y=>y.Count()).Select(z=>z.Key).FirstOrDefault();
            ViewBag.d12 = value12;
            var value13 = c.Uruns.Where(u=>u.UrunId==( c.SatisHarekets.
            GroupBy(x => x.UrunId).
            OrderByDescending(z => z.Count()).
            Select(y => y.Key).
            FirstOrDefault())).
            Select(k=>k.UrunAd).
            FirstOrDefault();
            ViewBag.d13 = value13;
            var value14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = value14;
            DateTime bugun = DateTime.Today;
            //var value15 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            //ViewBag.d15 = value15;
            var value16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = value16;
            return View();
        }
        public ActionResult Tablolar()
        {
            var sorgu = from x in c.Caris group x by x.CariSehir
                      into g select new SinifGrup
                      {
                          Sehir = g.Key,
                          Sayi = g.Count()

        };
            return View(sorgu);
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd
                       into g
                         select new SinifGrup2
                         {
                             DepartmanId = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Caris.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                         group x by x.Marka
                       into g
                         select new SinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());


        }
    }
}