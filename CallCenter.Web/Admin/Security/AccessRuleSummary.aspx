<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessRuleSummary.aspx.cs" Inherits="Seguridad.Admin.Access.AccessRuleSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
<table class="webparts">
<tr>
	<th align="left">Resumen de acceso de seguridad</th>
</tr>
<tr>
	<td class="details" valign="top">
		<table>
		<tr>
			<td valign="top" style="padding-right: 30px;">
				
				<asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true"
					AutoPostBack="true" OnSelectedIndexChanged="DisplayRoleSummary">
				<asp:ListItem>Seleccione Rol</asp:ListItem>
				</asp:DropDownList>
				
				&nbsp;&nbsp;&nbsp;&nbsp;<b>&mdash;&nbsp;&nbsp;O&nbsp;&nbsp;&mdash;</b>
				&nbsp;&nbsp;&nbsp;				
				
				<asp:DropDownList ID="UserList" runat="server" AppendDataBoundItems="true"
					AutoPostBack="true" OnSelectedIndexChanged="DisplayUserSummary">
				<asp:ListItem>Seleccione Usuario</asp:ListItem>
				<asp:ListItem Text="Usuarios anónimos (?)" Value="?"></asp:ListItem>
				<asp:ListItem Text="Usuarios autenticados que no están en ningún rol (*)" Value="*"></asp:ListItem>
				</asp:DropDownList>	
				
				<br />
				
				<div class="treeview">
				<asp:TreeView runat="server" ID="FolderTree"
					OnSelectedNodeChanged="FolderTree_SelectedNodeChanged"
					>
					<RootNodeStyle ImageUrl= "/Images/folder.gif" />
					<ParentNodeStyle ImageUrl="/Images/folder.gif" />
					<LeafNodeStyle ImageUrl="/Images/folder.gif" />
					<SelectedNodeStyle Font-Underline="true" ForeColor="#A21818" />
				</asp:TreeView>
				</div>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</asp:Content>
