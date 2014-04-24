<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Seguridad.Admin.Access.EditUser" %>
<%@ Register src="Alphalink.ascx" tagname="Alphalink" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table class="webparts">
<tr>
	<th align="left">Información de usuario</th>
</tr>
<tr>
<td class="details" valign="top">

<h3>Roles:</h3>
<asp:CheckBoxList ID="UserRoles" runat="server" />

<h3>Información principal:</h3>
<asp:DetailsView AutoGenerateRows="False" DataSourceID="MemberData"
  ID="UserInfo" runat="server" OnItemUpdating="UserInfo_ItemUpdating"
  >
  
<Fields>
	<asp:BoundField DataField="UserName" HeaderText="Nombre de usuario" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="Comment" HeaderText="Comentario" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:CheckBoxField DataField="IsApproved" HeaderText="Activor" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	<asp:CheckBoxField DataField="IsLockedOut" HeaderText="Bloqueado" ReadOnly="true" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	
	<asp:CheckBoxField DataField="IsOnline" HeaderText="Online" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	<asp:BoundField DataField="CreationDate" HeaderText="Fecha de creación" ReadOnly="True"
	 HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="LastActivityDate" HeaderText="Fecha última actividad" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="LastLockoutDate" HeaderText="Fecha último bloqueo" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="LastPasswordChangedDate" HeaderText="Fecha último cambio de contraseña"
	ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:CommandField ButtonType="button" ShowEditButton="true" EditText="Editar información de usuario" />
</Fields>
</asp:DetailsView>
<div class="alert" style="padding: 5px;">
<asp:Literal ID="UserUpdateMessage" runat="server">&nbsp;</asp:Literal>
</div>


<div style="text-align: right; width: 100%; margin: 20px 0px;">
<asp:Button ID="Button1" runat="server" Text="Desbloquear usuario" OnClick="UnlockUser" OnClientClick="return confirm('Click OK para desbloquear este usuario.')" />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button2" runat="server" Text="Eliminar usuario" OnClick="DeleteUser" OnClientClick="return confirm('¿Está usted seguro, que desea eliminar este usuario?')" />
</div>


<asp:ObjectDataSource ID="MemberData" runat="server" DataObjectTypeName="System.Web.Security.MembershipUser" SelectMethod="GetUser" UpdateMethod="UpdateUser" TypeName="System.Web.Security.Membership">
	<SelectParameters>
		<asp:QueryStringParameter Name="username" QueryStringField="username" />
	</SelectParameters>
</asp:ObjectDataSource> 
</td>

</tr></table>
</asp:Content>
