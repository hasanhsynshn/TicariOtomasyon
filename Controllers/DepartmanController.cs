using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{

    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            
            var values = c.Departmans.Where(x=>x.Durum==true).ToList();
            
            return View(values);
        }
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir",dpt);
        }
        public ActionResult DepartmanGuncelle(Departman model)
        {
            var result = c.Departmans.Find(model.DepartmanId);
            result.DepartmanAd = model.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var values = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanId == id).
                Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values);


        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var values=c.SatisHarekets.Where(x=>x.PersonelId==id).ToList();
            var per = c.Personels.Where(x => x.PersonelId == id).
                  Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpersonel = per;
            return View(values);
        }
    }
}