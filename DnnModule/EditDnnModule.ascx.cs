//
// EditDnnModule.ascx.cs
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
using System.Web.UI.WebControls;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.UserControls;

namespace DnnModule
{
	public partial class EditDnnModule : PortalModuleBase
	{
		// ALT: private int itemId = Null.NullInteger;
		private int? itemId = null;

		#region Handlers

		/// <summary>
		/// Handles Init event for a control.
		/// </summary>
		/// <param name="e">Event args.</param>
		protected override void OnInit (EventArgs e)
		{
			base.OnInit (e);

			// set url for Cancel link
			linkCancel.NavigateUrl = Globals.NavigateURL ();

			// wireup event handlers
			buttonUpdate.Click += buttonUpdate_Click;
			buttonDelete.Click += buttonDelete_Click;

			// add confirmation dialog to delete button
			buttonDelete.Attributes.Add ("onClick", "javascript:return confirm('" + Localization.GetString ("DeleteItem") + "');");
		}

		/// <summary>
		/// Handles Load event for a control.
		/// </summary>
		/// <param name="e">Event args.</param>
		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);
			
			try
			{
				// parse querystring parameters
				int tmpItemId;
				if (int.TryParse (Request.QueryString ["DnnModuleID"], out tmpItemId))
					itemId = tmpItemId;
      
				if (!IsPostBack)
				{
					// load the data into the control the first time we hit this page

					// check we have an item to lookup
					// ALT: if (!Null.IsNull (itemId) 
					if (itemId.HasValue)
					{
						// load the item
						var ctrl = new DnnModuleController ();
						var item = ctrl.Get<DnnModuleInfo> (itemId.Value, this.ModuleId);

						if (item != null)
						{
							// TODO: Fill controls with data
							txtContent.Text = item.Content;
							
							// setup audit control
							ctlAudit.CreatedByUser = item.CreatedByUserName;
							ctlAudit.CreatedDate = item.CreatedOnDate.ToLongDateString ();
						}
						else
							Response.Redirect (Globals.NavigateURL (), true);
					}
					else
					{
						buttonDelete.Visible = false;
						ctlAudit.Visible = false;
					}
				}
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}

		/// <summary>
		/// Handles Click event for Update button
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// Event args.
		/// </param>
		protected void buttonUpdate_Click (object sender, EventArgs e)
		{
			try
			{
				var ctrl = new DnnModuleController ();
				DnnModuleInfo item;

				// determine if we are adding or updating
				// ALT: if (Null.IsNull (itemId))
				if (!itemId.HasValue)
				{
					// TODO: populate new object properties with data from controls 
					// to add new record
					item = new DnnModuleInfo ();
					item.Content = txtContent.Text;
					item.ModuleID = this.ModuleId;
					item.CreatedByUser = this.UserId;					

					ctrl.Add<DnnModuleInfo> (item);
				}
				else
				{
					// TODO: update properties of existing object with data from controls 
					// to update existing record
					item = ctrl.Get<DnnModuleInfo> (itemId.Value, this.ModuleId);
					item.Content = txtContent.Text;

					ctrl.Update<DnnModuleInfo> (item);
				}

				Utils.SynchronizeModule (this);

				Response.Redirect (Globals.NavigateURL (), true);
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}

		/// <summary>
		/// Handles Click event for Delete button
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// Event args.
		/// </param>
		protected void buttonDelete_Click (object sender, EventArgs e)
		{
			try
			{
				// ALT: if (!Null.IsNull (itemId))
				if (itemId.HasValue)
				{
					var ctrl = new DnnModuleController ();
					ctrl.Delete<DnnModuleInfo> (itemId.Value);
					Response.Redirect (Globals.NavigateURL (), true);
				}
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}

		#endregion
	}
}

