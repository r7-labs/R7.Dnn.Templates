﻿using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DotNetNuke.UI.UserControls;
using DotNetNuke.UI.WebControls;

namespace DnnModule
{
	public partial class EditDnnModule
	{
		protected LinkButton buttonUpdate;
		protected LinkButton buttonDelete;
		protected HyperLink linkCancel;
		protected LabelControl lblContent;
		protected TextEditor txtContent;
		protected ModuleAuditControl ctlAudit;
	}
}