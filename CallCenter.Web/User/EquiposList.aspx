<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EquiposList.aspx.cs" Inherits="CallCenter.Web.User.EquiposList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Añadir un nuevo equipo</h2>
    <table>
        <tr>
            <td>Nombre</td>
            <td><asp:TextBox ID="Nombre_nuevo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descripci&oacute;n</td>
            <td><textarea id="Descripcion_nuevo" runat="server" cols="20" rows="2" ></textarea></td>
        </tr>
        <tr>
            <td>Tipo de Equipo</td>
            <td>
                <asp:DropDownList ID="Listatipo" runat="server"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Button ID="guardar" runat="server" Text="Guardar" OnClick="Guardar_Click" />
    <br />
    <asp:Label ID="Result" runat="server"></asp:Label>
    <h1>Mis Equipos</h1>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Descripci&oacute;n</th>
                        <th>Tipo</th>
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
                <td><asp:Literal ID="Nombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Literal></td>
                <td><asp:Literal ID="Descripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Literal></td>
                <td><asp:Literal ID="Tipo" runat="server" Text='<%# Eval("Tipo.Nombre") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="edit" runat="server" NavigateUrl='<%# Eval("Id","EquipoEdit.aspx?Id={0}") %>' Text="Editar"></asp:HyperLink></td>
                <td><asp:Button ID="eliminar" runat="server" Text="Eliminar"  OnClientClick="if(!confirm('¿Esta seguro de eliminar el tipo de equipo?')){return false;};" OnCommand="Eliminar_Click" CommandArgument='<%# Eval("Id") %>'/></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
