using Fika.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fika.Controllers
{
    public class MainController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult VeriGetir()
        {
            using (db)
            {
                // var data = db.Musteris.Include(x => x.Grup).ToList();
                var data = db.Musteris
                .Join(
                     db.Personels,
                     musteri => musteri.MusteriID,
                     personel => personel.PersonelID,
                     (musteri, personel) => new
                     {
                         MusteriID = musteri.MusteriID,
                         Unvan = musteri.Unvan,
                         GrupID = musteri.Grup.Adi,
                         Operasyon = musteri.OperasyonID.Isim,
                         Satis = musteri.SatisID.Isim
                     }
                 ).ToList();
                return Json(data);
            }

        }

        public JsonResult GrupGetir()
        {
            var gruplar = db.Grups.Select(x => new { Id = x.GrupID, Text = x.Adi }).Distinct();
            return Json(gruplar);
        }

        public JsonResult GrupFiltre(int grup)
        {
            using (db)
            {
                var data = db.Musteris
                .Where(x => x.GrupID == grup).Join(
                     db.Personels,
                     musteri => musteri.MusteriID,
                     personel => personel.PersonelID,
                     (musteri, personel) => new
                     {
                         MusteriID = musteri.MusteriID,
                         Unvan = musteri.Unvan,
                         GrupID = musteri.Grup.Adi,
                         Operasyon = musteri.OperasyonID.Isim,
                         Satis = musteri.SatisID.Isim
                     }
                 ).ToList();
                return Json(data);
            }
        }

        public JsonResult UrunGetir()
        {
            var urun = db.Stoks.Select(x => new { Id = x.StokID, Text = x.Adi }).Distinct();
            return Json(urun);
        }

        public JsonResult PersonelGetir()
        {
            var personel = db.Personels.Select(x => new { Id = x.PersonelID, Text = x.Isim }).ToList();
            return Json(personel);
        }

        [HttpPost]
        public IActionResult SatisYap(int StokId, int MusteriId, int PersonelId)
        {
            SatisHareket satisHareket = new SatisHareket
            {
                StokID = StokId,
                MusteriID = MusteriId,
                PersonelID = PersonelId,
                SatisZamani = DateTime.Parse(DateTime.Now.ToShortTimeString())
            };
            db.SatisHarekets.Add(satisHareket);
            db.SaveChanges();
            return Json(satisHareket);
        }
    }
}

