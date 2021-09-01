using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;

namespace ProjeMvc5Eticaret.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var deger = c.Departmen.Where(x => x.Durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int ID)
        {
            var deger = c.Departmen.Find(ID);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int ID)

        {
            var deger = c.Departmen.Find(ID);
            return View("DepartmanGetir", deger);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var deger = c.Departmen.Find(d.DepartmanID);
            deger.DepartmanAdi = d.DepartmanAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int ID)
        {
            var degerler = c.Personels.Where(x => x.DepartmanID == ID).ToList();
            var dpt = c.Personels.Where(x => x.DepartmanID == ID).Select(y => y.Departman.DepartmanAdi).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }

        public  ActionResult DepartmanPersonelSatis(int ID)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelID == ID).ToList();
            return View(degerler);
        }

    }
}