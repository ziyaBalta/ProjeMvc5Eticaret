using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjeMvc5Eticaret.Models.Siniflar;


namespace ProjeMvc5Eticaret.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {

            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin1(Cariler z)
        {
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == z.CariMail && x.CariSifre == z.CariSifre);
            if (degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.CariMail, false);
                Session["CariMail"] = degerler.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else 
            {
                return RedirectToAction("Index","Login");
            }  
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var degerler = c.Admins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            
            if(degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.KullaniciAdi, false);
                Session["KullaniciAdi"] = degerler.KullaniciAdi.ToString();
                return RedirectToAction("Index","Kategori");

            }

            else
            {
                return RedirectToAction("Index", "Login"); 
            }
        }
    }
}