﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="TipoEquipoList.aspx.cs" Inherits="CallCenter.Web.Admin.TipoEquipoList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Agregar un nuevo tipo de equipo</h2>
    <table>
        <tr>
            <td>Nombre:</td>
            <td><asp:TextBox ID="Nombre_nuevo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descripci&oacute;n</td>
            <td><textarea id="Descripcion_nuevo" cols="20" rows="2" runat="server"></textarea></td>
        </tr>
    </table>
    <asp:Button ID="Guardar" runat="server" CssClass="btnGuardar" Text="Guardar" OnClick="Guardar_Click" />
    <br />
    <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    <h1>Listado de Tipos de Equipo</h1>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table class="itemsTable">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Descripci&oacute;n</th>
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
                <td><asp:Literal ID="Name" runat="server" Text='<%# Eval("Nombre") %>'></asp:Literal></td>
                <td><asp:Literal ID="Descripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="edit" runat="server" NavigateUrl='<%# Eval("Id","TipoEquipoEdit.aspx?Id={0}") %>' Text="Editar"></asp:HyperLink></td>
                <td><asp:Button ID="Eliminar" runat="server" CssClass="btnEliminar" Text="Eliminar" OnClientClick="if(!confirm('¿Esta seguro de eliminar el tipo de equipo?')){return false;};" OnCommand="Eliminar_Click" CommandArgument='<%# Eval("Id") %>'/></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
