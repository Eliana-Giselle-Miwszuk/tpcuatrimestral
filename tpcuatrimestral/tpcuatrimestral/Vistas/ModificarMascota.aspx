<%@ Page Title="Editar Mascota" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditarMascota.aspx.cs" 
    Inherits="tpcuatrimestral.Vistas.EditarMascota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4" style="max-width: 500px;">
        <h2>Editar Mascota</h2>
        
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="mb-3">
            <label class="form-label">Peso (kg)</label>
            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="d-flex justify-content-between">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="Mascotas.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>