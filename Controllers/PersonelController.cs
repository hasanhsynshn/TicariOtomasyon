using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Personels.ToList();
            return View(values);
        }
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> value = (from x in c.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value=x.DepartmanId.ToString()
                                          }).ToList() ;
            ViewBag.value = value;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi+uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaAdi + uzanti;

            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> value = (from x in c.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanId.ToString()
                                          }).ToList();
            ViewBag.value = value;
            var prs=c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Personel model)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                model.PersonelGorsel = "/Image/" + dosyaAdi + uzanti;

            }
            var stuff = c.Personels.Find(model.PersonelId);
            stuff.PersonelAd = model.PersonelAd;
            stuff.PersonelSoyad = model.PersonelSoyad;
            stuff.PersonelGorsel = model.PersonelGorsel;
            stuff.PersonelId = model.PersonelId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      public ActionResult PersonelList()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}