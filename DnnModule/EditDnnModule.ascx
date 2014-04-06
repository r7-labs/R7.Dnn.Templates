<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EditDnnModule.ascx.cs" Inherits="DnnModule.EditDnnModule" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>

<div class="dnnForm dnnClear">
	<fieldset>	
		<div class="dnnFormItem">
			<dnn:Label ID="lblContent" runat="server" ControlName="lblContent" Suffix=":" />
			<dnn:TextEditor ID="txtContent" runat="server" Height="200" Width="100%" />
		</div>
	</fieldset>
	<ul class="dnnActions dnnClear">
		<li><asp:LinkButton id="buttonUpdate" runat="server" CssClass="dnnPrimaryAction" ResourceKey="cmdUpdate" CausesValidation="true" /></li>
		<li><asp:LinkButton id="buttonDelete" runat="server" CssClass="dnnSecondaryAction" ResourceKey="cmdDelete" /></li>
		<li><asp:HyperLink id="linkCancel" runat="server" CssClass="dnnSecondaryAction" ResourceKey="cmdCancel" /></li>
	</ul>
	<dnn:Audit id="ctlAudit" runat="server" />
</div>

