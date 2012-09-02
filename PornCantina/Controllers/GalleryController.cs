using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PornCantina.Models;
using PornCantina.Helpers;
using PornCantina.ViewModels;

namespace PornCantina.Controllers
{
	public class GalleryController : Controller
	{
		private PornCantinaContext db = new PornCantinaContext();
		private GalleryCreateEditModel galleryCreateEditModel = new GalleryCreateEditModel();

		public ViewResult Index(Guid? modelId, int? page)
		{
			const int pageSize = 20;
			var galleries = GetPagedGalleries((page ?? 1) * pageSize - pageSize, pageSize);

			ViewBag.HasPrevious = galleries.HasPrevious;
			ViewBag.HasMore = galleries.HasNext;
			ViewBag.CurrentPage = (page ?? 1);
			ViewBag.FirstPage = 1;
			ViewBag.LastPage = Math.Round((double)(GetGalleries().Count() / 20), 0, MidpointRounding.AwayFromZero) + 1;

			return View(galleries);
		}

		public ViewResult Manage(int? page)
		{
			return View(db.Galleries.Where(g => g.IsActive == false).OrderBy(g => g.Folder).OrderBy(g => g.ModelId).ToList());
		}

		//
		// GET: /Gallery/Create
		public ActionResult Create()
		{
			return View(this.galleryCreateEditModel);
		}

		// UI Automation Create
		public void CreateGallery(Gallery gallery)
		{
			if(ModelState.IsValid)
			{
				db.Galleries.Add(gallery);
				db.SaveChanges();
			}
		}

		[HttpPost]
		public ActionResult Create(GalleryCreateEditModel galleryCreateEditModel)
		{
			Gallery gallery = new Gallery();

			if(ModelState.IsValid)
			{
				gallery.Id = Guid.NewGuid();
				gallery.Folder = galleryCreateEditModel.Folder;
				gallery.Title = galleryCreateEditModel.Title;
				gallery.ModelId = galleryCreateEditModel.SelectedModel;
				gallery.DatePublished = galleryCreateEditModel.DatePublished;
				gallery.URL = galleryCreateEditModel.URL;
				gallery.IsActive = false;
				db.Galleries.Add(gallery);
				db.SaveChanges();

				// Create Gallery Folder
				string basePath = "Content/Images/" + gallery.GetModelName(gallery.ModelId).Replace(" ", string.Empty);
				DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);
				dInfo.CreateSubdirectory(gallery.Folder.Replace(" ", string.Empty));

				return RedirectToAction("Manage");
			}

			return View(gallery);
		}

		public ActionResult Edit(Guid id)
		{
			GalleryCreateEditModel galleryCreateEditModel = new GalleryCreateEditModel();
			galleryCreateEditModel.Gallery = this.db.Galleries.Find(id);

			var viewModel = new GalleryCreateEditModel
			{
				Gallery = galleryCreateEditModel.Gallery,
				Title = galleryCreateEditModel.Gallery.Title,
				Folder = galleryCreateEditModel.Gallery.Folder,
				DatePublished = galleryCreateEditModel.Gallery.DatePublished,
				URL = galleryCreateEditModel.Gallery.URL,
				IsActive = galleryCreateEditModel.Gallery.IsActive,
				SelectedModel = galleryCreateEditModel.Gallery.ModelId
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(GalleryCreateEditModel galleryCreateEditModel)
		{
			Gallery gallery = this.db.Galleries.Find(galleryCreateEditModel.Gallery.Id);

			if(ModelState.IsValid)
			{
				db.Entry(gallery).State = EntityState.Modified;
				gallery.Title = galleryCreateEditModel.Title;
				gallery.Folder = galleryCreateEditModel.Folder;
				gallery.DatePublished = galleryCreateEditModel.DatePublished;
				gallery.URL = galleryCreateEditModel.URL;
				gallery.IsActive = galleryCreateEditModel.IsActive;
				gallery.ModelId = galleryCreateEditModel.SelectedModel;

				db.SaveChanges();
				return RedirectToAction("Manage");
			}
			else
			{
				var viewModel = new GalleryCreateEditModel
				{
					Gallery = galleryCreateEditModel.Gallery,
					Title = galleryCreateEditModel.Title,
					Folder = galleryCreateEditModel.Folder,
					DatePublished = galleryCreateEditModel.DatePublished,
					URL = galleryCreateEditModel.URL,
					IsActive = galleryCreateEditModel.IsActive,
					SelectedModel = galleryCreateEditModel.Gallery.ModelId
				};

				return View("Edit", viewModel);
			}
		}

		public ActionResult SetToActive(Guid id)
		{
			Gallery gallery = db.Galleries.Find(id);

			db.Entry(gallery).State = EntityState.Modified;
			gallery.IsActive = true;
			db.SaveChanges();

			return RedirectToAction("Manage");
		}

		//
		// GET: /Gallery/Details/5
		public ViewResult Details(Guid id)
		{
			Gallery gallery = db.Galleries.Find(id);
			return View(gallery);
		}

		//
		// GET: /Gallery/Delete/5

		public ActionResult Delete(Guid id)
		{
			Gallery gallery = db.Galleries.Find(id);
			return View(gallery);
		}

		//
		// POST: /Gallery/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(Guid id)
		{
			Gallery gallery = db.Galleries.Find(id);
			db.Galleries.Remove(gallery);
			db.SaveChanges();
			return RedirectToAction("Manage");
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

		public ViewResult Model(string Name, Guid galleryId)
		{
			var gallery = GetThumbnailsForGallery(galleryId);
			return View(gallery);
		}

		public static IEnumerable<PornCantina.Models.Image> GetThumbnailsForGallery(Guid galleryId)
		{
			using(var context = new PornCantinaContext())
			{
				var query = (from i in context.Images
							 where i.GalleryId == galleryId
							 orderby i.ThumbnailFileName ascending
							 select i).ToList();

				return query;
			}
		}

		public static PagedList<Gallery> GetPagedGalleries(int skip, int take)
		{
			using(var context = new PornCantinaContext())
			{
				var query = (from g in context.Galleries
							 where g.IsActive == true
							 orderby g.DatePublished descending
							 select g).ToList();

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

		public static List<Gallery> GetGalleries()
		{
			using(var context = new PornCantinaContext())
			{
				var query = (from g in context.Galleries
							 where g.IsActive == true
							 orderby g.DatePublished descending
							 select g).ToList();

				return query;
			}
		}

		public ActionResult PopulateGalleryImages(string modelName, string folderName)
		{
			string basePath = string.Format(@"Content/Images/{0}/{1}", modelName.Replace(" ", string.Empty), folderName);
			DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);

			Guid modelId = db.Models.Where(m => m.Name.Replace(" ", string.Empty) == modelName.Replace(" ", string.Empty)).FirstOrDefault().Id;

			var existingGallery = (from g in db.Galleries
								   where g.Folder == folderName && g.ModelId == modelId
								   select g).FirstOrDefault();

			if(existingGallery != null && existingGallery.IsActive == false)
			{
				Guid galleryId = existingGallery.Id;

				// iterate through each file and add an Image record to the database
				foreach(var file in dInfo.GetFiles())
				{
					if(!file.Name.Contains("tn_"))
					{
						if(file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".jpeg" || file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".gif")
						{
							var existingImage = db.Images.Where(i => i.GalleryId == galleryId && i.FileName == file.Name);

							if(existingImage.FirstOrDefault() == null)
							{
								db.Images.Add(new PornCantina.Models.Image
								{
									Id = Guid.NewGuid(),
									FileName = file.Name,
									FilePath = basePath,
									ThumbnailFileName = "tn_" + file.Name,
									GalleryId = galleryId,
								});

								db.SaveChanges();
							}
						}
					}
				}
			}

			return RedirectToAction("Manage");
		}

		public ActionResult RenameAndCreateThumbnails(string modelName, string folderName)
		{
			string basePath = string.Format("Content/Images/{0}/{1}", modelName.Replace(" ", string.Empty), folderName);
			DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);

			int i = 1;

			// iterate through each file and rename and create thumbnails
			foreach(var file in dInfo.GetFiles())
			{
				string filename = string.Empty;

				if(i <= 9)
				{
					filename = string.Format("0{0}", i);
				}
				else
				{
					filename = string.Format("{0}", i);
				}

				if(file.Name != string.Format("{0}{1}", filename, file.Extension.ToLower()))
				{
					file.CopyTo(string.Format(@"{0}/{1}{2}", dInfo, filename, file.Extension.ToLower()), true);
				}

				// Create Thumbnail
				Bitmap bitmap = new Bitmap(file.FullName);

				System.Drawing.Image thumbnailImage = this.ResizeImage(bitmap, new Size(180, 240));

				this.SaveJpegThumbnail(string.Format(@"{0}/tn_{1}{2}", dInfo, filename, ".jpg"), (Bitmap)thumbnailImage, 100);

				if(file.Name != string.Format("{0}{1}", filename, file.Extension.ToLower()))
				{
					file.Delete();
				}

				i++;
			}

			return RedirectToAction("Manage");
		}

		public System.Drawing.Image ResizeImage(System.Drawing.Image imageToResize, Size size)
		{
			int sourceWidth = imageToResize.Width;
			int sourceHeight = imageToResize.Height;

			float percent = 0;
			float percentW = 0;
			float percentH = 0;

			percentW = (float)size.Width / (float)sourceWidth;
			percentH = (float)size.Height / (float)sourceHeight;

			if(percentH < percentW)
			{
				percent = percentW;
			}
			else
			{
				percent = percentH;
			}

			RectangleF destinationRect = new RectangleF(0, 0, size.Width, size.Height);

			int destWidth = (int)(sourceWidth * percent);
			int destHeight = (int)(sourceHeight * percent);

			System.Drawing.Image image = new Bitmap(size.Width, size.Height);

			Graphics graphics = Graphics.FromImage(image);
			graphics.DrawImage(image, 0, 0);

			RectangleF sourceRect = new RectangleF(0, 0, percentW, percentH);

			graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

			graphics.DrawImage(imageToResize, 0, 0, destWidth, destHeight);
			imageToResize.Dispose();
			graphics.Dispose();

			return image;
		}

		private void SaveJpegThumbnail(string path, Bitmap img, long quality)
		{
			// Encoder parameter for image quality
			EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

			// Jpeg image codec
			ImageCodecInfo jpegCodec = this.GetEncoderInfo("image/jpeg");

			if(jpegCodec == null)
			{
				return;
			}

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;

			MemoryStream memoryStream = new MemoryStream();
			FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);

			img.Save(memoryStream, jpegCodec, encoderParams);
			byte[] matrix = memoryStream.ToArray();
			fileStream.Write(matrix, 0, matrix.Length);

			memoryStream.Close();
			fileStream.Close();
		}

		private ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			// Get image codecs for all image formats
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

			// Find the correct image codec
			for(int i = 0; i < codecs.Length; i++)
			{
				if(codecs[i].MimeType == mimeType)
				{
					return codecs[i];
				}
			}

			return null;
		}

		public void PopulateGalleryImage()
		{
			string basePath = @"Content/Images";
			DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);

			using(var context = new PornCantinaContext())
			{
				// iterate through each model folder
				foreach(var modelRootFolder in dInfo.GetDirectories())
				{
					// iterate through each gallery folder
					foreach(var galleryFolder in modelRootFolder.GetDirectories())
					{
						this.PopulateGalleryImages(modelRootFolder.Name, galleryFolder.Name);
					}
				}
			}
		}
	}
}