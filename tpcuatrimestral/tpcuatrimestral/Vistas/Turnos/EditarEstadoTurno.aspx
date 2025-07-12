<%@ Page Title="Editar Estado Turno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEstadoTurno.aspx.cs" Inherits="tpcuatrimestral.Vistas.Turnos.EditarEstadoTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Editar Estado Turno
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 500px;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-container">
            <h2 class="text-center mb-4">Editar Estado del Turno</h2>
            
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
            
            <div class="form-group">
                <label>ID Turno:</label>
                <asp:TextBox ID="txtIdTurno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label>Estado del Turno:</label>
                <asp:DropDownList ID="ddlEstadoTurno" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            
            <div class="text-center mt-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" 
                    CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>