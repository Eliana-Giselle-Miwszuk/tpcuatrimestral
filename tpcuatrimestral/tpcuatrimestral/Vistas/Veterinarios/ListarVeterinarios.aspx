<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarVeterinarios.aspx.cs" Inherits="tpcuatrimestral.Vistas.ListarVeterinarios" %>
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
        .estado-checkbox {
            transform: scale(1.3);
            cursor: default;
        }
        .table td {
            vertical-align: middle !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid py-4">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="h4 mb-0 text-gray-800 font-weight-bold">
                <i class="fas fa-user-md fa-fw mr-2"></i>Gestión de Veterinarios
            </h2>
            <asp:LinkButton ID="lkbAgregar" runat="server" 
                PostBackUrl="~/Vistas/Veterinarios/AgregarVeterinarios.aspx" 
                CssClass="btn btn-primary btn-icon-split">
                <span class="icon text-white-50">
                    <i class="fas fa-plus"></i>
                </span>
                <span class="text">Nuevo Veterinario</span>
            </asp:LinkButton>
        </div>

        <div class="card shadow mb-4 card-grid">
            <div class="card-body">
                <div class="search-container">
                    <asp:TextBox ID="txtNombre" runat="server" 
                        CssClass="form-control" 
                        placeholder="Filtrar por nombre..."
                        Height="38px"></asp:TextBox>
                    <asp:Button ID="btnBuscarNombre" runat="server" 
                        Text="Buscar" 
                        OnClick="btnBuscarNombre_Click"
                        CssClass="btn btn-primary"
                        Height="43px" />
                </div>
                
                <asp:Label ID="lblMensaje" runat="server" CssClass="alert d-block mb-3"></asp:Label>
                
                <div class="table-responsive">
                    <asp:GridView ID="gvVeterinarios" runat="server" 
                        AutoGenerateColumns="false" 
                        OnRowCommand="gvVeterinarios_RowCommand" 
                        OnRowDeleting="gvVeterinarios_RowDeleting" 
                        DataKeyNames="IDVeterinario" 
                        CssClass="table table-hover"
                        AllowPaging="true" 
                        PageSize="10"
                        OnPageIndexChanging="gvVeterinarios_PageIndexChanging"
                        PagerStyle-CssClass="pagination-custom"
                        HeaderStyle-CssClass="table-header-custom"
                        GridLines="None">
                        
                        <Columns>
                            <asp:BoundField DataField="Dni" HeaderText="DNI" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="MatriculaNacional" HeaderText="Matrícula Nacional" />
                            <asp:BoundField DataField="MatriculaProvincial" HeaderText="MatriculaProvincial" />
                            
                            <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActivo" runat="server" 
                                        Checked='<%# Convert.ToBoolean(Eval("Activo")) %>' 
                                        Enabled="false"
                                        CssClass="estado-checkbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="text-nowrap">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditar" runat="server"
                                        CommandName="Editar"
                                        CommandArgument='<%# Eval("IDVeterinario") %>'
                                        CssClass="btn btn-warning btn-sm btn-action"
                                        ToolTip="Editar">
                                        <i class="fas fa-edit"></i> Editar
                                    </asp:LinkButton>
                                    
                                    <asp:LinkButton ID="btnEliminar" runat="server"
                                        CommandName="Eliminar"
                                        CommandArgument='<%# Eval("IDVeterinario") %>'
                                        CssClass="btn btn-danger btn-sm btn-action"
                                        OnClientClick="return confirm('¿Está seguro que desea eliminar este veterinario?');"
                                        ToolTip="Eliminar">
                                        <i class="fas fa-trash-alt"></i> Eliminar
                                    </asp:LinkButton>
                                    
                                    <asp:LinkButton ID="btnAgenda" runat="server"
                                        CommandName="Agenda"
                                        CommandArgument='<%# Eval("IDVeterinario") %>'
                                        CssClass="btn btn-info btn-sm btn-action"
                                        ToolTip="Agenda">
                                        <i class="fas fa-calendar-alt"></i> Editar Agenda
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnGenerarAgenda" runat="server"
                                        CommandName="GenerarAgenda"
                                        CommandArgument='<%# Eval("IDVeterinario") %>'
                                        CssClass="btn btn-success btn-sm btn-action"
                                        OnClientClick="return confirm('¿Generar agenda básica para este veterinario?');"
                                        ToolTip="Generar Agenda Básica"><i class="fas fa-calendar-plus"></i> Generar Agenda</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <EmptyDataTemplate>
                            <div class="empty-grid">
                                <i class="fas fa-info-circle fa-2x mb-3"></i>
                                <h5 class="text-gray-800">No se encontraron veterinarios registrados</h5>
                                <p class="mb-0">Utilice el botón "Nuevo Veterinario" para agregar uno</p>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>