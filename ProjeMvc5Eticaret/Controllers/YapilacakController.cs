﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;

namespace ProjeMvc5Eticaret.Controllers
{
    public class YapilacakController : Controller
    {
        Context c = new Context();
        // GET: Yapilacak
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var Yapilacaklar = c.Yapilacaks.ToList();
            return View(Yapilacaklar);
        }
    }
}