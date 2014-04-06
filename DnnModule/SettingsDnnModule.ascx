﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsDnnModule.ascx.cs" Inherits="DnnModule.SettingsDnnModule" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<div class="dnnForm dnnClear">
	<h2 class="dnnFormSectionHead"><a href=""><asp:Label runat="server" ResourceKey="sectionBaseSettings.Text" /></a></h2>
	<fieldset>	
		<div class="dnnFormItem">
			<dnn:Label ID="lblTemplate" runat="server" ControlName="txtTemplate" Suffix=":" />
			<asp:TextBox ID="txtTemplate" runat="server" CssClass="NormalTextBox" Rows="10" Columns="30" TextMode="MultiLine" MaxLength="2000" />
		</div>
	</fieldset>	
</div>

