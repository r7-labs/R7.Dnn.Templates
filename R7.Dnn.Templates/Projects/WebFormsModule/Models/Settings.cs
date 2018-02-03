using DotNetNuke.Entities.Modules.Settings;

namespace ${Namespace}
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class ${SafeProjectName}Settings
    {
        /// <summary>
        /// Template used to render the module content
        /// </summary>
        [TabModuleSetting (Prefix = "${AuthorCompany}_${SafeProjectName}_")]
        public string Template { get; set; } = "<em>[CREATEDONDATE]</em> <strong>[CREATEDBYUSERNAME]:</strong><p>[CONTENT]</p>";
    }
}