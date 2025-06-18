<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoriasClinicas.aspx.cs" Inherits="tpcuatrimestral.Vistas.HistoriasClinicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:LinkButton ID="lkbAgregarHC" Class="btn btn-primary" runat="server">AgregarHistoriaClinica</asp:LinkButton>
    </p>
    <p>
        <asp:TextBox ID="TxtFiltrarDiagnostico" PlaceHolder="Ingrese Diagnóstico" runat="server"></asp:TextBox>
        <asp:Button ID="BtnFiltrarDiagnostico" runat="server" class="btn btn-success" Height="29px" Text="Aplicar" />
    </p>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
