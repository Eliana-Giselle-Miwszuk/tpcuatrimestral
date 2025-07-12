<%@ Page Title="Lista de Turnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Turnos.aspx.cs" Inherits="tpcuatrimestral.Vistas.Turnos.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Turnos - Sistema Veterinario
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .turnos-container {
            margin: 20px;
        }
        .btn-agregar {
            margin-bottom: 15px;
        }
        .grid-turnos {
            width: 100%;
        }
        .alert-empty {
            text-align: center;
            padding: 20px;
            background-color: #f8f9fa;
            border: 1px solid #dee2e6;
            border-radius: 4px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="turnos-container">
        <h2>Listado de Turnos</h2>
        
        <asp:HyperLink ID="lnkAgregarTurno" runat="server" 
            NavigateUrl="~/Vistas/Turnos/AgregarTurno.aspx" 
            CssClass="btn btn-primary btn-agregar">
            <i class="fas fa-plus"></i> Agregar Nuevo Turno
        </asp:HyperLink>

        <asp:GridView ID="dgvTurnos" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdTurno"
            CssClass="table table-striped table-bordered grid-turnos"
            GridLines="None"
            OnRowCommand="dgvTurnos_RowCommand" CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="FechaHoraTurno" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="FechaHoraTurno" HeaderText="Hora" DataFormatString="{0:HH:mm}" />
                <asp:BoundField DataField="MascotaNombre" HeaderText="Mascota" />
                <asp:BoundField DataField="NroHistoriaClinica" HeaderText="Historia Clínica" />
                <asp:BoundField DataField="VeterinarioNombre" HeaderText="Veterinario" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
                <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server"
                            CssClass="btn btn-sm btn-warning"
                            CommandName="Editar"
                            CommandArgument='<%# Eval("IdTurno") %>'>
                    <i class="fas fa-edit"></i> Editar
                        </asp:LinkButton>
                    </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <EmptyDataTemplate>
                <div class="alert-empty">No se encontraron turnos registrados</div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>