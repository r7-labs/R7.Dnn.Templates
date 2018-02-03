<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="${ProjectName}.View" %>
<asp:ListView id="lstContent" ItemType="${ProjectName}.Models.${SafeProjectName}Info" runat="server">
    <LayoutTemplate>
        <ul runat="server" class="${SafeProjectName}-content-list">
            <asp:Placeholder runat="server" id="itemPlaceholder" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li class="${SafeProjectName}-content-item">
            <asp:HyperLink id="linkEdit" runat="server" Visible="<%# IsEditable %>"
                    NavigateUrl='<%# EditUrl ("${SafeProjectName}Id".ToLowerInvariant (), Item.${SafeProjectName}Id.ToString (), "Edit") %>'>
                <asp:Image id="imageEdit" runat="server" IconKey="Edit" ResourceKey="Edit" />
            </asp:HyperLink>
            <asp:Literal runat="server" Text="<%# Item.FillTemplate (Settings.Template) %>" />
        </li>
    </ItemTemplate>
</asp:ListView>
