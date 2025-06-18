<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMascota.aspx.cs" Inherits="tpcuatrimestral.Vistas.AgregarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600&display=swap" rel="stylesheet">
    <link href="../Estilos/FormsEstilo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <p>
            <asp:Label ID="LblAgregarMascota" runat="server" Font-Bold="True" Font-Size="Larger" Text="Agregar Mascota"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="DdlDueño" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione un dueño" Value="" Selected="True" />
            </asp:DropDownList>
        </p>
        <p>
            <asp:DropDownList ID="DdlRaza" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione una raza" Value="" Selected="True" />
            </asp:DropDownList>
        </p>
        <p>
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Nombre de la mascota"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="TextSexo" runat="server" CssClass="form-control" placeholder="Sexo (Macho/Hembra)"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="TextColor" runat="server" CssClass="form-control" placeholder="Color principal"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="TextPeso" runat="server" CssClass="form-control" placeholder="Peso en kg" TextMode="Number"></asp:TextBox>
        </p>
        <asp:Button ID="BtnGuardarMascota" runat="server" Class="btn btn-primary" Text="Guardar" />
    </div>
</asp:Content>