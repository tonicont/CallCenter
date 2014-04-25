<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaNew.aspx.cs" Inherits="CallCenter.Web.User.IncidenciaNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nueva Incidencia</h1>
    <table>
        <tr>
            <td>Equipo:</td>
            <td><asp:DropDownList ID="ListaEquipos" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Describa la incidencia:</td>
            <td><textarea id="txtDescipcion" runat="server" cols="20" rows="5" ></textarea></td>
        </tr>
    </table>
    <asp:Button ID="Enviar" runat="server" CssClass="btnGuardar" Text="Enviar" OnClick="Enviar_Click" />
    <asp:HyperLink ID="voler" runat="server" Text="Volver" NavigateUrl="~/User/IncidenciasList.aspx"></asp:HyperLink>
    <br />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Content>
