using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDurumYonetimi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Oturum Oluşturma
            Session.Add("egitmen", "Altan Emre DEMİRCİ");
            Session.Add("sayi", 5);
            Session["egitmen2"] = "Altan Emre";


            ViewBag.message = Session["egitmen"];

            //İstenilen Oturumu Kapatma
            Session.Remove("egitmen2");

            //Bütün Oturumlar Kapatılır.
            Session.Abandon();


            ViewBag.Online = HttpContext.Application["OnlineUyeSayisi"];

            return View();
        }

        public ActionResult Index2()
        {
            //Oturum Oluşturma
            HttpContext.Application.Add("egitmen", "Altan Emre DEMİRCİ");
            HttpContext.Application["egitmen2"] = "Altan Emre";
            ViewBag.Message = HttpContext.Application["egitmen"];

            //İstenilen Oturumu Kapatma
            HttpContext.Application.Remove("egitmen2");

            //Bütün Oturumlar Kapatılır.
            HttpContext.Application.RemoveAll();

            return View();

            //Session'la farkı application herkese açık olur. Session bir kullanıcıya açık olur. 

        }

        //Session gibi kullanıcıya aittir.Farkı istemci tarafında tutulurlar.Kullanıcı istediği zaman silebilir.
        public ActionResult Cookie()
        {
            HttpCookie cookie = new HttpCookie("kullanici", "Altan Emre");

            HttpContext.Response.Cookies.Add(cookie);

            cookie.Expires = DateTime.Now.AddDays(1); //Default olarak 30 dk. Kod ile 1 gün kalıcı olmasını istedim.

            ViewBag.Message = HttpContext.Request.Cookies["kullanici"].Value;

            //HttpContext.Response.Cookies.Remove("kullanici");

            return View();
        }
    }
}