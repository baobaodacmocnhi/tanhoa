using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhongTroWebMVC.Models;
using System.IO;
using System.Drawing;

namespace PhongTroWebMVC.Controllers
{
    public class HinhAnhsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: HinhAnhs
        public ActionResult Index()
        {
            var hinhAnhs = db.HinhAnhs.Include(h => h.KhachHang);
            return View(hinhAnhs.ToList());
        }

        // GET: HinhAnhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Create
        public ActionResult Create()
        {
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen");
            return View();
        }

        // POST: HinhAnhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Include = "ID_KhachHang")] HinhAnh hinhAnh, IEnumerable<HttpPostedFileBase> imageUploads)
        {
            if (ModelState.IsValid)
            {
                if (imageUploads != null)
                {
                    for (int i = 0; i < imageUploads.Count(); i++)
                    {
                        if (imageUploads.ElementAt(i) != null && imageUploads.ElementAt(i).ContentLength > 0)
                        {
                            HinhAnh en = new HinhAnh();
                            en.ID_KhachHang = hinhAnh.ID_KhachHang;
                            if (db.HinhAnhs.Count() == 0)
                                en.ID = 1;
                            else
                                en.ID = db.HinhAnhs.Max(item => item.ID) + 1;

                            byte[] imageData = new byte[imageUploads.ElementAt(i).ContentLength];
                            imageUploads.ElementAt(i).InputStream.Read(imageData, 0, imageUploads.ElementAt(i).ContentLength);

                            //MemoryStream ms = new MemoryStream(imageData);
                            Image originalImage = byteArrayToImage(imageData);

                            if (originalImage.PropertyIdList.Contains(0x0112))
                            {
                                int rotationValue = originalImage.GetPropertyItem(0x0112).Value[0];
                                switch (rotationValue)
                                {
                                    case 1: // landscape, do nothing
                                        break;

                                    case 8: // rotated 90 right
                                            // de-rotate:
                                        originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
                                        break;

                                    case 3: // bottoms up
                                        originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
                                        break;

                                    case 6: // rotated 90 left
                                        originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
                                        break;
                                }
                            }
                            en.Image = imageToByteArray(resizeImage(originalImage, 2048));
                            en.Image_Thumb = imageToByteArray(resizeImage(originalImage, 1024));
                            en.CreateDate = DateTime.Now;
                            db.HinhAnhs.Add(en);
                            db.SaveChanges();
                        }
                    }
                    //foreach (var file in imageUploads)
                    //{
                    //    if (file != null && file.ContentLength > 0)
                    //    {
                    //        HinhAnh en = new HinhAnh();
                    //        en.ID_KhachHang = hinhAnh.ID_KhachHang;
                    //        if (db.HinhAnhs.Count() == 0)
                    //            en.ID = 1;
                    //        else
                    //            en.ID = db.HinhAnhs.Max(item => item.ID) + 1;

                    //        byte[] imageData = new byte[file.ContentLength];
                    //        file.InputStream.Read(imageData, 0, file.ContentLength);

                    //        //MemoryStream ms = new MemoryStream(imageData);
                    //        Image originalImage = byteArrayToImage(imageData);

                    //        if (originalImage.PropertyIdList.Contains(0x0112))
                    //        {
                    //            int rotationValue = originalImage.GetPropertyItem(0x0112).Value[0];
                    //            switch (rotationValue)
                    //            {
                    //                case 1: // landscape, do nothing
                    //                    break;

                    //                case 8: // rotated 90 right
                    //                        // de-rotate:
                    //                    originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
                    //                    break;

                    //                case 3: // bottoms up
                    //                    originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
                    //                    break;

                    //                case 6: // rotated 90 left
                    //                    originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
                    //                    break;
                    //            }
                    //        }
                    //        en.Image = imageToByteArray(resizeImage(originalImage, 2048));
                    //        en.Image_Thumb = imageToByteArray(resizeImage(originalImage, 1024));
                    //        en.CreateDate = DateTime.Now;
                    //        db.HinhAnhs.Add(en);
                    //        db.SaveChanges();
                    //    }
                    //}
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen", hinhAnh.ID_KhachHang);
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen", hinhAnh.ID_KhachHang);
            return View(hinhAnh);
        }

        // POST: HinhAnhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image,ID_KhachHang,CreateDate")] HinhAnh hinhAnh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hinhAnh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen", hinhAnh.ID_KhachHang);
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.HinhAnhs.Remove(hinhAnh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hinhAnh);
        }

        // POST: HinhAnhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            db.HinhAnhs.Remove(hinhAnh);
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

        public ActionResult GetImage(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(ID);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(hinhAnh.Image_Thumb, "image/jpg");
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public Image resizeImage(Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }
}
