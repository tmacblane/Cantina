using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace PornCantina.Models
{
	public class Model
	{
		#region Fields

		private PornCantinaContext db = new PornCantinaContext();
		WebSite webSite = new WebSite();
		private List<SelectListItem> _webSites = new List<SelectListItem>();

		#endregion

		#region Constructors

		public Model()
		{
			this.Galleries = new List<Gallery>();
		}

		#endregion

		#region Type specific properties

		[Key]
		public Guid Id
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}

		public Guid WebSiteId
		{
			get;
			set;
		}

		[ForeignKey("WebSiteId")]
		public virtual WebSite WebSite
		{
			get;
			set;
		}

		public virtual ICollection<Gallery> Galleries
		{
			get;
			set;
		}

		#endregion

		#region Type specific methods

		public IEnumerable<WebSite> GetWebSitesList()
		{
			return db.WebSites;
		}

		public List<SelectListItem> GetWebSiteList()
		{
			foreach(WebSite webSite in this.GetWebSitesList())
			{
				_webSites.Add(new SelectListItem()
				{
					Text = webSite.Name,
					Value = webSite.Id.ToString()
				});
			}

			return _webSites;
		}

		public string GetWebSiteByModel(Model model)
		{
			using(var context = new PornCantinaContext())
			{
				var webSite = context.WebSites.Where(w => w.Id == model.WebSiteId);

				return webSite.FirstOrDefault().Name;
			}
		}

		public string GetWebSiteReferralLink(Model model)
		{
			using(var context = new PornCantinaContext())
			{
				var webSite = context.WebSites.Where(w => w.Id == model.WebSiteId);

				return webSite.FirstOrDefault().ReferralLink;
			}
		}

		public int GetActiveGalleryCountByModel(Guid modelId)
		{
			int count = 0;

			using(var context = new PornCantinaContext())
			{
				if(context.Galleries.Where(g => g.ModelId == modelId && g.IsActive == true) != null)
				{
					count = context.Galleries.Where(g => g.ModelId == modelId && g.IsActive == true).Count();
				}
			}

			return count;
		}

		public int GetInactiveGalleryCountByModel(Guid modelId)
		{
			int count = 0;

			using(var context = new PornCantinaContext())
			{
				if(context.Galleries.Where(g => g.ModelId == modelId && g.IsActive == false) != null)
				{
					count = context.Galleries.Where(g => g.ModelId == modelId && g.IsActive == false).Count();
				}
			}

			return count;
		}

		#endregion
	}
}