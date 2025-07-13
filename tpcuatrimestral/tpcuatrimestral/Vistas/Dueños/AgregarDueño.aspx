<%@ Page Title="Formulario de Dueño" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="AgregarDueño.aspx.cs" 
    Inherits="tpcuatrimestral.Vistas.AgregarDueño" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        :root {
            --primary-color: #4361ee;
            --secondary-color: #3f37c9;
            --accent-color: #4895ef;
            --light-color: #f8f9fa;
            --dark-color: #212529;
            --success-color: #4cc9f0;
            --danger-color: #f72585;
            --warning-color: #f8961e;
        }
        
        .form-container {
            max-width: 800px;
            margin: 2rem auto;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            border-radius: 12px;
            overflow: hidden;
            background: white;
        }
        
        .form-header {
            background: linear-gradient(135deg, var(--primary-color), var(--secondary-color));
            color: white;
            padding: 1.5rem;
            position: relative;
        }
        
        .form-header h3 {
            margin: 0;
            font-weight: 600;
            display: flex;
            align-items: center;
        }
        
        .form-header i {
            margin-right: 12px;
            font-size: 1.5rem;
        }
        
        .form-body {
            padding: 2rem;
        }
        
        .section-title {
            color: var(--primary-color);
            font-weight: 500;
            margin-bottom: 1.5rem;
            display: flex;
            align-items: center;
            font-size: 1.1rem;
        }
        
        .section-title i {
            margin-right: 10px;
        }
        
        .form-label {
            font-weight: 500;
            margin-bottom: 0.5rem;
            color: var(--dark-color);
        }
        
        .required-field::after {
            content: " *";
            color: var(--danger-color);
        }
        
        .form-control {
            border-radius: 8px;
            padding: 10px 15px;
            border: 1px solid #e0e0e0;
            transition: all 0.3s ease;
        }
        
        .form-control:focus {
            border-color: var(--accent-color);
            box-shadow: 0 0 0 0.25rem rgba(67, 97, 238, 0.15);
        }
        
        .input-hint {
            font-size: 0.8rem;
            color: #6c757d;
            margin-top: 0.25rem;
        }
        
        .form-footer {
            background-color: var(--light-color);
            padding: 1.5rem;
            display: flex;
            justify-content: space-between;
            align-items: center;
            border-top: 1px solid #e9ecef;
        }
        
        .btn-primary-custom {
            background-color: var(--primary-color);
            border-color: var(--primary-color);
            border-radius: 8px;
            padding: 8px 20px;
            font-weight: 500;
            transition: all 0.3s ease;
        }
        
        .btn-primary-custom:hover {
            background-color: var(--secondary-color);
            border-color: var(--secondary-color);
            transform: translateY(-2px);
        }
        
        .btn-secondary-custom {
            background-color: white;
            border: 1px solid #e0e0e0;
            color: var(--dark-color);
            border-radius: 8px;
            padding: 8px 20px;
            font-weight: 500;
            transition: all 0.3s ease;
        }
        
        .btn-secondary-custom:hover {
            background-color: #f1f1f1;
            transform: translateY(-2px);
        }
        
        .btn-warning-custom {
            background-color: white;
            border: 1px solid var(--warning-color);
            color: var(--warning-color);
            border-radius: 8px;
            padding: 8px 20px;
            font-weight: 500;
            transition: all 0.3s ease;
        }
        
        .btn-warning-custom:hover {
            background-color: #fff9f0;
            transform: translateY(-2px);
        }
        
        .form-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
            gap: 1.5rem;
        }
        
        .status-message {
            font-weight: 600;
            padding: 0.5rem;
            border-radius: 8px;
            text-align: center;
            margin-top: 1rem;
        }
        
        @media (max-width: 768px) {
            .form-container {
                margin: 1rem;
            }
            
            .form-body {
                padding: 1.5rem;
            }
            
            .form-footer {
                flex-direction: column;
                gap: 1rem;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <div class="form-header">
            <h3><i class="fas fa-user-tie"></i>Formulario de Dueño</h3>
        </div>
        
        <div class="form-body">
            <div class="section-title">
                <i class="fas fa-id-card"></i>Información Básica
            </div>
            
            <div class="form-grid">
                <div class="form-group">
                    <label class="form-label required-field">DNI</label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" MaxLength="8" TextMode="Number" placeholder="Ingrese DNI sin puntos" />
                    <small class="input-hint">Ejemplo: 12345678</small>
                </div>
                
                <div class="form-group">
                    <label class="form-label required-field">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="50" placeholder="Ingrese apellido" />
                </div>
                
                <div class="form-group">
                    <label class="form-label required-field">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" placeholder="Ingrese nombre" />
                </div>
                
                <div class="form-group">
                    <label class="form-label required-field">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" placeholder="Ingrese teléfono" />
                    <small class="input-hint">Ejemplo: 3815123456</small>
                </div>
                
                <div class="form-group">
                    <label class="form-label required-field">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ingrese email" />
                </div>
                
                <div class="form-group">
                    <label class="form-label required-field">Dirección</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ingrese dirección completa" />
                </div>
            </div>
            
            <asp:Label ID="lblCartel" runat="server" CssClass="status-message" style="display: block;"></asp:Label>
        </div>

        <div class="form-footer">
            <div class="button-group">
                <div class="d-flex gap-2 flex-wrap">
                    
                    <asp:Button ID="btnInsertar" runat="server"
                        CssClass="btn btn-primary px-4 py-2 fw-bold"
                        OnClick="btnInsertar_Click"
                        Text="Guardar" />
                    
                    <asp:Button ID="btnLimpiarCampo" runat="server"
                        CssClass="btn btn-secondary px-4 py-2 fw-bold"
                        OnClick="btnLimpiar_Click"
                        Text="Limpiar" />
                 
                    <asp:Button ID="btnCancelar" runat="server"
                        CssClass="btn btn-outline-danger px-4 py-2 fw-bold"
                        OnClick="btnCancelar_Click"
                        Text="Cancelar" />
                </div>
            </div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>