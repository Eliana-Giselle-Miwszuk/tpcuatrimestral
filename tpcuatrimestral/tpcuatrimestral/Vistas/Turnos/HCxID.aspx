<%@ Page Title="Historia Clínica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HCxID.aspx.cs" Inherits="tpcuatrimestral.Vistas.Turnos.HCxID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Historia Clínica
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .table {
            width: 100%;
            margin-top: 20px;
        }
        .table th {
            background-color: #343a40;
            color: white;
            text-align: center;
        }
        .table td {
            vertical-align: middle;
        }
        .no-records {
            text-align: center;
            padding: 20px;
            font-style: italic;
            color: #6c757d;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Historia Clínica N° <asp:Label ID="lblNroHC" runat="server" /></h2>
        
        <asp:GridView ID="gdvHCxID" runat="server" AutoGenerateColumns="False" 
            CssClass="table" EmptyDataText="No se encontraron registros de historia clínica">
            <Columns>
                <asp:BoundField DataField="IDRegistro" HeaderText="ID" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="FechaHoraCita" HeaderText="Fecha Cita" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Sintomas" HeaderText="Síntomas" />
                <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
                <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                
            </Columns>
            <EmptyDataRowStyle CssClass="no-records" />
        </asp:GridView>
    </div>
</asp:Content>