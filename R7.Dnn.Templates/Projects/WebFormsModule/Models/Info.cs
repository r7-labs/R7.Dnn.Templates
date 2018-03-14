using System;
using System.Web;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace ${Namespace}
{
    // http://www.dnnsoftware.com/wiki/dal-2

    [TableName ("${AuthorCompany}_${SafeProjectName}_${SafeProjectName}s")]
    [PrimaryKey (nameof (${SafeProjectName}Id), AutoIncrement = true)]
    [Scope (nameof (ModuleId))]
    [Cacheable]
    public class ${SafeProjectName}Info
    {
        #region Fields
        
        string createdByUserName;

        #endregion

        #region Properties

        public int ${SafeProjectName}Id { get; set; }

        public int ModuleId { get; set; }

        public string Content { get; set; }

        public int CreatedByUserId { get; set; }

        [ReadOnlyColumn]
        public DateTime CreatedOnDate { get; set; }

        [IgnoreColumn]
        public string CreatedByUserName {
        	get {
        		if (createdByUserName == null) {
        			var portalId = PortalController.Instance.GetCurrentPortalSettings ().PortalId;
        			var user = UserController.GetUserById (portalId, CreatedByUserId);
        			createdByUserName = user.DisplayName;
        		}

        		return createdByUserName;
        	}
        }

        public string FillTemplate (string template)
        {
        	template = template.Replace ("[CREATEDBYUSER]", CreatedByUserId.ToString ());
        	template = template.Replace ("[CREATEDBYUSERNAME]", CreatedByUserName);
        	template = template.Replace ("[CREATEDONDATE]", CreatedOnDate.ToShortDateString ());
        	template = template.Replace ("[CONTENT]", HttpUtility.HtmlDecode (Content));

        	return template;
        }

        #endregion
     }
}