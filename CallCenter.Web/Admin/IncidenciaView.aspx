<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciaView.aspx.cs" Inherits="CallCenter.Web.Admin.IncidenciaView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalles de Incidencia</h1>
    <table>
        <tr>
            <td><h3>Estado: </h3></td>
            <td><h3><asp:Label ID="lblEstado" runat="server"></asp:Label></h3></td>
            <td><asp:Button ID="CambiarEstado" runat="server" Text="Cambiar Estado" OnClick="CambiarEstado_Click" /> </td>
        </tr>
        <tr>
            <td>Id: </td>
            <td><asp:Label ID="lblId" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>Fecha: </td>
            <td><asp:Label ID="lblFecha" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Usuario: </td>
            <td><asp:Label ID="lblUsuario" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Equipo: </td>
            <td><asp:Label ID="lblEquipo" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Descripci&oacute;n Equipo:</td>
            <td><asp:Label ID="lblDescripcionEquipo" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Problema: </td>
            <td><asp:Label ID="lblProblema" runat="server"></asp:Label></td>
        </tr>
    </table>
    
    <h1>Hilo de Comunicaci&oacute;n</h1>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
        <table class="messageTable">
            <thead>
                <tr>
                    <th>Autor</th>
                    <th>Mensaje</th>
                </tr>
            </thead>
            <tbody>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </tbody>
        </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="Fecha" runat="server" Text='<%# Eval("Fecha") %>'></asp:Literal></td>
            </tr>
            <tr>
                <td class="messageAutor"><strong><asp:Literal ID="Autor" runat="server" Text='<%# Membership.GetUser(Eval("UserId")) %>'></asp:Literal></strong></td>
                <td class="messageText"><asp:Literal ID="Mensaje" runat="server" Text='<%# Eval("Texto") %>'></asp:Literal></td>
            </tr>
        </ItemTemplate>
        </asp:ListView>

        <textarea id="txtMensaje" runat="server" cols="50" rows="5"></textarea>
        <br />
        <asp:Button ID="Enviar" runat="server" CssClass="btnGuardar" Text="Enviar" OnClick="Enviar_Click" />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Content>
