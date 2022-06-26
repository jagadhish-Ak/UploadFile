using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uploadimage.Models;

namespace Uploadimage.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            using (DBEntities db = new DBEntities())
            {
                db.Images.Add(imageModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }


        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/Images/" + ImageName;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }
    }
}