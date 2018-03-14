using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search.Entities;
using R7.Dnn.Extensions.Data;
using ${ProjectName}.Models;

namespace ${Namespace}
{
    public class ${SafeProjectName}Controller : ModuleSearchBase, IPortable
    {
        #region ModuleSearchBase implementaion

        public override IList<SearchDocument> GetModifiedSearchDocuments (ModuleInfo moduleInfo, DateTime beginDateUtc)
        {
        	var searchDocs = new List<SearchDocument> ();

        	// TODO: Implement GetModifiedSearchDocuments () here
        	// var sd = new SearchDocument ();
        	// searchDocs.Add (searchDoc);

        	return searchDocs;
        }

        #endregion

        #region IPortable members

        /// <summary>
        /// Exports a module to XML
        /// </summary>
        /// <param name="ModuleID">a module ID</param>
        /// <returns>XML string with module representation</returns>
        public string ExportModule (int moduleId)
        {
        	var sb = new StringBuilder ();
        	var dataProvider = new Dal2DataProvider ();
        	var infos = dataProvider.GetObjects<${SafeProjectName}Info> (moduleId);

        	if (infos != null) {
        		sb.Append ("<${SafeProjectName}s>");
        		foreach (var info in infos) {
        			sb.Append ("<${SafeProjectName}>");
        			sb.Append ("<content>");
        			sb.Append (XmlUtils.XMLEncode (info.Content));
        			sb.Append ("</content>");
        			sb.Append ("</${SafeProjectName}>");
        		}
        		sb.Append ("</${SafeProjectName}s>");
        	}

        	return sb.ToString ();
        }   

        /// <summary>
        /// Imports a module from an XML
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule (int ModuleID, string Content, string Version, int UserID)
        {
        	var infos = DotNetNuke.Common.Globals.GetContent (Content, "${SafeProjectName}s");
        	var dataProvider = new Dal2DataProvider ();

        	foreach (XmlNode info in infos.SelectNodes ("${SafeProjectName}")) {
        		var item = new ${SafeProjectName}Info ();
        		item.ModuleId = ModuleID;
        		item.Content = info.SelectSingleNode ("content").InnerText;
        		item.CreatedByUserId = UserID;

        		dataProvider.Add<${SafeProjectName}Info> (item);
        	}
        }

        #endregion
    }
}