using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MBand.Models;
using System.IO;

namespace MBand.Controllers
{
    public class BandsController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Bands
        public ActionResult Index()
        {
            var bands = db.Bands;
            return View(db.Bands.ToList());
        }


        //public ActionResult AddImage()
        //{
        //    Band band = new Band();
        //    return View(band);
        //}

        //[HttpPost]
        //public ActionResult AddImage(Band model, HttpPostedFileBase image1)
        //{
        //    if (image1 != null)
        //    {
        //        model.BandImg = new byte[image1.ContentLength];
        //        image1.InputStream.Read(model.BandImg, 0, image1.ContentLength);
        //    }
        //    db.Bands.Add(model);
        //    db.SaveChanges();
        //    return View(model);
        //}

        //public ActionResult AddImage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddImage(Band band, HttpPostedFileBase uploadImage)
        //{
        //    if (ModelState.IsValid && uploadImage != null)
        //    {
        //        byte[] imageData = null;
        //        // считываем переданный файл в массив байтов
        //        using (var binaryReader = new BinaryReader(uploadImage.InputStream))
        //        {
        //            imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
        //        }
        //        // установка массива байтов
        //        band.BandImg = imageData;

        //        db.Bands.Add(band);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    else if (ModelState.IsValid)
        //    {
        //        db.Bands.Add(band);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(band);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddImage([Bind(Include = "BandId,Name,YearFoundation,ImgPath,BandImg")] Band band)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Bands.Add(band);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(band);
        //}



        // GET: Bands/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // GET: Bands/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Band band, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                band.BandImg = imageData;

                db.Bands.Add(band);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                db.Bands.Add(band);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(band);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BandId,Name,YearFoundation,BandImg")] Band band)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Bands.Add(band);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(band);
        //}

        // GET: Bands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            var bands = db.Bands;
            return View(band);
        }

        // POST: Bands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Band band, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                band.BandImg = imageData;

                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                //Band thisProduct = db.Bands.Where(p => p.BandId == band.BandId).FirstOrDefault();
                //band.BandImg = thisProduct.BandImg;

                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(band);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BandId,Name,YearFoundation,BandImg")] Band band)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(band).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    var bands = db.Bands;
        //    return View(band);
        //}

        // GET: Bands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            var bands = db.Bands;
            return View(band);
        }

        // POST: Bands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = db.Bands.Find(id);
            db.Bands.Remove(band);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
