using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;

namespace ProjeMvc5Eticaret.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satıs
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> degerler1 = (from x in c.Uruns.ToList()
                                             select new SelectListItem

                                             {
                                                 Text = x.UrunAdi,
                                                 Value = x.UrunID.ToString()
                                             }
                                             ).ToList();

            List<SelectListItem> degerler2 = (from x in c.Carilers.ToList()
                                              select new SelectListItem

                                              {
                                                  Text = x.CariAdi + "" + x.CariSoyadi,
                                                  Value = x.CariID.ToString()
                                              }
                                             ).ToList();

            List<SelectListItem> degerler3 = (from x in c.Personels.ToList()
                                              select new SelectListItem

                                              {
                                                  Text = x.PersonelAdi + "" + x.PersaonelSoyad,
                                                  Value = x.PersonelID.ToString()
                                              }
                                 ).ToList();


            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int ID)
        {
            List<SelectListItem> degerler1 = (from x in c.Uruns.ToList()
                                              select new SelectListItem

                                              {
                                                  Text = x.UrunAdi,
                                                  Value = x.UrunID.ToString()
                                              }
                                            ).ToList();

            List<SelectListItem> degerler2 = (from x in c.Carilers.ToList()
                                              select new SelectListItem

                                              {
                                                  Text = x.CariAdi + "" + x.CariSoyadi,
                                                  Value = x.CariID.ToString()
                                              }
                                             ).ToList();

            List<SelectListItem> degerler3 = (from x in c.Personels.ToList()
                                              select new SelectListItem

                                              {
                                                  Text = x.PersonelAdi + "" + x.PersaonelSoyad,
                                                  Value = x.PersonelID.ToString()
                                              }
                                 ).ToList();


            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            var deger = c.SatisHarekets.Find(ID);
            return View("SatisGetir",deger);
        }

        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var degerler = c.SatisHarekets.Find(p.SatisID);
            degerler.CariID = p.CariID;
            degerler.Adet = p.Adet;
            degerler.Fiyat = p.Fiyat;
            degerler.PersonelID = p.PersonelID;
            degerler.Tarih = p.Tarih;
            degerler.ToplamTutar = p.ToplamTutar;
            degerler.UrunID = p.UrunID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}