using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turpax.Models;

namespace Turpax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Turpax turpax)
        {
            using (ozbolukEntities db = new ozbolukEntities())
            {
                string rasgele = Guid.NewGuid().ToString().Substring(0, 6);
                Models.Turpax turpax1 = new Models.Turpax
                {
                    Filo_kodu = rasgele,
                    Istasyon_fiyati = turpax.Istasyon_fiyati,
                    Plaka = turpax.Plaka,
                    Satis_fiyati = turpax.Satis_fiyati,
                   
                    Litre = turpax.Litre,
                    Tarih_Saat = turpax.Tarih_Saat,
                    Tutar = turpax.Tutar,
                    Satis_tipi ="Otomasyon",
                    Pompa = "00"+turpax.Pompa,
                    Pompaci = "öksüz48",
                    Urun_adi = turpax.Urun_adi
                };
                db.Turpax.Add(turpax1);
                db.SaveChanges();
            }
           
           
            return View();
        }
        public ActionResult Index(string id)
        {
            using (ozbolukEntities db = new ozbolukEntities())
            {
                if (!string.IsNullOrEmpty(id))
                {
                    return View(db.Turpax.Where(x=>x.Plaka.Contains(id)).ToList());
                }
                return View(db.Turpax.ToList());
            }
        }

        public ActionResult Delete(int id)
        {
            using (ozbolukEntities db = new ozbolukEntities())
            {
               var sa= db.Turpax.FirstOrDefault(x => x.Id==id);
                db.Turpax.Remove(sa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          

        }

    }
}