using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Portals;
using DotNetNuke.UI.Skins;
using DotNetNuke.Services.Localization;

namespace ${Namespace}
{
    public class ${SafeProjectName} : SkinObjectBase
    {
        #region Controls
    
        protected Literal litContent;

        #endregion

        #region Control properties

        public string CssClass {
        	get {
                if (!string.IsNullOrEmpty (Attributes ["CssClass"])) {
                    return Attributes ["CssClass"];
                }
        		return string.Empty;
        	}
        }

        #endregion

        string template;
        protected string Template {
        	get {
        		if (template == null) {
        			template = Localization.GetString ("Template.Text", LocalResourceFile);
                    if (string.IsNullOrEmpty (template)) {
                        template = "Error loading template from resource file!";
                    }
        		}
        		return template;
        	}
        }
    
        string localResourceFile;
        protected string LocalResourceFile {
        	get {
        		if (localResourceFile == null) {
        			localResourceFile = DotNetNuke.Web.UI.Utilities.GetLocalResourceFile (this);
        		}
                return localResourceFile;
            }
        }

        protected string GetCreatedByUserName (int createdByUserId)
        {
            var user = UserController.GetUserById (PortalSettings.Current.PortalId, createdByUserId);

            if (user != null) {
                return user.DisplayName;
            }

            return Localization.GetString ("SystemUser.Text", LocalResourceFile);
        }

        protected override void OnLoad (EventArgs e)
        {
        	base.OnLoad (e);

        	if (!IsPostBack) {
        		var activeTab = PortalSettings.ActiveTab;
                var content = Template.Replace ("[CSSCLASS]", CssClass);
                content = content.Replace ("[CREATEDBYUSER]", GetCreatedByUserName (activeTab.CreatedByUserID));
                content = content.Replace ("[CREATEDONDATE]", activeTab.CreatedOnDate.ToShortDateString ());

    			litContent.Text = content;
        	}
        }
    }
}