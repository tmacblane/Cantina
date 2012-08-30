using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PornCantina.Models;

namespace PornCantina.ViewModels
{
	public class GalleryCreateEditModel
	{
		#region Fields

		private Gallery gallery = new Gallery();

		#endregion

		#region Type specific properties

		public Gallery Gallery
		{
			get;
			set;
		}

		[Required]
		public string Title
		{
			get;
			set;
		}

		[Required]
		public string Folder
		{
			get;
			set;
		}

		[Required]
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

		[Required(ErrorMessage = "Please select a model")]
		public Guid SelectedModel
		{
			get;
			set;
		}

		[Required]
		public List<SelectListItem> Models
		{
			get
			{
				return gallery.GetModelList();
			}
		}

		#endregion
	}
}