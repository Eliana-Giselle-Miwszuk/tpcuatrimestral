<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarVeterinarios.aspx.cs" Inherits="tpcuatrimestral.Vistas.ListaVeterinarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#3333CC" Text="Gestion Veterinarios"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtDni" runat="server" placeholder="DNI" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtApellido" runat="server" placeholder="apellido" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtNombre" runat="server" placeholder="nombre" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtTelefono" runat="server" placeholder="telefono" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtMatriculaNacional" runat="server" placeholder="Matricula Nacional" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtMatriculaProvincial" runat="server" placeholder="Matricula Provincial" Height="33px" Width="191px"></asp:TextBox>
    </p>
    <p>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="40px" Width="203px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:DropDownList ID="ddlIdUsuario" runat="server" Height="40px" Width="203px">
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <asp:Button ID="btnGuardar" runat="server" Height="36px" Class="btn btn-primary" Text="Guardar" Width="167px" OnClick="btnGuardar_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblCartel" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#009900"></asp:Label>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
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
