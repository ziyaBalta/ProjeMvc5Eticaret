using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;

namespace ProjeMvc5Eticaret.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult faturaSil(int ID)
        {
            var degerler = c.Faturalars.Find(ID);
            c.Faturalars.Remove(degerler);
            return View("Index");
        }

        public ActionResult FaturaGetir(int ID)
        {
            var degerler = c.Faturalars.Find(ID);
            return View("FaturaGetir", degerler);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var degerler = c.Faturalars.Find(f.FaturaID);
            degerler.FaturaSeriNo = f.FaturaSeriNo;
            degerler.FaturaSıraNo = f.FaturaSıraNo;
            degerler.VergiDairesi = f.VergiDairesi;
            degerler.Tarih = f.Tarih;
            degerler.Saat = f.Saat;
            degerler.Toplam = f.Toplam;
            degerler.TeslimEden = f.TeslimEden;
            degerler.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int ID)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaID == ID).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}