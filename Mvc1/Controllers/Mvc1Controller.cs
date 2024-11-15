using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc1.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Mvc1.Controllers
{
    public class Mvc1Controller : Controller
    {
        // GET: Mvc1
        Proje1DBEntities db = new Proje1DBEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORI.ToList();
            var degerler = db.TBLKATEGORI.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORI.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
                db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORI p1)
        {
            var ktg = db.TBLKATEGORI.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}