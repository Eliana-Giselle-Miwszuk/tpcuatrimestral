<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarVeterinarios.aspx.cs" Inherits="tpcuatrimestral.Vistas.ListarVeterinarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#3333CC" Text="Gestion Veterinarios"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="lkbAgregar" runat="server" Class="btn btn-primary" PostBackUrl="~/Vistas/Veterinarios/AgregarVeterinarios.aspx" Height="30px" Width="131px">Agregar</asp:LinkButton>
    </p>
    <asp:TextBox ID="txtNombre" runat="server" placeholder="Ingrese Nombre" Height="38px" Width="179px"></asp:TextBox>
    <asp:Button ID="btnBuscarNombre" runat="server" Class="btn btn-success" Height="43px" Text="Aplicar" Width="84px" OnClick="btnBuscarNombre_Click" />
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#009900"></asp:Label>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="gvVeterinarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
    OnRowCommand="gvVeterinarios_RowCommand" OnRowDeleting="gvVeterinarios_RowDeleting" 
    DataKeyNames="IDVeterinario" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvVeterinarios_PageIndexChanging">
    <Columns>
        <asp:BoundField DataField="Dni" HeaderText="DNI" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="MatriculaNacional" HeaderText="Matrícula Nacional" />
        <asp:BoundField DataField="Activo" HeaderText="Estado" />
        

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" 
                    CommandArgument='<%# Eval("IDVeterinario") %>' CssClass="btn btn-primary btn-sm" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" 
                    CommandArgument='<%# Eval("IDVeterinario") %>' CssClass="btn btn-danger btn-sm" 
                    OnClientClick="return confirm('¿Está seguro que desea eliminar este veterinario?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="pagination" />
</asp:GridView>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
