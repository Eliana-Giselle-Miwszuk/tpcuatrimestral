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
        .horarios-disponibles {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            margin-top: 10px;
        }
        .horario-btn {
            padding: 8px 12px;
            background-color: #e7e7e7;
            border: 1px solid #ddd;
            cursor: pointer;
        }
        .horario-btn:hover {
            background-color: #4CAF50;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Registro de Turnos</h2>
           <asp:Label ID="lblMensajeError" runat="server" Text="Veterinario:" CssClass="form-label"></asp:Label>
        <!-- Paso 1: Seleccionar fecha -->
        <div class="form-group">
            <asp:Label ID="lblFechaTurno" runat="server" Text="Fecha del Turno:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtFechaTurno" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtFechaTurno_TextChanged"></asp:TextBox>
        </div>
        
        <!-- Paso 2: Seleccionar veterinario (se llena dinámicamente) -->
        <div class="form-group" id="divVeterinarios" runat="server" visible="false">
            <asp:Label ID="lblVeterinario" runat="server" Text="Veterinario:" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlVeterinarios" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVeterinarios_SelectedIndexChanged"></asp:DropDownList>
        </div>
        
        <!-- Paso 3: Mostrar horarios disponibles -->
        <div class="form-group" id="divHorarios" runat="server" visible="false">
            <asp:Label ID="lblHorariosDisponibles" runat="server" Text="Horarios Disponibles:" CssClass="form-label"></asp:Label>
            <div class="horarios-disponibles" id="horariosContainer" runat="server">
                <!-- Los botones de horarios se generarán dinámicamente -->
            </div>
        </div>
        
        <!-- Resto del formulario (se muestra después de seleccionar horario) -->
        <div id="divFormularioCompleto" runat="server" visible="false">
            <div class="form-group">
                <asp:Label ID="lblIDTurno" runat="server" Text="ID Turno:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtIDTurno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <asp:Label ID="lblFechaHoraTurno" runat="server" Text="Fecha y Hora del Turno:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtFechaHoraTurnoSeleccionada" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <asp:Label ID="lblNroHistoriaClinica" runat="server" Text="Número de Historia Clínica:" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlNroHistoriaClinica" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            
            <div class="form-group">
                <asp:Label ID="lblMotivoConsulta" runat="server" Text="Motivo de Consulta:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtMotivoConsulta" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:HyperLink ID="lnkCancelar" runat="server" NavigateUrl="~/Vistas/Turnos/Turnos.aspx" CssClass="btn btn-secondary">Cancelar</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>