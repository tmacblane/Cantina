using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PornCantina.Models;

namespace PornCantina.Controllers
{
	public class AdminController : Controller
	{
		private PornCantinaContext db = new PornCantinaContext();

		// GET: /Admin/
		public ActionResult Index()
		{
			return View();
		}
	}
}
