using System;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using R7.Dnn.Extensions.Modules;
using ${ProjectName}.Models;

namespace ${Namespace}
{	
	public class EditSettings : ModuleSettingsBase<${ProjectName}Settings>
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
		/// Handles updating the module settings for this control
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