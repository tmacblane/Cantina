using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace PornCantina.Models
{
	public class Image
	{
		private PornCantinaContext db = new PornCantinaContext();

		#region Type specific properties

		[Key]
		public Guid Id
		{
			get;
			set;
		}

		public string FilePath
		{
			get;
			set;
		}

		public string FileName
		{
			get;
			set;
		}

		public string ThumbnailFileName
		{
			get;
			set;
		}

		public Guid GalleryId
		{
			get;
			set;
		}

		#endregion


		public string GetThumbnailImage(Guid imageId)
		{
			string thumbnailImage = string.Empty;
			var image = this.db.Images.Where(i => i.Id == imageId).FirstOrDefault();

			if(image != null)
			{
				thumbnailImage = image.FilePath + "\\" + image.ThumbnailFileName;
			}

			return thumbnailImage;
		}

		public string GetEnlargedImage(Guid imageId)
		{
			string imagePath = string.Empty;
			var image = this.db.Images.Where(i => i.Id == imageId).FirstOrDefault();

			if(image != null)
			{
				imagePath = image.FilePath + "\\" + image.FileName;
			}

			return imagePath;
		}

		public Guid GetModelId(Guid galleryId)
		{
			return this.db.Galleries.Where(g => g.Id == galleryId).FirstOrDefault().ModelId;
		}

		public string GetModelName(Guid galleryId)
		{
			var modelId = this.db.Galleries.Where(g => g.Id == galleryId).FirstOrDefault().ModelId;

			return this.db.Models.Where(m => m.Id == modelId).FirstOrDefault().Name;
		}

		public string GetGalleryName(Guid galleryId)
		{
			return this.db.Galleries.Where(g => g.Id == galleryId).FirstOrDefault().Title;
		}

		public string GetModelPaySiteURL(Guid galleryId)
		{
			var modelId = this.db.Galleries.Where(g => g.Id == galleryId).FirstOrDefault().ModelId;
			var webSiteId = this.db.Models.Where(m => m.Id == modelId).FirstOrDefault().WebSiteId;

			return this.db.WebSites.Where(w => w.Id == webSiteId).FirstOrDefault().ReferralLink;
		}

		public string GetModelGalleryURL(Guid galleryId)
		{
			return this.db.Galleries.Where(g => g.Id == galleryId).FirstOrDefault().URL;
		}

		// search images folder
		// foreach model folder in the images folder
		// open the model folder and get the model id (need query based off of name)
		// foreach gallery folder in model folder
		// if gallery folder path exists in DB already, skip
		// else open gallery folder
		// foreach image in gallery folder
		// insert image into db
		// if image begins with "tn" or something to denote it's a thumbnail, set isThumbnail == true
		// if no thumbnails exists, create thumbnails out of each image, rename to tn_xxx and set isThumbnail == true
	}
}