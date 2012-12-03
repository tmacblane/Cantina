using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace PornCantina.FFMpegFrameCapture
{
	public class FrameCapture
	{
		#region Fields
		
		private string _ffExe;
		private string _WorkingPath;

		#endregion

		#region Constructors

		public FrameCapture()
		{
			Initialize();
		}

		public FrameCapture(string ffmpegExePath)
		{
			_ffExe = ffmpegExePath;
			Initialize();
		}

		#endregion

		#region Type specific properties

		public string ffExe
		{
			get
			{
				return _ffExe;
			}
			set
			{
				_ffExe = value;
			}
		}

		public string WorkingPath
		{
			get
			{
				return _WorkingPath;
			}
			set
			{
				_WorkingPath = value;
			}
		}

		#endregion

		#region Initialization

		private void Initialize()
		{
			//first make sure we have a value for the ffexe file setting
			if(string.IsNullOrEmpty(_ffExe))
			{
				object o = ConfigurationManager.AppSettings["ffmpeg:ExeLocation"];
				if(o == null)
				{
					throw new Exception("Could not find the location of the ffmpeg exe file.  The path for ffmpeg.exe " +
					"can be passed in via a constructor of the ffmpeg class (this class) or by setting in the app.config or web.config file.  " +
					"in the appsettings section, the correct property name is: ffmpeg:ExeLocation");
				}
				else
				{
					if(string.IsNullOrEmpty(o.ToString()))
					{
						throw new Exception("No value was found in the app setting for ffmpeg:ExeLocation");
					}
					_ffExe = o.ToString();
				}
			}

			//Now see if ffmpeg.exe exists
			string workingpath = GetWorkingFile();
			if(string.IsNullOrEmpty(workingpath))
			{
				//ffmpeg doesn't exist at the location stated.
				throw new Exception("Could not find a copy of ffmpeg.exe");
			}
			_ffExe = workingpath;

			//now see if we have a temporary place to work
			if(string.IsNullOrEmpty(_WorkingPath))
			{
				object o = ConfigurationManager.AppSettings["ffmpeg:WorkingPath"];
				if(o != null)
				{
					_WorkingPath = o.ToString();
				}
				else
				{
					_WorkingPath = string.Empty;
				}
			}
		}

		private string GetWorkingFile()
		{
			//try the stated directory
			if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + _ffExe))
			{
				return AppDomain.CurrentDomain.BaseDirectory + _ffExe;
			}

			//oops, that didn't work, try the base directory
			if(File.Exists(Path.GetFileName(AppDomain.CurrentDomain.BaseDirectory + _ffExe)))
			{
				return Path.GetFileName(AppDomain.CurrentDomain.BaseDirectory + _ffExe);
			}

			//well, now we are really unlucky, let's just return null
			return null;
		}

		#endregion

		#region Run the process

		private string RunProcess(string parameters)
		{
			//create a process info
			ProcessStartInfo oInfo = new ProcessStartInfo(this._ffExe, parameters);
			oInfo.UseShellExecute = false;
			oInfo.CreateNoWindow = true;
			oInfo.RedirectStandardOutput = true;
			oInfo.RedirectStandardError = true;

			//Create the output and streamreader to get the output
			string output = null;
			StreamReader srOutput = null;

			//try the process
			try
			{
				//run the process
				Process proc = System.Diagnostics.Process.Start(oInfo);

				proc.WaitForExit(10000);

				//get the output
				srOutput = proc.StandardError;

				//now put it in a string
				output = srOutput.ReadToEnd();

				proc.Close();
			}
			catch(Exception)
			{
				output = string.Empty;
			}
			finally
			{
				//now, if we succeded, close out the streamreader
				if(srOutput != null)
				{
					srOutput.Close();
					srOutput.Dispose();
				}
			}

			return output;
		}

		private void RunProcessNoOutput(string parameters)
		{
			//create a process info
			ProcessStartInfo oInfo = new ProcessStartInfo(this._ffExe, parameters);
			oInfo.UseShellExecute = false;
			oInfo.CreateNoWindow = true;
			oInfo.RedirectStandardOutput = true;
			oInfo.RedirectStandardError = true;

			//try the process
			Process proc = System.Diagnostics.Process.Start(oInfo);
		}

		#endregion

		#region GetVideoInfo

		public VideoFile GetVideoInfo(MemoryStream inputFile, string Filename)
		{
			string tempfile = Path.Combine(this.WorkingPath, System.Guid.NewGuid().ToString() + Path.GetExtension(Filename));
			FileStream fs = File.Create(tempfile);
			inputFile.WriteTo(fs);
			fs.Flush();
			fs.Close();
			GC.Collect();

			VideoFile vf = null;
			try
			{
				vf = new VideoFile(tempfile);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			GetVideoInfo(vf);

			try
			{
				File.Delete(tempfile);
			}
			catch(Exception)
			{

			}

			return vf;
		}

		public VideoFile GetVideoInfo(string inputPath)
		{
			VideoFile vf = null;
			try
			{
				vf = new VideoFile(inputPath);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			GetVideoInfo(vf);
			return vf;
		}

		public void GetVideoInfo(VideoFile input)
		{
			//set up the parameters for video info
			string Params = string.Format("-i {0}", input.Path);
			string output = RunProcess(Params);
			input.RawInfo = output;

			//get duration
			Regex re = new Regex("[D|d]uration:.((\\d|:|\\.)*)");
			Match m = re.Match(input.RawInfo);

			if(m.Success)
			{
				string duration = m.Groups[1].Value;
				string[] timepieces = duration.Split(new char[] { ':', '.' });
				if(timepieces.Length == 4)
				{
					input.Duration = new TimeSpan(0, Convert.ToInt16(timepieces[0]), Convert.ToInt16(timepieces[1]), Convert.ToInt16(timepieces[2]), Convert.ToInt16(timepieces[3]));
				}
			}

			//get audio bit rate
			re = new Regex("[B|b]itrate:.((\\d|:)*)");
			m = re.Match(input.RawInfo);
			double kb = 0.0;
			if(m.Success)
			{
				Double.TryParse(m.Groups[1].Value, out kb);
			}
			input.BitRate = kb;

			//get the audio format
			re = new Regex("[A|a]udio:.*");
			m = re.Match(input.RawInfo);
			if(m.Success)
			{
				input.AudioFormat = m.Value;
			}

			//get the video format
			re = new Regex("[V|v]ideo:.*");
			m = re.Match(input.RawInfo);
			if(m.Success)
			{
				input.VideoFormat = m.Value;
			}

			//get the video format
			re = new Regex("(\\d{2,3})x(\\d{2,3})");
			m = re.Match(input.RawInfo);
			if(m.Success)
			{
				int width = 0;
				int height = 0;
				int.TryParse(m.Groups[1].Value, out width);
				int.TryParse(m.Groups[2].Value, out height);
				input.Width = width;
				input.Height = height;
			}

			input.infoGathered = true;
		}

		#endregion

		#region CreateVideoThumbnails

		public void CreateVideoThumbnails(MemoryStream inputFile, string Filename)
		{
			string tempfile = Path.Combine(this.WorkingPath, System.Guid.NewGuid().ToString() + Path.GetExtension(Filename));
			FileStream fs = File.Create(tempfile);
			inputFile.WriteTo(fs);
			fs.Flush();
			fs.Close();
			GC.Collect();

			VideoFile vf = null;
			try
			{
				vf = new VideoFile(tempfile);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			this.CreateVideoThumbnails(vf);
		}

		public void CreateVideoThumbnails(string inputPath)
		{
			VideoFile vf = null;
			try
			{
				vf = new VideoFile(inputPath);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			this.CreateVideoThumbnails(vf);
		}

		public void CreateVideoThumbnails(VideoFile input)
		{
			if(!input.infoGathered)
			{
				GetVideoInfo(input);
			}
			OutputPackage ou = new OutputPackage();

			//set up the parameters for getting a previewimage
			string filename;
			string finalpath;
			string Params;
			int secs;
			double[] previewPercentages = new double[] { .05, .15, .25, .35, .45, .55, .65, .75, .85, .95 };

			foreach(double previewPercentage in previewPercentages)
			{
				secs = (int)Math.Round(TimeSpan.FromTicks((long)(input.Duration.Ticks * previewPercentage)).TotalSeconds, 0);

				filename = string.Format("{0}.jpg", secs.ToString());
				finalpath = Path.Combine(this.WorkingPath, filename);
				Params = string.Format("-i {0} -ss {1} -vcodec mjpeg -vframes 1 -an {2} -f rawvideo", input.Path, secs, finalpath);

				this.RunProcess(Params);
			}
		}

		#endregion
	}
}