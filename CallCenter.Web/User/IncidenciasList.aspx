<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="IncidenciasList.aspx.cs" Inherits="CallCenter.Web.User.IncidenciasList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mis Incidencias</h1>
    <asp:HyperLink ID="NuevaIncidencia" runat="server" Text="Crear Nueva Incidencia" NavigateUrl="~/User/IncidenciaNew.aspx"></asp:HyperLink>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table class="itemsTable">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Fecha</th>
                        <th>Equipo</th>
                        <th>Problema</th>
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
                <td><asp:Literal ID="Eqipo" runat="server" Text='<%# Eval("Equipo.Nombre") %>'></asp:Literal></td>
                <td><asp:Literal ID="Descripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Literal></td>
                <td><asp:Literal ID="Estado" runat="server" Text='<%# Eval("Estado") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="ver" runat="server" NavigateUrl='<%# Eval("Id","IncidenciaView.aspx?Id={0}") %>' Text="Ver"></asp:HyperLink></td>
                <td><asp:Button ID="eliminar" runat="server" CssClass="btnEliminar" Text="Eliminar"  OnClientClick="if(!confirm('¿Esta seguro de eliminar la incidencia?')){return false;};" OnCommand="Eliminar_Click" CommandArgument='<%# Eval("Id") %>'/></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
