<%@ Page Title="Gestión de Veterinarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarVeterinarios.aspx.cs" Inherits="tpcuatrimestral.Vistas.ListaVeterinarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />
    <style>
        .form-container {
            max-width: 800px;
            margin: 2rem auto;
            background: white;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
            overflow: hidden;
        }
        
        .form-header {
            background: linear-gradient(135deg, #4361ee, #3f37c9);
            color: white;
            padding: 1.5rem;
            text-align: center;
        }
        
        .form-header h2 {
            margin: 0;
            font-weight: 600;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        
        .form-header i {
            margin-right: 10px;
            font-size: 1.8rem;
        }
        
        .form-body {
            padding: 2rem;
        }
        
        .form-group {
            margin-bottom: 1.5rem;
        }
        
        .form-label {
            display: block;
            margin-bottom: 0.5rem;
            font-weight: 500;
            color: #2d3436;
        }
        
        .form-control {
            width: 100%;
            padding: 12px 15px;
            border: 1px solid #dfe6e9;
            border-radius: 8px;
            transition: all 0.3s ease;
            font-size: 1rem;
        }
        
        .form-control:focus {
            border-color: #74b9ff;
            box-shadow: 0 0 0 3px rgba(116, 185, 255, 0.2);
            outline: none;
        }
        
        .btn {
            padding: 12px 24px;
            border-radius: 8px;
            font-weight: 500;
            cursor: pointer;
            transition: all 0.3s ease;
            border: none;
            font-size: 1rem;
        }
        
        .btn-primary {
            background-color: #4361ee;
            color: white;
        }
        
        .btn-primary:hover {
            background-color: #3a56d4;
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(67, 97, 238, 0.3);
        }
        
        .status-message {
            margin-top: 1.5rem;
            padding: 12px;
            border-radius: 8px;
            text-align: center;
            font-weight: 500;
        }
        
        .text-success {
            color: #00b894;
        }
        
        .text-danger {
            color: #d63031;
        }
        
        .input-group {
            display: flex;
            gap: 10px;
        }
        
        .input-group .form-control {
            flex: 1;
        }
        
        .small {
            font-size: 0.8rem;
        }
        
        .text-muted {
            color: #6c757d;
        }
        
        @media (max-width: 768px) {
            .form-container {
                margin: 1rem;
            }
            
            .form-body {
                padding: 1.5rem;
            }
            
            .input-group {
                flex-direction: column;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <div class="form-header">
            <h2><i class="fas fa-user-md"></i>Gestión de Veterinarios</h2>
        </div>
        
        <div class="form-body">
            <!-- Búsqueda de Usuario por DNI -->
            <div class="form-group">
                <label class="form-label">Buscar Usuario por DNI</label>
                <div class="input-group">
                    <asp:TextBox ID="txtBuscarDniUsuario" runat="server" CssClass="form-control" placeholder="Ingrese DNI del usuario" TextMode="Number"></asp:TextBox>
                    <asp:Button ID="btnBuscarUsuario" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscarUsuario_Click" />
                </div>
                <asp:Label ID="lblResultadoBusqueda" runat="server" CssClass="text-muted small"></asp:Label>
            </div>
            
            <asp:HiddenField ID="hdnIdUsuario" runat="server" />
            
            <!-- Información del Usuario -->
            <div class="form-group">
                <label class="form-label">Datos del Usuario</label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Nombre de usuario"></asp:TextBox>
            </div>
            
            <hr />
            
            <!-- Información Personal del Veterinario -->
            <div class="form-group">
                <label class="form-label required-field">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="50" placeholder="Ingrese apellido" />
            </div>
            
            <div class="form-group">
                <label class="form-label required-field">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" placeholder="Ingrese nombre" />
            </div>
            
            <!-- Información de Contacto -->
            <div class="form-group">
                <label class="form-label required-field">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ingrese dirección completa" />
            </div>
            
            <div class="form-group">
                <label class="form-label required-field">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" TextMode="Phone" placeholder="Ingrese teléfono" />
                <small class="text-muted">Ejemplo: 3815123456</small>
            </div>
            
            <div class="form-group">
                <label class="form-label required-field">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="100" TextMode="Email" placeholder="Ingrese email" />
            </div>
            
            <!-- Información Profesional -->
            <div class="form-group">
                <label class="form-label required-field">Matrícula Nacional</label>
                <asp:TextBox ID="txtMatriculaNacional" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese matrícula nacional" />
                <small class="text-muted">Solo números / en caso de tener M.P Ingrese 0</small>
            </div>
            
            <div class="form-group">
                <label class="form-label required-field">Matrícula Provincial</label>
                <asp:TextBox ID="txtMatriculaProvincial" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese matrícula provincial" />
                <small class="text-muted">Solo números / en caso de tener M.N Ingrese 0</small>
            </div>
            
            <div class="form-group">
                <label class="form-label required-field">Especialidad</label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
            
            <div class="form-footer">
                <div class="button-group">
                    <div class="d-flex gap-2 flex-wrap">
                        <asp:Button ID="btnGuardar" runat="server" 
                            CssClass="btn btn-primary px-4 py-2 fw-bold"
                            Text="Guardar" OnClick="btnGuardar_Click" />
                            
                        <asp:Button ID="btnLimpiar" runat="server"
                            CssClass="btn btn-secondary px-4 py-2 fw-bold"
                            Text="Limpiar" OnClick="btnLimpiar_Click" />
                            
                        <asp:Button ID="btnCancelar" runat="server"
                            CssClass="btn btn-outline-danger px-4 py-2 fw-bold"
                            Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>

            <asp:Label ID="lblCartel" runat="server" CssClass="status-message" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>