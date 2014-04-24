<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Seguridad.Admin.Access.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
<table class="webparts">
<tr>
	<th align="left">Añadir usuario</th>
</tr>
<tr>
<td class="details" valign="top">

<h3>Roles:</h3>
<asp:CheckBoxList ID="UserRoles" runat="server" />

<h3>Información principal:</h3>

<table>
<tr>
	<td class="detailheader">Usuario activo</td>
	<td>
		<asp:CheckBox ID="isapproved" runat="server" Checked="true" />
	</td>
</tr>
<tr>
	<td class="detailheader">Nombre de usuario</td>
	<td>
		<asp:TextBox ID="username" runat="server"></asp:TextBox>
	</td>
</tr>
<tr>
	<td class="detailheader">Contraseña</td>
	<td>
		<asp:TextBox ID="password" runat="server"></asp:TextBox>
	</td>
</tr>
<tr>
	<td class="detailheader">Email</td>
	<td>
		<asp:TextBox ID="email" runat="server"></asp:TextBox>
	</td>
</tr>
<tr>
	<td class="detailheader">Comentario</td>
	<td>
		<asp:TextBox ID="comment" runat="server"></asp:TextBox>
	</td>
</tr>
<tr>
	<td colspan="2"><br />
		<input type="submit" value="Añadir Usuario" />&nbsp;
		<input type="reset" />
	</td>
</tr>
<tr>
	<td colspan="2">
	<div id="ConfirmationMessage" runat="server" class="alert"></div>
	</td>
</tr>
</table>

<asp:ObjectDataSource ID="MemberData" runat="server" DataObjectTypeName="System.Web.Security.MembershipUser" SelectMethod="GetUser" UpdateMethod="UpdateUser" TypeName="System.Web.Security.Membership">
	<SelectParameters>
		<asp:QueryStringParameter Name="username" QueryStringField="username" />
	</SelectParameters>
</asp:ObjectDataSource> 
</td>

</tr></table>
</asp:Content>
