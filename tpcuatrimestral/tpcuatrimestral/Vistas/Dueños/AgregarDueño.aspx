<%@ Page Title="Formulario de Dueño" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="AgregarDueño.aspx.cs" 
    Inherits="tpcuatrimestral.Vistas.AgregarDueño" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-section {
            background-color: #f8f9fa;
            border-radius: 0.5rem;
            padding: 1.5rem;
            margin-bottom: 1.5rem;
            border-left: 4px solid #6c757d; /* Borde gris */
        }
        .required-field::after {
            content: " *";
            color: #dc3545;
        }
        .form-control:focus {
            border-color: #adb5bd;
            box-shadow: 0 0 0 0.25rem rgba(108, 117, 125, 0.25); /* Sombra gris */
        }
        .card-header-custom {
            background-color: #6c757d; /* Gris Bootstrap */
            color: white;
        }
        .btn-custom {
            background-color: #6c757d;
            border-color: #6c757d;
            color: white;
        }
        .btn-custom:hover {
            background-color: #5a6268;
            border-color: #545b62;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card shadow">
                    <div class="card-header card-header-custom">
                        <h3 class="card-title mb-0">
                            <i class="fas fa-user-edit me-2"></i>
                            Formulario de Dueño
                        </h3>
                    </div>
                    
                    <div class="card-body">
                      
                        <div class="form-section">
                            <h5 class="mb-4 text-secondary"><i class="fas fa-id-card me-2"></i>Información Básica</h5>
                            
                         
<div class="col-md-6">
    <label class="form-label required-field">DNI</label>
    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" MaxLength="8" TextMode="Number" placeholder="Ingrese DNI sin puntos" />
    <small class="text-muted">Ejemplo: 12345678</small>
</div>


<div class="col-md-6">
    <label class="form-label required-field">Apellido</label>
    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="50" placeholder="Ingrese apellido" />
</div>

<div class="col-md-6">
    <label class="form-label required-field">Nombre</label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" placeholder="Ingrese nombre" />
</div>

<div class="col-12">
    <label class="form-label required-field">Dirección</label>
    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ingrese dirección completa" />
</div>

<div class="col-md-6">
    <label class="form-label required-field">Teléfono</label>
    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" placeholder="Ingrese teléfono" />
    <small class="text-muted">Ejemplo: 3815123456</small>
</div>


<div class="col-md-6">
    <label class="form-label required-field">Email</label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ingrese email" />
</div>



                        

                    </div>
                    
                    <div class="card-footer bg-light">
                        <div class="d-flex justify-content-between">
                            
                            <div>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<br />
                                
                                <asp:Button ID="btnInsertar" runat="server" Height="34px" CssClass="btn btn-primary" OnClick="btnInsertar_Click" Text="Guardar" Width="100px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <asp:Button ID="btnLimpiarCampo" CssClass="btn btn-secondary" runat="server" Height="34px" OnClick="btnLimpiar_Click" Text="Limpiar" Width="100px" />
                                &nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                <asp:Label ID="lblCartel" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>