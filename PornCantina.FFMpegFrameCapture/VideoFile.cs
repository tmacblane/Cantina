using System;
using System.IO;

public class VideoFile
{
	#region Fields

	private string _Path;

	#endregion

	#region Constructors

	public VideoFile(string path)
	{
		_Path = path;
		Initialize();
	}

	#endregion

	#region Type specific properties

	public string Path
	{
		get
		{
			return this._Path;
		}
		set
		{
			this._Path = value;
		}
	}

	public TimeSpan Duration
	{
		get;
		set;
	}

	public double BitRate
	{
		get;
		set;
	}

	public string AudioFormat
	{
		get;
		set;
	}

	public string VideoFormat
	{
		get;
		set;
	}

	public int Height
	{
		get;
		set;
	}

	public int Width
	{
		get;
		set;
	}

	public string RawInfo
	{
		get;
		set;
	}

	public bool infoGathered
	{
		get;
		set;
	}

	#endregion

	#region Initialization

	private void Initialize()
	{
		this.infoGathered = false;
		//first make sure we have a value for the video file setting
		if(string.IsNullOrEmpty(_Path))
		{
			throw new Exception("Could not find the location of the video file");
		}

		//Now see if the video file exists
		if(!File.Exists(_Path))
		{
			throw new Exception("The video file " + _Path + " does not exist.");
		}
	}

	#endregion
}

public class OutputPackage
{
	#region Type specific properties

	public MemoryStream VideoStream
	{
		get;
		set;
	}

	public System.Drawing.Image PreviewImage
	{
		get;
		set;
	}

	public string RawOutput
	{
		get;
		set;
	}

	public bool Success
	{
		get;
		set;
	}

	#endregion
}