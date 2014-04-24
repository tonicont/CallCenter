<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipoEdit.aspx.cs" Inherits="CallCenter.Web.User.EquipoEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Editar Equipo</h1>
    <table>
        <tr>
            <td>Nombre:</td>
            <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descripci&oacute;n</td>
            <td><textarea id="txtDescripcion" runat="server" cols="20" rows="2"></textarea></td>
        </tr>
        <tr>
            <td>Tipo de Equipo</td>
            <td>
                <asp:DropDownList ID="Listatipo" runat="server"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Button ID="Guargar" runat="server" Text="Guardar" OnClick="Guardar_Click"/>
    <asp:HyperLink ID="volver" runat="server" Text="Volver" NavigateUrl="~/User/EquiposList.aspx"></asp:HyperLink>
    <br />
    <asp:Label ID="lblResult" runat="server" ></asp:Label>
</asp:Content>
