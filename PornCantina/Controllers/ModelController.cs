using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PornCantina.Models;
using PornCantina.ViewModels;
using PornCantina.Helpers;

namespace PornCantina.Controllers
{
	public class ModelController : Controller
	{
		private PornCantinaContext db = new PornCantinaContext();
		private ModelCreateEditViewModel modelCreateEditViewModel = new ModelCreateEditViewModel();

		public ViewResult Index(Guid modelId, int? page)
		{
			const int pageSize = 20;
			var galleries = GetModelGalleries(modelId, (page ?? 1) * pageSize - pageSize, pageSize);

			ViewBag.HasPrevious = galleries.HasPrevious;
			ViewBag.HasMore = galleries.HasNext;
			ViewBag.CurrentPage = (page ?? 1);
			ViewBag.FirstPage = 1;
			ViewBag.LastPage = Math.Round((double)(GetModelGalleries(modelId).Count()/20), 0, MidpointRounding.AwayFromZero) + 1;
			ViewBag.ModelId = modelId;

			return View("Index", galleries);
		}

		public static PagedList<Gallery> GetModelGalleries(Guid modelId, int skip, int take)
		{
			using(var context = new PornCantinaContext())
			{
				var query = GetModelGalleries(modelId);

				var galleryCount = query.Count();

				var galleries = query.Skip(skip).Take(take).ToList();

				return new PagedList<Gallery>
				{
					Entities = galleries,
					HasNext = (skip + 20 < galleryCount),
					HasPrevious = (skip > 0)
				};
			}
		}

		public static List<Gallery> GetModelGalleries(Guid modelId)
		{
			using(var context = new PornCantinaContext())
			{
				var query = (from g in context.Galleries
							 where g.IsActive == true && g.ModelId == modelId
							 orderby g.DatePublished descending
							 select g).ToList();

				return query;
			}
		}

		public static IEnumerable<Image> GetThumbnailsForModelGalleries(Guid modelId)
		{
			using(var context = new PornCantinaContext())
			{
				var query = (from i in context.Images
							 join g in context.Galleries on i.GalleryId equals g.Id
							 where g.ModelId == modelId
							 orderby i.ThumbnailFileName ascending
							 select i).ToList();

				return query;
			}
		}

		// GET: /Model/
		public ViewResult Manage()
		{
			return View(db.Models.ToList().OrderBy(m => m.Name));
		}

		// GET: /Model/Details/5
		public ViewResult Details(Guid id)
		{
			Model model = db.Models.Find(id);
			return View(model);
		}

		//
		// GET: /Model/Create

		public ActionResult Create()
		{
			return View(this.modelCreateEditViewModel);
		}

		//
		// POST: /Model/Create

		[HttpPost]
		public ActionResult Create(ModelCreateEditViewModel modelCreateEditViewModel)
		{
			Model model = new Model();

			if(ModelState.IsValid)
			{
				model.Id = Guid.NewGuid();
				model.WebSiteId = modelCreateEditViewModel.SelectedWebSite;
				model.Name = modelCreateEditViewModel.Name;
				db.Models.Add(model);
				db.SaveChanges();

				// Create Model Folder
				string basePath = @"Content\Images";
				DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);
				dInfo.CreateSubdirectory(model.Name.Replace(" ", string.Empty));

				return RedirectToAction("Manage");
			}

			return View(model);
		}

		//
		// GET: /Model/Edit/5

		public ActionResult Edit(Guid id)
		{
			ModelCreateEditViewModel modelCreateEditViewModel = new ModelCreateEditViewModel();
			modelCreateEditViewModel.Model = this.db.Models.Find(id);

			var viewModel = new ModelCreateEditViewModel
			{
				Model = modelCreateEditViewModel.Model,
				Name = modelCreateEditViewModel.Model.Name,
				SelectedWebSite = modelCreateEditViewModel.Model.WebSiteId
			};

			return View(viewModel);
		}

		//
		// POST: /Model/Edit/5

		[HttpPost]
		public ActionResult Edit(ModelCreateEditViewModel modelCreateEditViewModel)
		{
			Model model = this.db.Models.Find(modelCreateEditViewModel.Model.Id);

			if(ModelState.IsValid)
			{
				db.Entry(model).State = EntityState.Modified;
				model.Name = modelCreateEditViewModel.Name;
				model.WebSiteId = modelCreateEditViewModel.SelectedWebSite;

				db.SaveChanges();
				return RedirectToAction("Manage");
			}
			else
			{
				var viewModel = new ModelCreateEditViewModel
				{
					Model = modelCreateEditViewModel.Model,
					Name = modelCreateEditViewModel.Model.Name,
					SelectedWebSite = modelCreateEditViewModel.Model.WebSiteId,
				};

				return View("Edit", viewModel);
			}
		}

		//
		// GET: /Model/Delete/5

		public ActionResult Delete(Guid id)
		{
			Model model = db.Models.Find(id);
			return View(model);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}