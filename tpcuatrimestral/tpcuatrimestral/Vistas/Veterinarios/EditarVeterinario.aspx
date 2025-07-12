<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarVeterinario.aspx.cs" Inherits="tpcuatrimestral.Vistas.EditarVeterinario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:TextBox ID="txtDni" runat="server" placeholder="DNI" Height="44px" Width="222px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtApellido" runat="server" placeholder="apellido" Height="44px" Width="222px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtNombre" runat="server" placeholder="nombre" Height="44px" Width="222px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion" Height="44px" Width="222px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtTelefono" runat="server" placeholder="telefono" Height="44px" Width="222px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Height="44px" Width="222px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtMatriculaNacional" runat="server" placeholder="Matricula Nacional" Height="44px" Width="222px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtMatriculaProvincial" runat="server" placeholder="Matricula Provincial" Height="44px" Width="222px"></asp:TextBox>
    </p>
     <p>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="122px" Width="245px">
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAplicar" runat="server" CssClass="btn btn-success" Text="Aplicar" Width="121px" Height="36px" OnClick="btnAplicar_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#FF6600"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
