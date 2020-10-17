using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;
using PagedList.Mvc;
using PagedList;

namespace TicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();

        public ActionResult Index(int sayfa=1)
        {
            var values = c.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(values);

        }
        public ActionResult KategoriEkle()
        {
            return View();

        }


        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();

            return RedirectToAction("Index");

        }
        
        public ActionResult Sil(int id)
        {
            var result = c.Kategoris.Find(id);
            c.Kategoris.Remove(result);

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            
          var result=  c.Kategoris.Find(id);
            return View("KategoriGetir",result);
        }
       
        public ActionResult Guncelle(Kategori k)
        {
            //İki yöntem
            //var result = c.Kategoris.Find(k.KategoriId);
            //result.KategoriAd = k.KategoriAd;
            c.Entry(k).State = EntityState.Modified;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}