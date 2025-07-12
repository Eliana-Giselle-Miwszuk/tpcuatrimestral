<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnosXFechaVete.aspx.cs" Inherits="tpcuatrimestral.Vistas.Turnos.TurnosXFechaVete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Turnos para el día: <asp:Label ID="lblFecha" runat="server" Font-Bold="true"></asp:Label></h2>
    
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    
    <asp:GridView ID="gdvTurnoXFecha" runat="server" CssClass="table table-striped table-bordered" 
    AutoGenerateColumns="False" OnRowCommand="gvTurnos_RowCommand" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
    <Columns>
        <asp:BoundField DataField="FechaHoraTurno" HeaderText="Fecha y Hora" 
            DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="NroHistoriaClinica" HeaderText="HC N°" 
            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" >
<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="MascotaNombre" HeaderText="Mascota" />
        <asp:BoundField DataField="VeterinarioNombre" HeaderText="Veterinario" />
        <asp:BoundField DataField="MotivoConsulta" HeaderText="Motivo" />
        <asp:BoundField DataField="EstadoTurnoDescripcion" HeaderText="Estado" 
            ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Acción" ItemStyle-Width="120px">
            <ItemTemplate>
                <asp:Button ID="btnSeleccionarHC" runat="server" Text="Seleccionar HC" 
                    CssClass="btn btn-success btn-sm" 
                    CommandName="SeleccionarHC" 
                    CommandArgument='<%# Eval("NroHistoriaClinica") %>' />
            </ItemTemplate>

<ItemStyle Width="120px"></ItemStyle>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <div class="alert alert-info">
            No hay turnos programados para esta fecha.
        </div>
    </EmptyDataTemplate>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
</asp:GridView>
</asp:Content>
