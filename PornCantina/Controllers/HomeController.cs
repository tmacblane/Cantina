using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ffMpeg;
using PornCantina.FFMpegFrameCapture;

namespace PornCantina.Controllers
{
	public class HomeController : Controller
	{
		Converter Converter;
		FrameCapture FrameCapture;

		public ActionResult Index()
		{
			ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult CreateVideoThumbnails()
		{
			var videoLocation = @"C:\Temp\catie_minx_bedroom_floor_hitachi.mp4";

			this.FrameCapture = new FrameCapture();
			this.FrameCapture.CreateVideoThumbnails(videoLocation);

			return View("Index");
		}

		public ActionResult ConvertVideo()
		{
			var videoLocation = @"C:\Temp\catie_minx_bedroom_floor_hitachi.mp4";
			this.Converter = new Converter();
			ffMpeg.OutputPackage outputPackage = this.Converter.ConvertToFLV(videoLocation);

			FileStream outStream = System.IO.File.OpenWrite("newVideo.flv");
			outputPackage.VideoStream.WriteTo(outStream);
			outStream.Flush();
			outStream.Close();
			outputPackage.PreviewImage.Save(@"C:\Temp\preview001.jpg");

			return View();
		}
	}
}
