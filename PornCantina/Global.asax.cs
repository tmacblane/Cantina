using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using PornCantina.Models;

namespace PornCantina
{
	public class MvcApplication : System.Web.HttpApplication
	{
		#region Type specific methods

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new
				{
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				} // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			//Database.SetInitializer(new PornCantinaContextInitializer());

			//using(var context = new CIAutomationContext())
			//{
			//    context.Database.Initialize(force: true);
			//}

			// WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		#endregion
	}
}