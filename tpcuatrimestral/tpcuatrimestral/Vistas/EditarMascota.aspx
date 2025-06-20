<%@ Page Title="Editar Mascota" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditarMascota.aspx.cs" 
    Inherits="tpcuatrimestral.Vistas.EditarMascota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Editar Mascota</h2>
        
        <div class="form-group">
            <asp:Label AssociatedControlID="txtNombre" runat="server">Nombre:</asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlSexo" runat="server">Sexo:</asp:Label>
            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione..." Value="" />
                <asp:ListItem Text="Macho" Value="Macho" />
                <asp:ListItem Text="Hembra" Value="Hembra" />
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Label AssociatedControlID="txtPeso" runat="server">Peso (kg):</asp:Label>
            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" TextMode="Number" step="0.1"></asp:TextBox>
        </div>
        
        <div class="form-actions">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:HyperLink ID="hlCancelar" runat="server" NavigateUrl="~/Vistas/Mascotas.aspx" CssClass="btn btn-default">Cancelar</asp:HyperLink>
        </div>
    </div>
</asp:Content>