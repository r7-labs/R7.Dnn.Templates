using System;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.UserControls;
using R7.Dnn.Extensions.Data;
using ${ProjectName}.Models;

namespace ${Namespace}
{
    public class Edit : PortalModuleBase
    {
        #region Controls

        protected LinkButton buttonUpdate;
        protected LinkButton buttonDelete;
        protected HyperLink linkCancel;
        protected TextEditor txtContent;
        protected ModuleAuditControl ctlAudit;

        #endregion

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

        	try {
        		// parse querystring parameters
        		int tmpItemId;
        		if (int.TryParse (Request.QueryString ["${SafeProjectName}Id"], out tmpItemId))
        			itemId = tmpItemId;

        		if (!IsPostBack) {
        			// load the data into the control the first time we hit this page

        			// check we have an item to lookup
        			// ALT: if (!Null.IsNull (itemId) 
        			if (itemId.HasValue) {
        				// load the item
        				var dataProvider = new Dal2DataProvider ();
        				var item = dataProvider.Get<${SafeProjectName}Info> (itemId.Value, ModuleId);

        				if (item != null) {
        					// TODO: Fill controls with data
        					txtContent.Text = item.Content;

        					// setup audit control
        					ctlAudit.CreatedByUser = item.CreatedByUserName;
        					ctlAudit.CreatedDate = item.CreatedOnDate.ToLongDateString ();
                        } else {
        					Response.Redirect (Globals.NavigateURL (), true);
                        }
        			} else {
        				buttonDelete.Visible = false;
        				ctlAudit.Visible = false;
        			}
        		}
        	} catch (Exception ex) {
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
        	try {
        		var dataProvider = new Dal2DataProvider ();
                ${SafeProjectName}Info item;

        		// determine if we are adding or updating
        		// ALT: if (Null.IsNull (itemId))
        		if (!itemId.HasValue) {
        			// TODO: populate new object properties with data from controls 
        			// to add new record
        			item = new ${SafeProjectName}Info ();
        		} else {
        			// TODO: update properties of existing object with data from controls 
        			// to update existing record
        			item = dataProvider.Get<${SafeProjectName}Info> (itemId.Value, ModuleId);
        		}

        		// fill the object
        		item.Content = txtContent.Text;
        		item.ModuleId =  ModuleId;

        		if (!itemId.HasValue) {
        			item.CreatedByUserId = UserId;
        			dataProvider.Add<${SafeProjectName}Info> (item);
        		} else {
        			dataProvider.Update<${SafeProjectName}Info> (item);
        		}

        		ModuleController.SynchronizeModule (ModuleId);
        		Response.Redirect (Globals.NavigateURL (), true);

        	} catch (Exception ex) {
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
        	try {
        		if (itemId.HasValue) {
        			var dataProvider = new Dal2DataProvider ();
        			dataProvider.Delete<${SafeProjectName}Info> (itemId.Value);
        			Response.Redirect (Globals.NavigateURL (), true);
        		}
        	} catch (Exception ex) {
        		Exceptions.ProcessModuleLoadException (this, ex);
        	}
        }
        
        #endregion
    }
}