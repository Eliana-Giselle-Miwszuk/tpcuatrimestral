<%@ Page Title="Nuevo Turno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="NuevoTurno.aspx.cs" Inherits="tpcuatrimestral.Vistas.Admision.NuevoTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Nuevo Turno - Sistema Veterinario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-control {
            width: 100%;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .btn-submit {
            background-color: #4CAF50;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            margin-right: 10px;
        }
        .btn-submit:hover {
            background-color: #45a049;
        }
        .search-results {
            margin-top: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            max-height: 200px;
            overflow-y: auto;
            display: none;
        }
        .search-item {
            padding: 8px;
            border-bottom: 1px solid #eee;
            cursor: pointer;
        }
        .search-item:hover {
            background-color: #f0f0f0;
        }
        .owner-info {
            font-weight: bold;
        }
        .pet-info {
            margin-left: 15px;
            color: #555;
            font-size: 0.9em;
        }
        .selected-pet {
            background-color: #e6f7e6;
            padding: 10px;
            border-radius: 4px;
            margin-top: 10px;
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Registrar Nuevo Turno</h2>
        
        <!-- Sección de Búsqueda de Dueño/Animal -->
        <div class="form-group">
            <label for="busquedaPaciente">Buscar Dueño/Animal:</label>
            <input type="text" id="busquedaPaciente" class="form-control" placeholder="Ingrese nombre del dueño o DNI..." />
            
            <div id="resultadosBusqueda" class="search-results">
                <!-- Ejemplo de resultados estáticos -->
                <div class="search-item" onclick="seleccionarPaciente('1001', 'María González (DNI: 30123456) - Firulais (Caniche)')">
                    <div class="owner-info">María González (DNI: 30123456)</div>
                    <div class="pet-info">Firulais (Perro, Caniche) - HC-1001</div>
                </div>
                <div class="search-item" onclick="seleccionarPaciente('1001', 'María González (DNI: 30123456) - Mishi (Siames)')">
                    <div class="owner-info">María González (DNI: 30123456)</div>
                    <div class="pet-info">Mishi (Gato, Siames) - HC-1002</div>
                </div>
                <div class="search-item" onclick="seleccionarPaciente('1003', 'Juan Pérez (DNI: 28987654) - Rex (Labrador)')">
                    <div class="owner-info">Juan Pérez (DNI: 28987654)</div>
                    <div class="pet-info">Rex (Perro, Labrador) - HC-1003</div>
                </div>
            </div>
            
            <div id="pacienteSeleccionado" class="selected-pet">
                <strong>Paciente seleccionado:</strong> <span id="infoPaciente"></span>
                <input type="hidden" id="idPaciente" name="idPaciente" />
            </div>
        </div>

        <!-- Resto del formulario de turno -->
        <div class="form-group">
            <label for="fechaHoraTurno">Fecha y Hora del Turno:</label>
            <input type="datetime-local" id="fechaHoraTurno" name="fechaHoraTurno" class="form-control"  />
        </div>
        
        <div class="form-group">
            <label for="veterinario">Veterinario:</label>
            <select id="veterinario" name="veterinario" class="form-control" >
                <option value="">-- Seleccione un veterinario --</option>
                <option value="1">Dr. Juan Pérez</option>
                <option value="2">Dra. María González</option>
                <option value="3">Dr. Carlos López</option>
            </select>
        </div>
        
        <div class="form-group">
            <label for="motivoConsulta">Motivo de la Consulta:</label>
            <textarea id="motivoConsulta" name="motivoConsulta" class="form-control" rows="4" ></textarea>
        </div>
        
        <div class="form-group">
            <button type="submit" class="btn-submit">Registrar Turno</button>
            <button type="reset" class="btn-submit">Cancelar</button>
        </div>
    </div>


    <!--    Prueba la búsqueda de pacientes:
Escribe "maría" en el campo de búsqueda

Deberían aparecer dos mascotas de María González

Escribe "2898" (parte del DNI de Juan Pérez)

Debería aparecer Rex (Labrador)

Haz clic en cualquier resultado

Verifica que se muestre la selección debajo del campo de búsqueda-->

    <script type="text/javascript">
        // Función para mostrar/ocultar resultados de búsqueda
        document.getElementById('busquedaPaciente').addEventListener('input', function() {
            var searchValue = this.value.toLowerCase();
            var resultados = document.getElementById('resultadosBusqueda');
            var items = resultados.getElementsByClassName('search-item');
            
            if (searchValue.length > 2) {
                resultados.style.display = 'block';
                
                // Filtrado simple (en realidad sería una búsqueda del lado del servidor)
                for (var i = 0; i < items.length; i++) {
                    var text = items[i].textContent.toLowerCase();
                    items[i].style.display = text.includes(searchValue) ? 'block' : 'none';
                }
            } else {
                resultados.style.display = 'none';
            }
        });
        
        // Función para seleccionar un paciente
        function seleccionarPaciente(id, info) {
            document.getElementById('idPaciente').value = id;
            document.getElementById('infoPaciente').textContent = info;
            document.getElementById('pacienteSeleccionado').style.display = 'block';
            document.getElementById('resultadosBusqueda').style.display = 'none';
            document.getElementById('busquedaPaciente').value = '';
        }
    </script>
</asp:Content>


