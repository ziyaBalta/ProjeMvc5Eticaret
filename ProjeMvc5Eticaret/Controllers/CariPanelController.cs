using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeMvc5Eticaret.Models.Siniflar;

namespace ProjeMvc5Eticaret.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var Mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == Mail);
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var Mail = (string)Session["CariMail"];
            var ID = c.Carilers.Where(x => x.CariMail == Mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == ID).ToList();
            return View(degerler);
        }
    }
}