using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telefon.Models;

namespace Telefon.Controllers
{
    public class HomeController : Controller
    {
        TelefonumEntitiesConnectionDB db = new TelefonumEntitiesConnectionDB();
        // GET: Home
        public ActionResult Liste()
        {
            ViewBag.RehberListesi = db.Rehber.ToList();
            return View();
        }
        public ActionResult YeniKisi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Telefon.Models.Rehber YeniKisi)
        {
            db.Rehber.Add(YeniKisi);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }
        [HttpPost]
        public ActionResult Duzenle(Telefon.Models.Rehber d)
        {
            Rehber _r = db.Rehber.FirstOrDefault(x => x.id == d.id);
            _r.Ad = d.Ad;
            _r.Soyad = d.Soyad;
            _r.Telefon = d.Telefon;
            _r.Mail = d.Mail;
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id)
        {
            Rehber silinecekKisi = db.Rehber.FirstOrDefault(x => x.id == id);
            db.Rehber.Remove(silinecekKisi);
            db.SaveChanges();
            return RedirectToAction("Liste");
        }

        public ActionResult Ara(string deger)
        {
            ViewBag.Sonuc = db.Rehber.Where(x => x.Ad.Contains(deger) || x.Soyad.Contains(deger) || x.Telefon.Contains(deger) | x.Mail.Contains(deger));
            ViewBag.Deger = deger;
            return View();
        }
    }
}