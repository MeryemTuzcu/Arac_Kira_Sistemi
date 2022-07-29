using AracKiraSistemi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace KutuphaneYonetimi1O.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Musteri pMusteri)
        {
            pMusteri.MusteriKAdi = pMusteri.MusteriEmail;
            using (AracKiraContext db = new AracKiraContext())
            {
                Musteri musteri = db.Musteri.AsNoTracking().Where(x => (x.MusteriEmail == pMusteri.MusteriEmail || x.MusteriKAdi == pMusteri.MusteriKAdi) && x.MusteriParola == pMusteri.MusteriParola).FirstOrDefault();


                if (musteri != null)
                {
                    FormsAuthentication.SetAuthCookie(musteri.MusteriKAdi, false);
                    
                    Session["MusteriId"] = musteri.MusteriId;
                    Session["Musteri"] = musteri.FirstName + " " + musteri.LastName;
                    Session["MusteriEmail"] = musteri.MusteriEmail;

                    
                    return RedirectToAction("Index", "KiraTuru");

                }
            }

            return RedirectToAction("Index", "KiraTuru");
        }


        public ActionResult CikisYap()
        {
            
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}