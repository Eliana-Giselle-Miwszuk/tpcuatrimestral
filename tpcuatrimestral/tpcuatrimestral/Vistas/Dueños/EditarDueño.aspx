<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDueño.aspx.cs" Inherits="tpcuatrimestral.Vistas.EditarDueño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Registro de dueño a editar"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:TextBox ID="txtApellido" runat="server" Height="37px" Width="211px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtNombre" runat="server" Height="37px" Width="211px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtDireccion" runat="server" Height="37px" Width="211px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtTelefono" runat="server" Height="37px" Width="211px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtEmail" runat="server" Height="37px" Width="211px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" Width="100px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
