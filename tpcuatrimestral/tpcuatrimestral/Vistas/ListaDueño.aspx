<%@ Page Title="Listado de Dueños" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="ListaDueño.aspx.cs" 
    Inherits="tpcuatrimestral.Vistas.ListaDueño" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .grid-view {
            width: 100%;
            margin-top: 20px;
        }
        .grid-view th {
            background-color: #f8f9fa;
            text-align: left;
            padding: 8px;
        }
        .grid-view td {
            padding: 8px;
            border-bottom: 1px solid #dee2e6;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Listado de Dueños Activos</h2>
        
        <asp:GridView ID="dgvDueños" runat="server" CssClass="grid-view table" 
            AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:BoundField DataField="Dni" HeaderText="DNI" DataFormatString="{0:0}" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" DataFormatString="{0:0}" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" 
                    DataFormatString="{0:dd/MM/yyyy}" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />
            </Columns>
            <EmptyDataTemplate>
                <div class="alert alert-info">No se encontraron dueños registrados</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>