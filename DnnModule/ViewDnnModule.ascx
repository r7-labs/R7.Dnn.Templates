<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewDnnModule.ascx.cs" Inherits="DnnModule.ViewDnnModule" %>
<asp:DataList ID="lstContent" DataKeyField="DnnModuleID" runat="server" CssClass="DnnModule_ContentList" OnItemDataBound="lstContent_ItemDataBound">
	<ItemTemplate>
		<asp:HyperLink ID="linkEdit" runat="server">
			<asp:Image ID="imageEdit" runat="server" ImageUrl="~/images/edit.gif" AlternateText="Edit" ResourceKey="Edit" />
		</asp:HyperLink>
		<asp:Label ID="lblUserName" runat="server" CssClass="DnnModule_UserName" />
		<asp:Label ID="lblCreatedOnDate" runat="server" CssClass="DnnModule_CreatedOnDate" /> 
		<asp:Label ID="lblContent" runat="server" CssClass="DnnModule_Content" />
	</ItemTemplate>
	<ItemStyle CssClass="DnnModule_ContentListItem" />
</asp:DataList>
<!-- Label for debug info -->
<asp:Label ID="lblDebug" runat="server" />

