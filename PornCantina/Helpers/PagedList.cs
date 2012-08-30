using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PornCantina.Helpers
{
	public class PagedList<T>
	{
		#region Type specific properties

		public bool HasNext
		{
			get;
			set;
		}

		public bool HasPrevious
		{
			get;
			set;
		}

		public List<T> Entities
		{
			get;
			set;
		}

		#endregion
	}
}