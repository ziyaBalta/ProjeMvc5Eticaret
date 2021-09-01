using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace ProjeMvc5Eticaret.Models.Siniflar
{
    public class CariController : Controller
    {
        Context c = new Context();
        // GET: Cari
        public ActionResult Index(int sayfa = 1)
        {
            var deger = c.Carilers.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler j)
        {
            j.Durum = true;
            c.Carilers.Add(j);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int ID)
        {
            var deger = c.Carilers.Find(ID);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int ID)
        {
            var degerler = c.Carilers.Find(ID);
            return View("CariGetir", "Cari");
        }


    }
}