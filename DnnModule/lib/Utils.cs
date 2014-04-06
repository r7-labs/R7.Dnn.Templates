//
// Utils.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2014 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DotNetNuke.UI.Modules;
using DotNetNuke.Common;

namespace DnnModule
{
	/// <summary>
	/// Message severities
	/// </summary>
	public enum MessageSeverity
	{
		Info,
		Warning,
		Error
	}

	public class Utils
	{
		/// <summary>
		/// Determines if the specified file is an images.
		/// </summary>
		/// <returns></returns>
		/// <param name="fileName">File name.</param>
		public static bool IsImage (string fileName)
		{
			if (!string.IsNullOrWhiteSpace (fileName))
				return Globals.glbImageFileTypes.Contains (
					Path.GetExtension (fileName).Substring (1).ToLowerInvariant ());
			else
				return false;
		}

		/// <summary>
		/// Formats the URL by DNN rules.
		/// </summary>
		/// <returns>Formatted URL.</returns>
		/// <param name="module">A module reference.</param>
		/// <param name="link">A link value. May be TabID, FileID=something or in other valid forms.</param>
		/// <param name="trackClicks">If set to <c>true</c> then track clicks.</param>
		public static string FormatURL (IModuleControl module, string link, bool trackClicks)
		{
			return DotNetNuke.Common.Globals.LinkClick 
				(link, module.ModuleContext.TabId, module.ModuleContext.ModuleId, trackClicks);
		}

		/// <summary>
		/// Formats the Edit control URL by DNN rules (popups supported).
		/// </summary>
		/// <returns>Formatted Edit control URL.</returns>
		/// <param name="module">A module reference.</param>
		/// <param name="controlKey">Edit control key.</param>
		/// <param name="args">Additional parameters.</param>
		public static string EditUrl (IModuleControl module, string controlKey, params string[] args)
		{
			var argList = new List<string> (args); 
			argList.Add ("mid");
			argList.Add (module.ModuleContext.ModuleId.ToString ());

			return module.ModuleContext.NavigateUrl (module.ModuleContext.TabId, controlKey, false, argList.ToArray ());
		}

		/// <summary>
		/// Finds the item index by it's value in ListControl-type list.
		/// </summary>
		/// <returns>Item index.</returns>
		/// <param name="list">List control.</param>
		/// <param name="value">A value.</param>
		/// <param name="defaultIndex">Default index (in case item not found).</param>
		public static int FindIndexByValue (ListControl list, object value, int defaultIndex)
		{ 
			var index = 0;
			var strvalue = value.ToString ();
			foreach (ListItem item in list.Items)
			{
				if (item.Value == strvalue) return index;
				index++;
			}
			return defaultIndex; 
		}

		/// <summary>
		/// Sets the selected index of ListControl-type list.
		/// </summary>
		/// <param name="list">List control.</param>
		/// <param name="value">A value.</param>
		/// <param name="defaultIndex">Default index (in case item not found).</param>
		public static void SetIndexByValue (ListControl list, object value, int defaultIndex)
		{
			list.SelectedIndex = FindIndexByValue (list, value, defaultIndex);
		}

		/// <summary>
		/// Display a message at the top of the specified module.
		/// </summary>
		/// <param name="module">Module reference.</param>
		/// <param name="severity">Message severity level.</param>
		/// <param name="message">Message text.</param>
		public static void Message (IModuleControl module, MessageSeverity severity, string message)
		{
			var label = new Label ();
			label.CssClass = "dnnFormMessage dnnForm" + severity;
			label.Text = message;

			module.Control.Controls.AddAt (0, label);
		}
	}
	// class
}
 // namespace

