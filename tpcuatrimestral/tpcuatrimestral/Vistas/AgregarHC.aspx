<%@ Page Title="Agregar Historia Clínica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarHC.aspx.cs" Inherits="tpcuatrimestral.Vistas.AgregarHC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600&display=swap" rel="stylesheet">
    <link href="../Estilos/FormsEstilo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Nueva Historia Clínica</h2>
        
        <p>
            <label for="<%= TextSintomas.ClientID %>">Síntomas</label>
            <asp:TextBox ID="TextSintomas" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </p>
        
        <p>
            <label for="<%= TextDiagnostico.ClientID %>">Diagnóstico</label>
            <asp:TextBox ID="TextDiagnostico" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </p>
        
        <p>
            <label for="<%= TextTratamiento.ClientID %>">Tratamiento</label>
            <asp:TextBox ID="TextTratamiento" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </p>
        
        <p>
            <label for="<%= TextMedicacion.ClientID %>">Medicación</label>
            <asp:TextBox ID="TextMedicacion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
        </p>
        
        <p>
            <label for="<%= TextObservaciones.ClientID %>">Observaciones</label>
            <asp:TextBox ID="TextObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
        </p>
        
        <div class="form-actions">
            <asp:Button ID="BtnGuardar" runat="server" Class="btn btn-primary" Text="Guardar Historia Clínica" />
            <asp:HyperLink ID="HlCancelar" runat="server" NavigateUrl="~/Vistas/ListaMascotas.aspx" CssClass="btn-cancelar">Cancelar</asp:HyperLink>
        </div>
    </div>
</asp:Content>