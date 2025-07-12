<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTurno.aspx.cs" Inherits="tpcuatrimestral.Vistas.Turnos.AgregarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"> 

        <style type="text/css">
        .form-container {
            width: 90%;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f8f8f8;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .form-control {
            width: 100%;
            padding: 8px;
            border: 1px solid #ddd;
            box-sizing: border-box;
        }
        .btn {
            padding: 8px 15px;
            margin-right: 10px;
            border: none;
            cursor: pointer;
        }
        .btn-primary {
            background-color: #4CAF50;
            color: white;
        }
        .btn-secondary {
            background-color: #f0ad4e;
            color: white;
        }
        .btn-danger {
            background-color: #d9534f;
            color: white;
        }
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .grid-view th {
            background-color: #e7e7e7;
        }
        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="form-container">
        <h2>Registro de Turnos</h2>
        
        <div class="form-group">
            <asp:Label ID="lblIDTurno" runat="server" Text="ID Turno:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtIDTurno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblFechaHoraTurno" runat="server" Text="Fecha y Hora del Turno:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtFechaHoraTurno" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblNroHistoriaClinica" runat="server" Text="Número de Historia Clínica:" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlNroHistoriaClinica" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">HC-001</asp:ListItem>
                <asp:ListItem Value="2">HC-002</asp:ListItem>
                <asp:ListItem Value="3">HC-003</asp:ListItem>
                <asp:ListItem Value="4">HC-004</asp:ListItem>
                <asp:ListItem Value="5">HC-005</asp:ListItem>
                <asp:ListItem Value="6">HC-006</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblIDVeterinario" runat="server" Text="Veterinario:" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlIDVeterinario" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">Dr. Juan Pérez</asp:ListItem>
                <asp:ListItem Value="2">Dra. María Gómez</asp:ListItem>
                <asp:ListItem Value="3">Dr. Carlos López</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblMotivoConsulta" runat="server" Text="Motivo de Consulta:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtMotivoConsulta" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblIDEstadoTurno" runat="server" Text="Estado del Turno:" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlIDEstadoTurno" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">Pendiente</asp:ListItem>
                <asp:ListItem Value="2">Confirmado</asp:ListItem>
                <asp:ListItem Value="3">Cancelado</asp:ListItem>
                <asp:ListItem Value="4">Completado</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha de Registro:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblActivo" runat="server" Text="Activo:" CssClass="form-label"></asp:Label>
            <asp:CheckBox ID="chkActivo" runat="server" Checked="true" />
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" />
            <asp:HyperLink ID="lnkCancelar" runat="server" NavigateUrl="~/Vistas/Turnos/Turnos.aspx" CssClass="btn btn-secondary">Cancelar</asp:HyperLink>
        </div>
        
        
      </div>

</asp:Content>
