<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarMascotas.aspx.cs" Inherits="tpcuatrimestral.Vistas.ListarMascotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:LinkButton ID="LktAgregarMascota" runat="server" Class="btn btn-primary" PostBackUrl="~/Vistas/Mascotas/AgregarMascota.aspx">Agregar Mascota</asp:LinkButton>
    </p>
    <p>
        <asp:TextBox ID="TxtFiltrarxNombre" runat="server"></asp:TextBox>
        <asp:Button ID="BtnAplicarFiltro" runat="server" Text="Aplicar" OnClick="BtnAplicarFiltro_Click" />
    </p>
    <p>
       <asp:GridView ID="gdMascotas" runat="server" AutoGenerateColumns="False" 
    OnRowCommand="gdMascotas_RowCommand" OnRowDeleting="gdMascotas_RowDeleting" 
    DataKeyNames="NroHistoriaClinica" CssClass="table table-bordered" AllowPaging="True" OnPageIndexChanging="gdMascotas_PageIndexChanging" PageSize="5" CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
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
           <FooterStyle BackColor="White" ForeColor="#333333" />
           <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="White" ForeColor="#333333" />
           <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
           <SortedAscendingCellStyle BackColor="#F7F7F7" />
           <SortedAscendingHeaderStyle BackColor="#487575" />
           <SortedDescendingCellStyle BackColor="#E5E5E5" />
           <SortedDescendingHeaderStyle BackColor="#275353" />
</asp:GridView>
    </p>
</asp:Content>