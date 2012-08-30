using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PornCantina.Helpers
{
	public class PornCantinaHelper
	{
		public string GetModifiedDateTime(string originalDateTime)
		{
			string modifiedDateTime = DateTime.Now.ToString();

			Dictionary<string, string> timeZoneDictionary = new Dictionary<string, string>()
            {
                { "CDT", "-0500" },
                { "CST", "-0600" },
                { "EDT", "-0400" },
                { "EST", "-0500" },
                { "MDT", "-0600" },
                { "MST", "-0700" },
                { "PDT", "-0700" },
                { "PST", "-0800" },
            };

			foreach(KeyValuePair<string, string> timezone in timeZoneDictionary)
			{
				if(originalDateTime.Contains(timezone.Key))
				{
					modifiedDateTime = originalDateTime.Replace(timezone.Key, timezone.Value);
				}
			}

			return modifiedDateTime;
		}
	}
}