using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using PornCantina.Models;
using System.Xml;
using System.Xml.Linq;
using PornCantina.Helpers;

namespace PornCantina.Controllers
{
	public class WebSiteController : Controller
	{
		private PornCantinaContext db = new PornCantinaContext();
		private PornCantinaHelper pornCantinaHelper = new PornCantinaHelper();

		//
		// GET: /WebSite/

		public ViewResult Index()
		{
			return View(db.WebSites.ToList());
		}

		// GET: /Model/
		public ViewResult Manage()
		{
			return View(db.WebSites.ToList().OrderByDescending(w => w.Name).Reverse());
		}

		//
		// GET: /WebSite/Details/5

		public ViewResult Details(Guid id)
		{
			WebSite website = db.WebSites.Find(id);
			return View(website);
		}

		//
		// GET: /WebSite/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /WebSite/Create

		[HttpPost]
		public ActionResult Create(WebSite website)
		{
			if(ModelState.IsValid)
			{
				website.Id = Guid.NewGuid();
				db.WebSites.Add(website);
				db.SaveChanges();
				return RedirectToAction("Manage");
			}

			return View(website);
		}

		//
		// GET: /WebSite/Edit/5

		public ActionResult Edit(Guid id)
		{
			WebSite website = db.WebSites.Find(id);
			return View(website);
		}

		//
		// POST: /WebSite/Edit/5

		[HttpPost]
		public ActionResult Edit(WebSite website)
		{
			if(ModelState.IsValid)
			{
				db.Entry(website).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Manage");
			}
			return View(website);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

		#region Type specific methods

		public Guid GetModelIdByWebSiteId(Guid webSiteId)
		{
			return this.db.Models.Where(m => m.WebSiteId == webSiteId).FirstOrDefault().Id;
		}

		public DateTime GetLastGalleryPublishedDate()
		{
			DateTime date = (from g in db.Galleries
							 orderby g.DatePublished descending
							 select g.DatePublished).FirstOrDefault();

			return date;
		}

		public DateTime GetLastGalleryPublishedDateForSpecifiedModel(Guid modelId)
		{
			DateTime publishedDate = (from g in db.Galleries
									  where g.ModelId == modelId
									  orderby g.DatePublished descending
									  select g.DatePublished).FirstOrDefault();

			return publishedDate;
		}

		public string GetGalleryTitle(string xmlDescription)
		{
			Regex regexObj = new Regex("<a[^>]*? href=\"(?<url>[^\"]+)\"[^>]*?>(?<text>.*?)</a>", RegexOptions.Singleline);

			var match = Regex.Match(xmlDescription, regexObj.ToString());

			// get url within the description
			// match.Groups["url"].Value;

			return match.Groups["text"].Value;
		}

		#endregion
	}
}