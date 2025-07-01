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
    <asp:GridView ID="gdHC" runat="server" AutoGenerateColumns="False" 
    CssClass="table table-striped table-bordered" 
    DataKeyNames="IDRegistro" 
    OnRowCommand="gdHC_RowCommand">
    <Columns>
        <asp:BoundField DataField="IDRegistro" HeaderText="Registro" />
        <asp:BoundField DataField="NroHistoriaClinica" HeaderText="Nro HC" />
        <asp:BoundField DataField="IDTurno" HeaderText="Turno" />
        <asp:BoundField DataField="FechaHoraCita" HeaderText="Fecha y Hora" DataFormatString="{0:g}" />
        <asp:BoundField DataField="Sintomas" HeaderText="Síntomas" />
        <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
        <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
        <asp:BoundField DataField="Medicacion" HeaderText="Medicación" />
        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" 
                    CommandArgument='<%# Eval("IDRegistro") %>' 
                    CssClass="btn btn-sm btn-warning">Editar</asp:LinkButton>
                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" 
                    CommandArgument='<%# Eval("IDRegistro") %>' 
                    CssClass="btn btn-sm btn-danger" 
                    OnClientClick="return confirm('¿Estás seguro de eliminar esta historia clínica?');">
                    Eliminar
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
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
