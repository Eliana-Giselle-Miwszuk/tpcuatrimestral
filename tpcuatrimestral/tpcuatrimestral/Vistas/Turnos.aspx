<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="tpcuatrimestral.Vistas.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .calendar-container {
            max-width: 600px;
            margin: 0 auto;
        }
        .calendar {
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            overflow: hidden;
        }
        .calendar-header {
            background: #0d6efd;
            color: white;
            padding: 15px 0;
            text-align: center;
        }
        .calendar-nav {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 0 15px;
        }
        .calendar-nav button {
            background: none;
            border: none;
            color: white;
            font-size: 1.2rem;
            cursor: pointer;
        }
        .calendar-title {
            margin: 0;
            font-size: 1.3rem;
        }
        .calendar-weekdays {
            display: grid;
            grid-template-columns: repeat(7, 1fr);
            background: #f8f9fa;
            padding: 10px 0;
            text-align: center;
            font-weight: bold;
        }
        .calendar-days {
            display: grid;
            grid-template-columns: repeat(7, 1fr);
            gap: 5px;
            padding: 10px;
        }
        .day {
            aspect-ratio: 1;
            display: flex;
            align-items: center;
            justify-content: center;
            border-radius: 50%;
            cursor: pointer;
            transition: all 0.2s;
        }
        .day:hover {
            background: #e9ecef;
        }
        .day.today {
            background: #0d6efd;
            color: white;
        }
        .day.selected {
            background: #198754;
            color: white;
        }
        .day.other-month {
            color: #adb5bd;
            opacity: 0.6;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="calendar-container mt-4">
        <div class="calendar">
            <div class="calendar-header">
                <div class="calendar-nav">
                    <button id="prev-month"><i class="fas fa-chevron-left"></i></button>
                    <h3 class="calendar-title" id="current-month">Junio 2023</h3>
                    <button id="next-month"><i class="fas fa-chevron-right"></i></button>
                </div>
            </div>
            
            <div class="calendar-weekdays">
                <div>Dom</div>
                <div>Lun</div>
                <div>Mar</div>
                <div>Mié</div>
                <div>Jue</div>
                <div>Vie</div>
                <div>Sáb</div>
            </div>
            
            <div class="calendar-days" id="calendar-days">
                <!-- Días se generarán dinámicamente -->
                <div class="day other-month">30</div>
                <div class="day other-month">31</div>
                <div class="day">1</div>
                <div class="day">2</div>
                <div class="day">3</div>
                <div class="day">4</div>
                <div class="day">5</div>
                <div class="day">6</div>
                <div class="day">7</div>
                <div class="day">8</div>
                <div class="day">9</div>
                <div class="day">10</div>
                <div class="day">11</div>
                <div class="day">12</div>
                <div class="day">13</div>
                <div class="day">14</div>
                <div class="day">15</div>
                <div class="day">16</div>
                <div class="day">17</div>
                <div class="day">18</div>
                <div class="day">19</div>
                <div class="day today"><a runat="server"  href="VerTurno.aspx" style="color:aliceblue;" >20</a></div>
                <div class="day">21</div>
                <div class="day">22</div>
                <div class="day">23</div>
                <div class="day">24</div>
                <div class="day">25</div>
                <div class="day">26</div>
                <div class="day">27</div>
                <div class="day">28</div>
                <div class="day">29</div>
                <div class="day">30</div>
                <div class="day other-month">1</div>
                <div class="day other-month">2</div>
            </div>
        </div>
    </div>
</asp:Content>