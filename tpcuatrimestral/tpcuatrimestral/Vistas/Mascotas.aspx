<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mascotas.aspx.cs" Inherits="tpcuatrimestral.Vistas.Mascotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:LinkButton ID="LktAgregarMascota" runat="server" Class="btn btn-primary" PostBackUrl="~/Vistas/AgregarMascota.aspx">Agregar Mascota</asp:LinkButton>
    </p>
    <p>
        <asp:TextBox ID="TxtFiltrarxNombre" runat="server"></asp:TextBox>
        <asp:Button ID="BtnAplicarFiltro" runat="server" Text="Aplicar" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
