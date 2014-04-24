<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Alphalink.ascx.cs" Inherits="Seguridad.Controls.Alphalink" %>
<asp:Repeater runat="server" ID="__theAlphalink" OnItemDataBound="DisableSelectedLink">
<ItemTemplate>
	<asp:LinkButton runat="server" ID="link" 
		text="<%# Container.DataItem %>"
		CommandName="Filter"
		CommandArgument='<%# DataBinder.Eval(Container, "DataItem")%>'
		OnCommand="Select"
		 />&nbsp;
</ItemTemplate>
</asp:Repeater>