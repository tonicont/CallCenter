<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="IncidenciasList.aspx.cs" Inherits="CallCenter.Web.Admin.IncidenciasList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Lista de Incidencias</h1>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table class="itemsTable">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Fecha</th>
                        <th>Problema</th>
                        <th>Usuario</th>
                        <th>Equipo</th>
                        <th>Estado</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="Id" runat="server" Text='<%# Eval("Id") %>'></asp:Literal></td>
                <td><asp:Literal ID="Fecha" runat="server" Text='<%# Eval("Fecha") %>'></asp:Literal></td>
                <td><asp:Literal ID="Problema" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Literal></td>
                <td><asp:Literal ID="Usuario" runat="server" Text='<%# Eval("UserId") %>'></asp:Literal></td>
                <td><asp:Literal ID="Equipo" runat="server" Text='<%# Eval("Equipo.Nombre") %>'></asp:Literal></td>
                <td><asp:Literal ID="Estado" runat="server" Text='<%# Eval("Estado") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="ver" runat="server" NavigateUrl='<%# Eval("Id","IncidenciaView.aspx?Id={0}") %>' Text="Ver"></asp:HyperLink></td>
                <td><asp:Button ID="eliminar" runat="server" Text="Eliminar"  OnClientClick="if(!confirm('¿Esta seguro de eliminar la incidencia?')){return false;};" OnCommand="Eliminar_Click" CommandArgument='<%# Eval("Id") %>'/></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
