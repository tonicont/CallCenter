<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoEquipoEdit.aspx.cs" Inherits="CallCenter.Web.Admin.TipoEquipoEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Editar Equipo</h1>
    <table>
        <tr>
            <td>Id:</td>
            <td><asp:TextBox ID="Id" runat="server" Text="" ReadOnly="true" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Nombre:</td>
            <td><asp:TextBox ID="Nombre" runat="server" Text="" ></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descripci&oacute;n:</td>
            <td><textarea id="Descripcion" runat="server" cols="20" rows="2"></textarea></td>
        </tr>
    </table>  
    <asp:Button ID="Guardar" runat="server" Text="Guardar" OnClick="Guardar_Click" />
    <asp:HyperLink ID="volver" runat="server" Text="Volver" NavigateUrl="TipoEquipoList.aspx"></asp:HyperLink>
    <br />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Content>
