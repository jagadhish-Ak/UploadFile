using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uploadimage.Models;
namespace Uploadimage.Controllers
{
    public class HomeController : Controller
    {
        DBEntities db = new DBEntities();   
        public ActionResult List()
        {
            return View(db.Images.ToList());
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Image imageModel = new Image();

            using (DBEntities db = new DBEntities())
            {
                imageModel = db.Images.Where(x => x.ImageId == id).FirstOrDefault();
            }

            return View(imageModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}