using System;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using R7.DotNetNuke.Extensions.Modules;
using ${ProjectName}.Models;

namespace ${Namespace}
{	
	public partial class Settings : ModuleSettingsBase<${ProjectName}Settings>
	{
        #region Controls

        protected TextBox txtTemplate;

        #endregion

		/// <summary>
		/// Handles the loading of the module setting for this control
		/// </summary>
		public override void LoadSettings ()
		{
			try {
				if (!IsPostBack) {
					if (!string.IsNullOrWhiteSpace (Settings.Template)) {
						txtTemplate.Text = Settings.Template;
					}
				}
			}
			catch (Exception ex) {
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
      
		/// <summary>
		/// handles updating the module settings for this control
		/// </summary>
		public override void UpdateSettings ()
		{
			try {
				Settings.Template = txtTemplate.Text;
					
				SettingsRepository.SaveSettings (ModuleConfiguration, Settings);	
				ModuleController.SynchronizeModule (ModuleId);
			}
			catch (Exception ex) {
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
	}
}