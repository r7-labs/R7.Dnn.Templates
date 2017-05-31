using System;
using System.Linq;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Icons;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using R7.DotNetNuke.Extensions.Data;
using R7.DotNetNuke.Extensions.ModuleExtensions;
using R7.DotNetNuke.Extensions.Modules;
using ${ProjectName}.Models;

namespace ${Namespace}
{
    public partial class View : PortalModuleBase<${ProjectName}Settings>, IActionable
    {
        #region Controls

        protected ListView lstContent;

        #endregion
                
        protected override void OnLoad (EventArgs e)
        {
        	base.OnLoad (e);

        	try {
        		if (!IsPostBack) {
        			var dataProvider = new Dal2DataProvider ();
                    var items = dataProvider.GetObjects<${ProjectName}Info> (ModuleId);

        			// check if we have some content to display
                    if (IsEditable && !items.Any ()) {
        				this.Message ("NothingToDisplay.Text", MessageType.Info, true);
        			} else {
        				// bind the data
        				lstContent.DataSource = items;
        				lstContent.DataBind ();
        			}
        		}
        	} catch (Exception ex) {
        		Exceptions.ProcessModuleLoadException (this, ex);
        	}
        }

        #region IActionable implementation

        public ModuleActionCollection ModuleActions {
        	get {
        		var actions = new ModuleActionCollection ();
        		actions.Add (
        			GetNextActionID (),
        			LocalizeString (ModuleActionType.AddContent),
        			ModuleActionType.AddContent,
        			"",
        			IconController.IconURL ("Add"),
        			EditUrl ("Edit"),
        			false,
        			DotNetNuke.Security.SecurityAccessLevel.Edit,
        			true,
        			false
        		);

        		return actions;
        	}
        }

        #endregion
    }
}