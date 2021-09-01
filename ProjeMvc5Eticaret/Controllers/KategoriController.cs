using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace ProjeMvc5Eticaret.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var deger = c.Kategoris.ToList().ToPagedList(sayfa, 5);
            return View(deger);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int ID)
        {
            var deger = c.Kategoris.Find(ID);
            c.Kategoris.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int ID)
        {
            var deger = c.Kategoris.Find(ID);
            return View("KategoriGetir", deger);
        }

        public ActionResult KategoriGuncelle(Kategori g)
        {
            var deger = c.Kategoris.Find(g.KategoriID);
            deger.KategoriAdi = g.KategoriAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}