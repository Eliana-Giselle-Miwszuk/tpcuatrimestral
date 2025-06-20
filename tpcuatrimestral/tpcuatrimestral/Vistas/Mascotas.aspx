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
        <asp:Button ID="BtnAplicarFiltro" runat="server" Text="Aplicar" OnClick="BtnAplicarFiltro_Click" />
    </p>
    <p>
       <asp:GridView ID="gdMascotas" runat="server" AutoGenerateColumns="False" 
    OnRowCommand="gdMascotas_RowCommand" OnRowDeleting="gdMascotas_RowDeleting" 
    DataKeyNames="NroHistoriaClinica" CssClass="table table-bordered">
    <Columns>
        <asp:BoundField DataField="NroHistoriaClinica" HeaderText="Historia Clínica" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
        <asp:BoundField DataField="Color" HeaderText="Color" />
        <asp:BoundField DataField="Peso" HeaderText="Peso" DataFormatString="{0:N2} kg" />
        <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" DataFormatString="{0:d}" />
        
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="BtnEditar" runat="server" Text="Editar" 
                    CommandName="Editar" CommandArgument='<%# Eval("NroHistoriaClinica") %>'
                    CssClass="btn btn-warning btn-sm" />
                    
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" 
                    CommandName="Delete" CommandArgument='<%# Eval("NroHistoriaClinica") %>'
                    CssClass="btn btn-danger btn-sm" 
                    OnClientClick="return confirm('¿Está seguro que desea eliminar esta mascota?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    </p>
</asp:Content>