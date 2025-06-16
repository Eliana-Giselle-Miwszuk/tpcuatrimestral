
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tpcuatrimestral.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous" />
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script> 
</head>
<body>
<form id="form1" runat="server">
    <div class="container d-flex justify-content-center align-items-center min-vh-100">
        <div class="row justify-content-center w-100">
            <div class="col-md-6 col-lg-4">
                <div class="card shadow">
                    <div class="card-body p-4">
                        <h1 class="text-center mb-4">Página de Sesión</h1>
                        
                        <div class="mb-3">
                            <asp:Label Text="Usuario" runat="server" CssClass="form-label fw-bold" />
                            <asp:TextBox ID="xusuario" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                        <div class="mb-3">
                            <asp:Label Text="Contraseña" runat="server" CssClass="form-label fw-bold" />
                            <asp:TextBox ID="xcontraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                        <div class="d-grid gap-2 mt-4">
                            <asp:Button ID="ingresar" runat="server" Text="Ingresar" 
                                OnClick="ingresar_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</form>
</body>
</html>
