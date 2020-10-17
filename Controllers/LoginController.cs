using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cari p)
        {
            c.Caris.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        public PartialViewResult CariLogin()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CariLogin(Cari ca)
        {
            var result = c.Caris.FirstOrDefault
                (x => x.CariMail == ca.CariMail && 
                x.CariSifre == ca.CariSifre);
            if (result!=null)
            {
                FormsAuthentication.SetAuthCookie(result.CariMail, false);
                Session["CariMail"] = result.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
           
            else
            {
                return RedirectToAction("Index","Login");
            }
            
            
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
    }
}