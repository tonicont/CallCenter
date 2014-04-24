<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Seguridad.Admin.Access.User" %>
<%@ Register TagPrefix="dc" TagName="alphalinks" Src="Alphalink.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
<table class="webparts">
<tr align="left">
	<th align="left">Usuarios por Nombre
    </th>
</tr>
<tr>
<td class="details" valign="top">

Filtro por nombre de usuario:&nbsp;&nbsp;&nbsp;

<br />
    <dc:alphalinks runat="server" ID="Alphalinks" />
    <br />

<asp:GridView runat="server" ID="Users" AutoGenerateColumns="false"
	CssClass="list" AlternatingRowStyle-CssClass="odd" GridLines="none"
	>
<Columns>
	<asp:TemplateField>
		<HeaderTemplate>Nombre de Usuario</HeaderTemplate>
		<ItemTemplate>
		<a href="EditUser.aspx?username=<%# Eval("UserName") %>"><%# Eval("UserName") %></a>
		</ItemTemplate>
	</asp:TemplateField>
	<asp:BoundField DataField="email" HeaderText="Email" />
	<asp:BoundField DataField="comment" HeaderText="Comentario" />
	<asp:BoundField DataField="creationdate" HeaderText="Fecha de creación" />
	<asp:BoundField DataField="lastlogindate" HeaderText="Fecha de último acceso" />
	<asp:BoundField DataField="lastactivitydate" HeaderText="Fecha de última actividad" />
	<asp:BoundField DataField="isapproved" HeaderText="Activo" />
	<asp:BoundField DataField="isonline" HeaderText="Online" />
	<asp:BoundField DataField="islockedout" HeaderText="Bloqueado" />
</Columns>
</asp:GridView>

</td>

</tr></table>
</asp:Content>
