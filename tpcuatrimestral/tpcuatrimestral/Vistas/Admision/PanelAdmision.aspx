<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmision.aspx.cs" Inherits="tpcuatrimestral.Vistas.Admision.PanelAdmision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Panel de Admisión
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .badge-en-espera { background-color: #ffc107; color: #000; }
        .badge-en-curso { background-color: #0dcaf0; color: #000; }
        .badge-atendido { background-color: #198754; color: #fff; }
        .badge-cancelado { background-color: #dc3545; color: #fff; }
        .btn-action { min-width: 110px; }
        .btn-action i { margin-right: 5px; }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Panel de Admisión</h2>
        
        <!-- Filtros -->
        <div class="card shadow mb-4">
            <div class="card-header bg-light">
                <h5 class="mb-0">Filtros</h5>
            </div>
            <div class="card-body">
                <div class="row g-3">
                    <div class="col-md-4">
                        <label class="form-label">Fecha</label>
                        <asp:TextBox ID="txtFiltroFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Estado</label>
                        <asp:DropDownList ID="ddlFiltroEstado" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0" Text="Todos" Selected="True" />
                            <asp:ListItem Value="1" Text="En espera" />
                            <asp:ListItem Value="2" Text="En curso" />
                            <asp:ListItem Value="3" Text="Atendido" />
                            <asp:ListItem Value="4" Text="Cancelado" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Veterinario</label>
                        <asp:DropDownList ID="ddlFiltroVeterinario" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0" Text="Todos" Selected="True" />
                            <asp:ListItem Value="1" Text="Dr. Juan Pérez" />
                            <asp:ListItem Value="2" Text="Dra. María Gómez" />
                            <asp:ListItem Value="3" Text="Dr. Carlos López" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-12">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary me-2" />
                        <asp:Button ID="btnLimpiarFiltros" runat="server" Text="Limpiar" CssClass="btn btn-outline-secondary" />
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Grilla de Turnos con datos de ejemplo -->
        <div class="card shadow">
            <div class="card-header bg-light d-flex justify-content-between align-items-center">
                <h5 class="mb-0">Listado de Turnos</h5>
              <asp:HyperLink ID="btnNuevoTurno" runat="server" CssClass="btn btn-success" NavigateUrl="~/Vistas/Admision/NuevoTurno.aspx">
                    <i class="fas fa-plus me-1"></i> Nuevo Turno
              </asp:HyperLink>

            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Fecha y Hora</th>
                                <th>HC</th>
                                <th>Veterinario</th>
                                <th>Motivo</th>
                                <th>Estado</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Turno 1 - En espera (IdEstadoTurno = 1) -->
                            <tr>
                                <td>1</td>
                                <td>15/06/2024 10:00</td>
                                <td>1254</td>
                                <td>Dr. Juan Pérez</td>
                                <td>Control anual</td>
                                <td><span class="badge badge-en-espera">En espera</span></td>
                                <td>
                                    <div class="d-flex flex-wrap gap-2">

                                        <asp:LinkButton ID="btnIniciar1" runat="server"
                                            CssClass="btn btn-sm btn-primary btn-action"
                                            PostBackUrl="~/Vistas/Admision/InicioTurno.aspx?id=123">
                                            <i class="fas fa-play"></i> Iniciar
                                        </asp:LinkButton>


                                        <asp:LinkButton ID="btnCancelar1" runat="server" CssClass="btn btn-sm btn-danger btn-action" CommandArgument="1">
                                            <i class="fas fa-times"></i> Cancelar
                                        </asp:LinkButton>
                                        <asp:HyperLink ID="btnEditar1" runat="server" NavigateUrl="~/Vistas/Turnos/EditarTurno.aspx?id=1" CssClass="btn btn-sm btn-warning btn-action">
                                            <i class="fas fa-edit"></i> Editar
                                        </asp:HyperLink>
                                    </div>
                                </td>
                            </tr>
                            
                            <!-- Turno 2 - En curso (IdEstadoTurno = 2) -->
                            <tr>
                                <td>2</td>
                                <td>15/06/2024 11:30</td>
                                <td>1892</td>
                                <td>Dra. María Gómez</td>
                                <td>Vacunación antirrábica</td>
                                <td><span class="badge badge-en-curso">En curso</span></td>
                                <td>
                                    <div class="d-flex flex-wrap gap-2">
                                        <asp:LinkButton ID="btnFinalizar2" runat="server" CssClass="btn btn-sm btn-success btn-action" CommandArgument="2">
                                            <i class="fas fa-check"></i> Finalizar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnCancelar2" runat="server" CssClass="btn btn-sm btn-danger btn-action" CommandArgument="2">
                                            <i class="fas fa-times"></i> Cancelar
                                        </asp:LinkButton>
                                        <asp:HyperLink ID="btnEditar2" runat="server" NavigateUrl="~/Vistas/Turnos/EditarTurno.aspx?id=2" CssClass="btn btn-sm btn-warning btn-action">
                                            <i class="fas fa-edit"></i> Editar
                                        </asp:HyperLink>
                                    </div>
                                </td>
                            </tr>
                            
                            <!-- Turno 3 - Atendido (IdEstadoTurno = 3) -->
                            <tr>
                                <td>3</td>
                                <td>14/06/2024 09:15</td>
                                <td>1567</td>
                                <td>Dr. Carlos López</td>
                                <td>Dolor abdominal</td>
                                <td><span class="badge badge-atendido">Atendido</span></td>
                                <td>
                                    <div class="d-flex flex-wrap gap-2">
                                        <asp:HyperLink ID="btnEditar3" runat="server" NavigateUrl="~/Vistas/Turnos/EditarTurno.aspx?id=3" CssClass="btn btn-sm btn-warning btn-action">
                                            <i class="fas fa-edit"></i> Editar
                                        </asp:HyperLink>
                                        <asp:LinkButton ID="btnInforme3" runat="server" CssClass="btn btn-sm btn-secondary btn-action" CommandArgument="3">
                                            <i class="fas fa-file-alt"></i> Informe
                                        </asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            
                            <!-- Turno 4 - Cancelado (IdEstadoTurno = 4) -->
                            <tr>
                                <td>4</td>
                                <td>14/06/2024 16:00</td>
                                <td>1345</td>
                                <td>Dr. Juan Pérez</td>
                                <td>Castración</td>
                                <td><span class="badge badge-cancelado">Cancelado</span></td>
                                <td>
                                    <div class="d-flex flex-wrap gap-2">
                                        <asp:HyperLink ID="btnEditar4" runat="server" NavigateUrl="~/Vistas/Turnos/EditarTurno.aspx?id=4" CssClass="btn btn-sm btn-warning btn-action">
                                            <i class="fas fa-edit"></i> Editar
                                        </asp:HyperLink>
                                        <asp:LinkButton ID="btnReagendar4" runat="server" CssClass="btn btn-sm btn-info btn-action" CommandArgument="4">
                                            <i class="fas fa-calendar-alt"></i> Reagendar
                                        </asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                
                <!-- Leyenda de Estados -->
                <div class="mt-4 p-3 bg-light rounded">
                    <h6><i class="fas fa-info-circle me-2"></i>Leyenda de Estados (IdEstadoTurno):</h6>
                    <div class="d-flex flex-wrap gap-3 mt-2">
                        <span class="badge badge-en-espera">1 - En espera</span>
                        <span class="badge badge-en-curso">2 - En curso</span>
                        <span class="badge badge-atendido">3 - Atendido</span>
                        <span class="badge badge-cancelado">4 - Cancelado</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>