<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMascota.aspx.cs" Inherits="tpcuatrimestral.Vistas.AgregarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            background: linear-gradient(135deg, #6c5ce7, #0984e3);
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
            background-color: #0984e3;
            color: white;
        }
        
        .btn-primary:hover {
            background-color: #0767b3;
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(9, 132, 227, 0.3);
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
        
        @media (max-width: 768px) {
            .form-container {
                margin: 1rem;
            }
            
            .form-body {
                padding: 1.5rem;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <div class="form-header">
            <h2><i class="fas fa-paw"></i>Agregar Mascota</h2>
        </div>
        
        <div class="form-body">

            <div class="form-group">
                <label class="form-label">Buscar Dueño por DNI</label>
                <div class="input-group">
                    <asp:TextBox ID="txtBuscarDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI"></asp:TextBox>
                    <asp:Button ID="btnBuscarDNI" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscarDNI_Click" />
                </div>
                <asp:Label ID="lblResultadoBusqueda" runat="server" CssClass="text-muted small"></asp:Label>
            </div>

            <asp:HiddenField ID="hdnIdDueño" runat="server" />

            <!--/ DATOS DEL DUEÑO /-->
            <hr />
           <div class="form-group">
                <label class="form-label">Datos del dueño</label>
                <div class="input-group">
                    <asp:TextBox ID="txtNombreDueño" runat="server" CssClass="form-control" ></asp:TextBox>
                    <asp:TextBox ID="txtApellidoDueño" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
              <hr />
              <hr />
            <!--/ ----------------  /-->

            <div class="form-group">
                <label class="form-label">Raza</label>
                <asp:DropDownList ID="DdlRaza" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccione una raza" Value="" Selected="True" />
                </asp:DropDownList>
            </div>

            <!-- SEXO MASCOTA -->
            <div class="form-group">
                <label class="form-label">Sexo</label>
                <asp:DropDownList ID="DdlSexo" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccione un sexo" Value="" Selected="True" />
                    <asp:ListItem Text="Hembra" Value="Hembra" />
                    <asp:ListItem Text="Macho" Value="Macho" />
                </asp:DropDownList>
            </div>
            <!-- ------------- -->

            <div class="form-group">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Nombre de la mascota"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="form-label">Color</label>
                <asp:TextBox ID="TextColor" runat="server" CssClass="form-control" placeholder="Color principal"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="form-label">Peso</label>
                <asp:TextBox ID="TextPeso" runat="server" CssClass="form-control" placeholder="Peso en kg" TextMode="Number"></asp:TextBox>
            </div>
            
            <div class="form-footer">
                <div class="button-group">
                    <div class="d-flex gap-2 flex-wrap">

                        <asp:Button ID="BtnGuardarMascota" runat="server"
                            CssClass="btn btn-primary px-4 py-2 fw-bold"
                            OnClick="BtnGuardarMascota_Click"
                            Text="Guardar" />

                        <asp:Button ID="btnCancelar" runat="server"
                            CssClass="btn btn-outline-danger px-4 py-2 fw-bold"
                            OnClick="btnCancelar_Click"
                            Text="Cancelar"
                            CausesValidation="false" />

                    </div>
                </div>
            </div>

            <asp:Label ID="lblValidacion" runat="server" CssClass="status-message" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>