using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace PornCantina.Models
{
	public class Gallery
	{
		#region Fields

		private PornCantinaContext db = new PornCantinaContext();
		Model model = new Model();
		private List<SelectListItem> _models = new List<SelectListItem>();

		#endregion

		#region Constructors

		public Gallery()
		{
			this.Images = new List<Image>();
		}

		#endregion

		#region Type specific properties

		[Key]
		public Guid Id
		{
			get;
			set;
		}

		public Guid ModelId
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string Folder
		{
			get;
			set;
		}

		public DateTime DatePublished
		{
			get;
			set;
		}

		public string URL
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public virtual ICollection<Image> Images
		{
			get;
			set;
		}

		[ForeignKey("ModelId")]
		public virtual Model Model
		{
			get;
			set;
		}

		#endregion

		#region Type specific methods

		public IEnumerable<Model> GetModelsList()
		{
			return db.Models.OrderBy(m => m.Name);
		}

		public List<SelectListItem> GetModelList()
		{
			foreach(Model model in this.GetModelsList())
			{
				_models.Add(new SelectListItem()
				{
					Text = model.Name,
					Value = model.Id.ToString()
				});
			}

			return _models;
		}

		public string GetModelName(Guid modelId)
		{
			return this.db.Models.Where(m => m.Id == modelId).FirstOrDefault().Name;
		}

		public string GetModelPaySiteURL(Guid modelId)
		{
			var webSiteId = this.db.Models.Where(m => m.Id == modelId).FirstOrDefault().WebSiteId;

			return this.db.WebSites.Where(w => w.Id == webSiteId).FirstOrDefault().ReferralLink;
		}

		public Guid GetModelId(string modelName)
		{
			return this.db.Models.Where(m => m.Name == modelName).FirstOrDefault().Id;
		}

		public string GetThumbnailImage(Guid galleryId)
		{
			string thumbnailImage = string.Empty;
			var image = this.db.Images.Where(i => i.GalleryId == galleryId && i.FileName.Contains("01")).FirstOrDefault();

			if(image != null)
			{
				thumbnailImage = "/" + image.FilePath + "/" + image.ThumbnailFileName;
			}

			return thumbnailImage;
		}

		public int GetGalleryFolderImagesCount(string modelName, string folderName)
		{
			string basePath = string.Format(@"Content/Images/{0}/{1}", modelName.Replace(" ", string.Empty), folderName);
			DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + basePath);

			if(dInfo.Exists == false)
			{
				dInfo.Create();
			}

			return dInfo.GetFiles().Count();
		}

		public IEnumerable<Gallery> GetGalleriesByModel(string modelName)
		{
			model = this.db.Models.Where(m => m.Name == modelName).FirstOrDefault();

			return this.db.Galleries.Where(g => g.ModelId == model.Id);
		}

		#endregion
	}
}