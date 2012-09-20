using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PornCantina.Models
{
	public class WebSite
	{
		#region Fields

		private PornCantinaContext db = new PornCantinaContext();

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

		[Display(Name = "Referral Link")]
		public string ReferralLink
		{
			get;
			set;
		}

		[Display(Name="WebMaster Content Page")]
		public string WebmasterContentPage
		{
			get;
			set;
		}

		#endregion
	}
}