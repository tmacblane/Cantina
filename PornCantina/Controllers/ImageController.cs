using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PornCantina.Models;

namespace PornCantina.Controllers
{
	public class ImageController : Controller
	{
		private PornCantinaContext db = new PornCantinaContext();

		//
		// GET: /Thumbnail/

		public ViewResult Index()
		{
			return View(db.Images.ToList());
		}

		//
		// GET: /Thumbnail/Details/5

		public ViewResult Details(Guid id)
		{
			Image image = db.Images.Find(id);
			return View(image);
		}


		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

		//public ActionResult GetImage(Guid imageId)
		//{
		//    byte[] image = null;
		//    Image img = db.Images.Where(i => i.Id == imageId).FirstOrDefault();
		//    image = (byte[])img.Data;
		//    return File(image, img.ContentType);
		//}

	}
}