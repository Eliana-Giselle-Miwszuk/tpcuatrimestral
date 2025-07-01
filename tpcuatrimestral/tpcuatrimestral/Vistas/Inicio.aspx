<%@ Page Title="Inicio - Veterinaria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="tpcuatrimestral.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        /* Estilos existentes se mantienen igual */
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
        
        /* Nuevos estilos para la barra inferior */
        .session-footer {
            background-color: #2c3e50;
            color: white;
            padding: 10px 20px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            position: fixed;
            bottom: 0;
            left: 0;
            right: 0;
            z-index: 1000;
            box-shadow: 0 -2px 5px rgba(0,0,0,0.2);
        }
        
        .session-info {
            display: flex;
            gap: 15px;
            font-size: 0.9em;
        }
        
        .session-info span {
            display: flex;
            align-items: center;
        }
        
        .session-info i {
            margin-right: 5px;
            color: #4CAF50;
        }
        
        .logout-btn {
            background: none;
            border: 1px solid white;
            color: white;
            padding: 5px 10px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 0.8em;
            transition: all 0.3s;
        }
        
        .logout-btn:hover {
            background: white;
            color: #2c3e50;
        }
        
        /* Ajuste para el contenido principal */
        .main-content {
            margin-bottom: 50px; /* Espacio para la barra inferior */
        }
    </style>
    
    <!-- Font Awesome para íconos -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <section class="hero-section">
            <div class="hero-content">
                <h1 style="font-size: 3em; margin-bottom: 20px;">Bienvenido a Veterinaria Patitas Felices</h1>
                <p style="font-size: 1.2em; margin-bottom: 30px;">Cuidamos con amor a tus mascotas como si fueran nuestras</p>
            </div>
        </section>
    </div>

</asp:Content>