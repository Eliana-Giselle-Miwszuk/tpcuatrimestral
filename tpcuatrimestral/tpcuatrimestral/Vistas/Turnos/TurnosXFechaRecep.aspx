<%@ Page Title="Turnos por Fecha - Recepción" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnosXFechaRecep.aspx.cs" Inherits="tpcuatrimestral.Vistas.Turnos.TurnosXFechaRecep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Turnos por Fecha - Recepción
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .grid-view {
            width: 100%;
            margin-top: 20px;
        }
        .grid-view th {
            background-color: #343a40;
            color: white;
        }
        .btn-editar {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Turnos para el día: <asp:Label ID="lblFecha" runat="server" Font-Bold="true"></asp:Label></h2>
        
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        
        <asp:GridView ID="gridXfecha" runat="server" CssClass="grid-view table-striped table-bordered"
            AutoGenerateColumns="false" OnRowCommand="gridXfecha_RowCommand">
            <Columns>
                <asp:BoundField DataField="IdTurno" HeaderText="ID" ItemStyle-Width="50px" />
                <asp:BoundField DataField="FechaHoraTurno" HeaderText="Fecha/Hora" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-Width="120px" />
                <asp:BoundField DataField="MascotaNombre" HeaderText="Mascota" />
                <asp:BoundField DataField="VeterinarioNombre" HeaderText="Veterinario" />
                <asp:BoundField DataField="MotivoConsulta" HeaderText="Motivo" />
                <asp:BoundField DataField="EstadoTurnoDescripcion" HeaderText="Estado Actual" />
                
                <asp:TemplateField HeaderText="Acción" ItemStyle-Width="120px">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarEstado" runat="server" Text="Editar Estado" 
                            CssClass="btn btn-warning btn-sm btn-editar" 
                            CommandName="EditarEstado" 
                            CommandArgument='<%# Eval("IdTurno") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No hay turnos programados para esta fecha.
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>