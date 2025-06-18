<%@ Page Title="Editar Mascota" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarMascota.aspx.cs" Inherits="tpcuatrimestral.Vistas.EditarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600&display=swap" rel="stylesheet">
    <link href="../Estilos/FormsEstilo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Editar Mascota</h2>
        
        <p>
            <label for="<%= TxtNombre.ClientID %>">Nombre</label>
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </p>
        
        <p>
            <label for="<%= TxtPeso.ClientID %>">Peso (kg)</label>
            <asp:TextBox ID="TxtPeso" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </p>
        
        <!-- Agrega aquí más campos si son necesarios -->
        
        <p>
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar Cambios" Class="btn btn-primary" />
            <asp:HyperLink ID="HlCancelar" runat="server" NavigateUrl="~/Vistas/ListaMascotas.aspx" CssClass="btn-cancelar">Cancelar</asp:HyperLink>
        </p>
    </div>
</asp:Content>