using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;


namespace ProjeMvc5Eticaret.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int ID)
        {
            var degerler = c.Personels.Find(ID);
            c.Personels.Remove(degerler);
            c.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult PersonelGetir(int ID)
        {
            List<SelectListItem> bagview = (from x in c.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAdi,
                                                Value = x.PersonelID.ToString()
                                            }).ToList();
            ViewBag.dgr1 = bagview;

            var degerler = c.Personels.Find(ID);
            return View("PersonelGetir", degerler);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var degerler = c.Personels.Find(p.PersonelID);
            degerler.PersonelAdi = p.PersonelAdi;
            degerler.PersaonelSoyad = p.PersaonelSoyad;
            degerler.PersonelGorsel = p.PersonelGorsel;
            degerler.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult PersonelListe()
        {
            var degerler = c.Personels.ToList();

            return View(degerler);
        }



    }
}