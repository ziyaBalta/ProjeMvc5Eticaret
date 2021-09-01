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
    public class UrunController : Controller
    {
        Context c = new Context();

        public ActionResult Index(int sayfa = 1)
        {
            var Urunler = c.Uruns.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 5);
            return View(Urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {

            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAdi,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr1 = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int ID)
        {
            var deger = c.Uruns.Find(ID);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int ID)
        {
            List<SelectListItem> degerler = (from x in c.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAdi,
                                                 Value = x.UrunID.ToString()
                                             }).ToList();
            ViewBag.dgr1 = degerler;

            var UrunDeger = c.Uruns.Find(ID);
            return View("UrunGetir",UrunDeger);
        }

        public ActionResult UrunGuncelle (Urun u)
        {
            var deger = c.Uruns.Find(u.KategoriID);
            deger.UrunAdi = u.UrunAdi;
            deger.Marka = u.Marka;
            deger.Stok = u.Stok;
            deger.AlisFiyati = u.AlisFiyati;
            deger.SatisFiyati = u.SatisFiyati;
            deger.Durum = u.Durum;
            deger.UrunGorsel = u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        


    }
}