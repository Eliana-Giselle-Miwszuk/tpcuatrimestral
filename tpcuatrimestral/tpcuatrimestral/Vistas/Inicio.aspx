<%@ Page Title="Inicio - Veterinaria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="tpcuatrimestral.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hero-section {
            background-image: url('Imagenes/vete.jpg');
            background-size: cover;
            background-position: center;
            height: 80vh;
            display: flex;
            align-items: center;
            justify-content: center;
            text-align: center;
            color: white;
            position: relative;
        }
        
        .hero-section::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: rgba(0, 0, 0, 0.5);
        }
        
        .hero-content {
            position: relative;
            z-index: 1;
            max-width: 800px;
            padding: 20px;
        }
        
        .btn-primary {
            background-color: #4CAF50;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            margin-top: 20px;
            text-decoration: none;
            display: inline-block;
        }
        
        .services-section {
            padding: 50px 0;
            text-align: center;
        }
        
        .service-card {
            display: inline-block;
            width: 30%;
            margin: 15px;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-section">
        <div class="hero-content">
            <h1 style="font-size: 3em; margin-bottom: 20px;">Bienvenido a Veterinaria Patitas Felices</h1>
            <p style="font-size: 1.2em; margin-bottom: 30px;">Cuidamos con amor a tus mascotas como si fueran nuestras</p>
        </div>
    </section>
</asp:Content>