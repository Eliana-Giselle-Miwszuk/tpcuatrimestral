<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHC.aspx.cs" Inherits="tpcuatrimestral.Vistas.EditarHC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:TextBox ID="txtSintoma" runat="server" Width="187px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtDiagnostico" runat="server" Width="187px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtTratamiento" runat="server" Width="187px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="Medicacion" runat="server" Width="187px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtObervacion" runat="server" Width="187px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" Width="119px" />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
