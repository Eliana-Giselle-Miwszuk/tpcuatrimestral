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
                        <!-- Sección Información Básica -->
                        <div class="form-section">
                            <h5 class="mb-4 text-secondary"><i class="fas fa-id-card me-2"></i>Información Básica</h5>
                            
                            <div class="row g-3">
                                <!-- DNI -->
                                <div class="col-md-6">
                                    <label class="form-label required-field">DNI</label>
                                    <input type="number" class="form-control" placeholder="Ingrese DNI sin puntos" maxlength="8">
                                    <small class="text-muted">Ejemplo: 12345678</small>
                                </div>
                                
                                <!-- Fecha Registro -->
                                <div class="col-md-6">
                                    <label class="form-label">Fecha de Registro</label>
                                    <input type="text" class="form-control bg-light" value="15/07/2023" readonly>
                                </div>
                                
                                <!-- Apellido -->
                                <div class="col-md-6">
                                    <label class="form-label required-field">Apellido</label>
                                    <input type="text" class="form-control" placeholder="Ingrese apellido" maxlength="50">
                                </div>
                                
                                <!-- Nombre -->
                                <div class="col-md-6">
                                    <label class="form-label required-field">Nombre</label>
                                    <input type="text" class="form-control" placeholder="Ingrese nombre" maxlength="50">
                                </div>
                            </div>
                        </div>
                        
                        <!-- Sección Contacto -->
                        <div class="form-section">
                            <h5 class="mb-4 text-secondary"><i class="fas fa-address-book me-2"></i>Información de Contacto</h5>
                            
                            <div class="row g-3">
                                <!-- Dirección -->
                                <div class="col-12">
                                    <label class="form-label required-field">Dirección</label>
                                    <input type="text" class="form-control" placeholder="Ingrese dirección completa" maxlength="100">
                                </div>
                                
                                <!-- Teléfono -->
                                <div class="col-md-6">
                                    <label class="form-label required-field">Teléfono</label>
                                    <input type="tel" class="form-control" placeholder="Ingrese teléfono" maxlength="20">
                                    <small class="text-muted">Ejemplo: 3815123456</small>
                                </div>
                                
                                <!-- Email -->
                                <div class="col-md-6">
                                    <label class="form-label required-field">Email</label>
                                    <input type="email" class="form-control" placeholder="Ingrese email" maxlength="100">
                                </div>
                            </div>
                        </div>
                        
                        <!-- Sección Estado -->
                        <div class="form-section">
                            <h5 class="mb-4 text-secondary"><i class="fas fa-cog me-2"></i>Estado</h5>
                            
                            <div class="form-check form-switch">
                                <input class="form-check-input" type="checkbox" id="flexSwitchCheckChecked" checked>
                                <label class="form-check-label text-secondary" for="flexSwitchCheckChecked">Dueño activo</label>
                            </div>
                        </div>
                    </div>
                    
                    <div class="card-footer bg-light">
                        <div class="d-flex justify-content-between">
                            <a href="ListaDueño.aspx" class="btn btn-outline-secondary">
                                <i class="fas fa-times me-1"></i>Cancelar
                            </a>
                            
                            <div>
                                <button type="reset" class="btn btn-outline-dark me-2">
                                    <i class="fas fa-broom me-1"></i>Limpiar
                                </button>
                                
                                <button type="submit" class="btn btn-custom">
                                    <i class="fas fa-save me-1"></i>Guardar Dueño
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>