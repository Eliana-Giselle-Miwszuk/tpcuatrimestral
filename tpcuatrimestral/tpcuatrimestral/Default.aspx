<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tpcuatrimestral.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login - Veterinaria</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center align-items-center min-vh-100">
            <div class="row justify-content-center w-100">
                <div class="col-md-6 col-lg-4">
                    <div class="card shadow">
                        <div class="card-body p-4">
                            <h1 class="text-center mb-4">Acceso al Sistema</h1>
                            
                            <asp:Panel ID="pnlError" runat="server" Visible="false" CssClass="alert alert-danger">
                                <asp:Literal ID="litError" runat="server"></asp:Literal>
                            </asp:Panel>
                            
                            <div class="mb-3">
                                <asp:Label Text="Usuario" runat="server" CssClass="form-label fw-bold" />
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            
                            <div class="mb-3">
                                <asp:Label Text="Contraseña" runat="server" CssClass="form-label fw-bold" />
                                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                            
                            <div class="d-grid gap-2 mt-4">
                                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
                                    OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>