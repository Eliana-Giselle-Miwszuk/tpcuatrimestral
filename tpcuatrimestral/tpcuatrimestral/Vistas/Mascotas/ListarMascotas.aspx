<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarMascotas.aspx.cs" Inherits="tpcuatrimestral.Vistas.ListarMascotas" %>
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
        .search-container {
            display: flex;
            margin-bottom: 1rem;
        }
        .search-container .form-control {
            border-radius: 4px 0 0 4px;
        }
        .search-container .btn {
            border-radius: 0 4px 4px 0;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid py-4">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="h4 mb-0 text-gray-800 font-weight-bold">
                <i class="fas fa-paw fa-fw mr-2"></i>Listado de Mascotas
            </h2>
            <asp:LinkButton ID="LktAgregarMascota" runat="server" 
                PostBackUrl="~/Vistas/Mascotas/AgregarMascota.aspx" 
                CssClass="btn btn-primary btn-icon-split">
                <span class="icon text-white-50">
                    <i class="fas fa-plus"></i>
                </span>
                <span class="text">Nueva Mascota</span>
            </asp:LinkButton>
        </div>

        <div class="card shadow mb-4 card-grid">
            <div class="card-body">
                <div class="search-container">
                    <asp:TextBox ID="TxtFiltrarxNombre" runat="server" 
                        CssClass="form-control" 
                        placeholder="Filtrar por nombre..."></asp:TextBox>
                    <asp:Button ID="BtnAplicarFiltro" runat="server" 
                        Text="Buscar" 
                        OnClick="BtnAplicarFiltro_Click"
                        CssClass="btn btn-primary" />
                </div>
                
                <div class="table-responsive">
                    <asp:GridView ID="gdMascotas" runat="server" 
                        AutoGenerateColumns="False" 
                        OnRowCommand="gdMascotas_RowCommand" 
                        OnRowDeleting="gdMascotas_RowDeleting" 
                        DataKeyNames="NroHistoriaClinica" 
                        CssClass="table table-hover"
                        AllowPaging="True" 
                        OnPageIndexChanging="gdMascotas_PageIndexChanging" 
                        PageSize="5"
                        PagerStyle-CssClass="pagination-custom"
                        HeaderStyle-CssClass="table-header-custom"
                        GridLines="None">
                        
                        <Columns>
                            <asp:BoundField DataField="NroHistoriaClinica" HeaderText="Historia Clínica" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                            <asp:BoundField DataField="Color" HeaderText="Color" />
                            <asp:BoundField DataField="Peso" HeaderText="Peso" DataFormatString="{0:N2} kg" />
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" DataFormatString="{0:d}" />
                            
                            <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="text-nowrap">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnEditar" runat="server"
                                        CommandName="Editar"
                                        CommandArgument='<%# Eval("NroHistoriaClinica") %>'
                                        CssClass="btn btn-warning btn-sm btn-action"
                                        ToolTip="Editar">
                                        <i class="fas fa-edit"></i> Editar
                                    </asp:LinkButton>
                                    
                                    <asp:LinkButton ID="BtnEliminar" runat="server"
                                        CommandName="Delete"
                                        CommandArgument='<%# Eval("NroHistoriaClinica") %>'
                                        CssClass="btn btn-danger btn-sm btn-action"
                                        OnClientClick="return confirm('¿Está seguro que desea eliminar esta mascota?');"
                                        ToolTip="Eliminar">
                                        <i class="fas fa-trash-alt"></i> Eliminar
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <EmptyDataTemplate>
                            <div class="empty-grid">
                                <i class="fas fa-info-circle fa-2x mb-3"></i>
                                <h5 class="text-gray-800">No se encontraron mascotas registradas</h5>
                                <p class="mb-0">Utilice el botón "Nueva Mascota" para agregar una</p>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>