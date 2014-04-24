<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rols.aspx.cs" Inherits="Seguridad.Admin.Access.Rols" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
<table class="webparts">
<tr>
	<th align="left">Roles</th>
</tr>
<tr>
<td class="details" valign="top" style="width: 450px;">

<br />

<asp:GridView runat="server" ID="UserRoles" AutoGenerateColumns="false"
	CssClass="list" AlternatingRowStyle-CssClass="odd" GridLines="none"
	>
	<Columns>
		<asp:TemplateField>
			<HeaderTemplate>Rol</HeaderTemplate>
			<ItemTemplate>
				<%# Eval("Role Name") %>
			</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>Usuarios</HeaderTemplate>
			<ItemTemplate>
				<%# Eval("User Count") %>
			</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>Eliminar rol</HeaderTemplate>
			<ItemTemplate>
				<asp:Button ID="Button1" runat="server" OnCommand="DeleteRole" CommandName="DeleteRole" CommandArgument='<%# Eval("Role Name") %>' Text="Borrar" OnClientClick="return confirm('¿Está seguro que desea eliminar este Rol?')" />
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
</asp:GridView>


<p>
Nuevo Rol:
<asp:TextBox runat="server" ID="NewRole"></asp:TextBox>

<asp:Button ID="Button2" runat="server" OnClick="AddRole" Text="Añadir Rol" />
</p>

<div runat="server" id="ConfirmationMessage" class="alert">
</div>

</td>

</tr></table>
</asp:Content>
