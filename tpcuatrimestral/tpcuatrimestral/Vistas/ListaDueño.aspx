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
        <p class="mb-4">&nbsp;
            <asp:LinkButton ID="lbkCrear" Class="btn btn-primary"  runat="server" Height="20px" PostBackUrl="~/Vistas/AgregarDueño.aspx" Width="96px">Crear Dueño</asp:LinkButton>
        </p>
        <p class="mb-4">&nbsp;</p>
        <p class="mb-4">&nbsp;</p>
        <p class="mb-4">&nbsp;</p>
        
     <asp:GridView ID="dgvDueños" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="Dni"
    CssClass="grid-view table table-striped table-bordered"
    GridLines="None"
    OnRowCommand="dgvDueños_RowCommand">
    <Columns>
        <asp:BoundField DataField="Dni" HeaderText="DNI" DataFormatString="{0:0}" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" DataFormatString="{0:0}" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton ID="btnEditar" runat="server"
                    Text="Editar"
                    CommandName="Editar"
                    CommandArgument='<%# Eval("Dni") %>'
                    CssClass="btn btn-warning btn-sm" />

                <asp:LinkButton ID="btnEliminar" runat="server"
                    Text="Eliminar"
                    CommandName="Eliminar"
                    CommandArgument='<%# Eval("Dni") %>'
                    CssClass="btn btn-danger btn-sm"
                    OnClientClick="return confirm('¿Estás seguro de eliminar este dueño?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

    <EmptyDataTemplate>
        <div class="alert alert-info">No se encontraron dueños registrados</div>
    </EmptyDataTemplate>
</asp:GridView>


    </div>
</asp:Content>