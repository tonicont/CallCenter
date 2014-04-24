<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessRules.aspx.cs" Inherits="Seguridad.Admin.Access.AccessRules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
<table class="webparts">
<tr>
	<th align="left">Reglas de acceso</th>
</tr>
<tr>
	<td class="details" valign="top">
		<p>
		Utilice esta página para gestionar las reglas de acceso para su sitio Web. Las reglas se aplican a las carpetas, proporcionando así robusto nivel de carpeta de seguridad impuestas por la infraestructura de ASP.NET. Reglas se almacenan como XML en el archivo Web.config de cada carpeta. Página nivel de seguridad y la seguridad interior de la página no se manejan con esta herramienta - que se manejan con código especializado que está disponible para los desarrolladores Web.</i>
		</p>

		<table>
		<tr>
			<td valign="top" style="padding-right: 30px;">
				<div class="treeview">
				<asp:TreeView runat="server" ID="FolderTree"
					OnSelectedNodeChanged="FolderTree_SelectedNodeChanged">
					<RootNodeStyle ImageUrl="/Images/folder.gif" />
					<ParentNodeStyle ImageUrl="/Images/folder.gif" />
					<LeafNodeStyle ImageUrl="/Images/folder.gif" />
					<SelectedNodeStyle Font-Underline="true" ForeColor="#A21818" />
				</asp:TreeView>
				</div> 
			</td>

			<td valign="top" style="padding-left: 30px; border-left: 1px solid #999;">
			<asp:Panel runat="server" ID="SecurityInfoSection" Visible="false">
				<h2 runat="server" id="TitleOne" class="alert"></h2>
				
				<p>
				Las reglas se aplican en orden. La primera regla que coincide se aplica, y la autorización en cada Estado prevalece sobre los permisos de todas las reglas siguientes. Use los botones Subir y Bajar para cambiar el orden de la regla seleccionada. Normas que aparecen atenuadas se heredan de los padres y no se puede cambiar a este nivel. 
				</p>
				
				<asp:GridView runat="server" ID="RulesGrid" AutoGenerateColumns="False"
				CssClass="list" GridLines="None"
				OnRowDataBound="RowDataBound"
				>
					<Columns>
						<asp:TemplateField HeaderText="Acción">
							<ItemTemplate>
								<%# GetAction((System.Web.Configuration.AuthorizationRule)Container.DataItem)%>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Rol">
							<ItemTemplate>
								<%# GetRole((System.Web.Configuration.AuthorizationRule)Container.DataItem) %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Usuario">
							<ItemTemplate>
								<%# GetUser((System.Web.Configuration.AuthorizationRule)Container.DataItem) %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Eliminar Regla">
							<ItemTemplate>
								<asp:Button ID="Button1" runat="server" Text="Eliminar Regla" CommandArgument="<%# (System.Web.Configuration.AuthorizationRule)Container.DataItem %>" OnClick="DeleteRule" OnClientClick="return confirm('Click OK para eliminar esta regla.')" />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Move Rule">
							<ItemTemplate>
								<asp:Button ID="Button2" runat="server" Text="Subir" CommandArgument="<%# (System.Web.Configuration.AuthorizationRule)Container.DataItem %>" OnClick="MoveUp" />
								<asp:Button ID="Button3" runat="server" Text="Bajar" CommandArgument="<%# (System.Web.Configuration.AuthorizationRule)Container.DataItem %>" OnClick="MoveDown" />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>

				<br />
				<hr />
				<h2 runat="server" id="TitleTwo" class="alert"></h2>
				<b>Acción:</b>
				<asp:RadioButton runat="server" ID="ActionDeny" GroupName="action" 
					Text="Denegar" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:RadioButton runat="server" ID="ActionAllow" GroupName="action" 
					Text="Permitir" />
				
				<br /><br />
				<b>Reglas aplicadas a:</b>
				<br />
				<asp:RadioButton runat="server" ID="ApplyRole" GroupName="applyto"
					Text="Este Rol:" Checked="true" />
				<asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true">
				<asp:ListItem>Seleccione Rol</asp:ListItem>
				</asp:DropDownList>
				<br />
					
				<asp:RadioButton runat="server" ID="ApplyUser" GroupName="applyto"
					Text="Este usuario:" />
				<asp:DropDownList ID="UserList" runat="server" AppendDataBoundItems="true">
				<asp:ListItem>Seleccione Usuario</asp:ListItem>
				</asp:DropDownList>	
				<br />
				
				
				<asp:RadioButton runat="server" ID="ApplyAllUsers" GroupName="applyto"
					Text="Todos usuarios (*)"  />
				<br />
				
				
				<asp:RadioButton runat="server" ID="ApplyAnonUser" GroupName="applyto"
					Text="Usuarios anónimos (?)"  />
				<br /><br />
				
				<asp:Button ID="Button4" runat="server" Text="Crear Regla" OnClick="CreateRule"
					OnClientClick="return confirm('Click en OK para crear esta regla.');" />
					
				<asp:Literal runat="server" ID="RuleCreationError"></asp:Literal>
			</asp:Panel>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</asp:Content>
