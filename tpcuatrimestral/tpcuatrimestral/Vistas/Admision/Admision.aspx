<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admision.aspx.cs" Inherits="tpcuatrimestral.Vistas.Admision.Admision1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Administración de Admisionistas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .grid-view {
            margin-top: 20px;
        }
        .filter-container {
            margin-bottom: 15px;
        }
        .action-buttons .btn {
            margin: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Administración de Admisionistas</h2>
        
        <div class="row mb-3">
            <div class="col-md-6">
                <asp:LinkButton ID="LktAgregarAdmisionista" runat="server" 
                    CssClass="btn btn-primary" 
                    PostBackUrl="~/Vistas/Admision/AgregarAdmisionista.aspx">
                    <i class="fas fa-user-plus"></i> Agregar Admisionista
                </asp:LinkButton>
            </div>
        </div>

        <div class="row filter-container">
            <div class="col-md-6">
                <div class="input-group">
                    <asp:TextBox ID="TxtFiltrar" runat="server" 
                        CssClass="form-control" 
                        placeholder="Filtrar por nombre, apellido o DNI"></asp:TextBox>
                    <asp:Button ID="BtnFiltrar" runat="server" 
                        Text="Buscar" 
                        CssClass="btn btn-outline-secondary"
                        OnClick="BtnFiltrar_Click" />
                    <asp:Button ID="BtnLimpiar" runat="server" 
                        Text="Limpiar" 
                        CssClass="btn btn-outline-danger"
                        OnClick="BtnLimpiar_Click" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvAdmisionistas" runat="server" 
                    AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered grid-view"
                    OnRowCommand="dgvAdmisionistas_RowCommand" 
                    OnRowDataBound="dgvAdmisionistas_RowDataBound"
                    DataKeyNames="IDAdmisionista" 
                    EmptyDataText="No se encontraron admisionistas"
                    AllowPaging="True" 
                    PageSize="10"
                    OnPageIndexChanging="dgvAdmisionistas_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="IDAdmisionista" HeaderText="ID" ItemStyle-Width="5%" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" ItemStyle-Width="15%" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="15%" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="20%" />
                        <asp:TemplateField HeaderText="Estado" ItemStyle-Width="8%">
                            <ItemTemplate>
                                <span class='<%# (bool)Eval("Activo") ? "badge bg-success" : "badge bg-danger" %>'>
                                    <%# (bool)Eval("Activo") ? "Activo" : "Inactivo" %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="10%" />
                        
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="15%" ItemStyle-CssClass="action-buttons">
                            <ItemTemplate>
                                <asp:LinkButton ID="BtnEditar" runat="server" 
                                    CommandName="Editar" 
                                    CommandArgument='<%# Eval("IDAdmisionista") %>'
                                    CssClass="btn btn-sm btn-warning" 
                                    ToolTip="Editar">
                                    <i class="fas fa-edit">Editar</i>
                                </asp:LinkButton>
                                
                                <asp:LinkButton ID="BtnEliminar" runat="server" 
                                    CommandName="Eliminar" 
                                    CommandArgument='<%# Eval("IDAdmisionista") %>'
                                    CssClass="btn btn-sm btn-danger" 
                                    ToolTip="Eliminar"
                                    OnClientClick="return confirm('¿Está seguro que desea eliminar este admisionista?');">
                                    <i class="fas fa-trash-alt">Eliminar</i>
                                </asp:LinkButton>
                         
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="grid-pager" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="table-header" />
                    <RowStyle CssClass="table-row" />
                    <AlternatingRowStyle CssClass="table-alt-row" />
                    <EmptyDataRowStyle CssClass="text-center" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>