using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Faturalars.ToList();
            return View(values);
        }

        public ActionResult FaturaEkle()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var value = c.Faturalars.Find(f.FaturaId);
            
            value.FaturaSeriNo = f.FaturaSeriNo;
            value.FaturaSıraNo = f.FaturaSıraNo;
            value.Saat = f.Saat;
            value.Tarih = f.Tarih;
            value.TeslimEden = f.TeslimEden;
            value.TeslimAlan = f.TeslimAlan;
            value.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var values = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            return View(values);
        }
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}