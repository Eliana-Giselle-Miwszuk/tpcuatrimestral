<%@ Page Title="Agregar Historia Clínica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarHC.aspx.cs" Inherits="tpcuatrimestral.Vistas.AgregarHC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600&display=swap" rel="stylesheet">
    <link href="../Estilos/FormsEstilo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Nueva Historia Clínica</h2>
        
        <div class="form-group">
            <label>Número de Historia Clínica</label>
            <asp:DropDownList ID="DdlNroHistoriaClinica" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DdlNroHistoriaClinica_SelectedIndexChanged">
                <asp:ListItem Text="Seleccione una historia clínica" Value="" Selected="True" />
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label>Turno</label>
            <asp:DropDownList ID="DdlTurno" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione un turno" Value="" Selected="True" />
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label>Fecha y Hora de Cita</label>
            <asp:TextBox ID="TxtFechaHoraCita" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label>Síntomas</label>
            <asp:TextBox ID="TextSintomas" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label>Diagnóstico</label>
            <asp:TextBox ID="TextDiagnostico" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label>Tratamiento</label>
            <asp:TextBox ID="TextTratamiento" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label>Medicación</label>
            <asp:TextBox ID="TextMedicacion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label>Observaciones</label>
            <asp:TextBox ID="TextObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
        </div>
        
        <div class="form-actions">
            <asp:Button ID="BtnGuardar" runat="server" Class="btn btn-primary" Text="Guardar Historia Clínica" OnClick="BtnGuardar_Click" />
            <asp:HyperLink ID="HlCancelar" runat="server" NavigateUrl="~/Vistas/HistoriasClinicas.aspx" CssClass="btn-cancelar">Cancelar</asp:HyperLink>
        </div>
    </div>
</asp:Content>