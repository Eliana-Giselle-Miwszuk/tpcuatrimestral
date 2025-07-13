<%@ Page Title="Listado de Dueños" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="ListaDueño.aspx.cs" 
    Inherits="tpcuatrimestral.Vistas.ListaDueño" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-grid {
            border: none;
            border-radius: 10px;
            box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.1);
        }
        .table-header-custom {
            background-color: #4e73df;
            color: white;
        }
        .table > :not(:first-child) {
            border-top: none;
        }
        .btn-action {
            min-width: 80px;
            margin: 2px;
        }
        .empty-grid {
            padding: 2rem;
            text-align: center;
            color: #6c757d;
            font-size: 1.1rem;
        }
        .pagination-custom .page-item.active .page-link {
            background-color: #4e73df;
            border-color: #4e73df;
        }
        .pagination-custom .page-link {
            color: #4e73df;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid py-4">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="h4 mb-0 text-gray-800 font-weight-bold">
                <i class="fas fa-users fa-fw mr-2"></i>Listado de Dueños
            </h2>
            <asp:LinkButton ID="lbkCrear" runat="server" 
                PostBackUrl="~/Vistas/Dueños/AgregarDueño.aspx" 
                CssClass="btn btn-primary btn-icon-split">
                <span class="icon text-white-50">
                    <i class="fas fa-plus"></i>
                </span>
                <span class="text">Nuevo Dueño</span>
            </asp:LinkButton>
        </div>

        <div class="card shadow mb-4 card-grid">
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="dgvDueños" runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="Dni"
                        CssClass="table table-hover"
                        GridLines="None"
                        OnRowCommand="dgvDueños_RowCommand" 
                        AllowPaging="True" 
                        OnPageIndexChanging="dgvDueños_PageIndexChanging" 
                        PageSize="5"
                        PagerStyle-CssClass="pagination-custom"
                        HeaderStyle-CssClass="table-header-custom">
                        
                        <Columns>
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Dni" HeaderText="DNI" DataFormatString="{0:0}" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" DataFormatString="{0:0}" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />

                            <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="text-nowrap">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditar" runat="server"
                                        CommandName="Editar"
                                        CommandArgument='<%# Eval("Dni") %>'
                                        CssClass="btn btn-warning btn-sm btn-action"
                                        ToolTip="Editar">
                                        <i class="fas fa-edit"></i> Editar
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnEliminar" runat="server"
                                        CommandName="Eliminar"
                                        CommandArgument='<%# Eval("Dni") %>'
                                        CssClass="btn btn-danger btn-sm btn-action"
                                        OnClientClick="return confirm('¿Estás seguro de eliminar este dueño?');"
                                        ToolTip="Eliminar">
                                        <i class="fas fa-trash-alt"></i> Eliminar
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <EmptyDataTemplate>
                            <div class="empty-grid">
                                <i class="fas fa-info-circle fa-2x mb-3"></i>
                                <h5 class="text-gray-800">No se encontraron dueños registrados</h5>
                                <p class="mb-0">Utilice el botón "Nuevo Dueño" para agregar uno</p>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>