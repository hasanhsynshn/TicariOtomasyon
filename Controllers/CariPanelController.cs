using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        // GET: CariPanel
        [Authorize]
       
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var values = c.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(values);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString())
                .Select(y=>y.CariId).FirstOrDefault();
            var values = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(values);
        }
    }
}