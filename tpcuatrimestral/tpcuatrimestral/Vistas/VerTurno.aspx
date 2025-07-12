<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTurno.aspx.cs" Inherits="tpcuatrimestral.Vistas.VerTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .day-header {
            background-color: #f8f9fa;
            font-weight: bold;
        }
        .time-slot {
            border: 1px solid #dee2e6;
            border-radius: 4px;
            padding: 8px;
            margin-bottom: 5px;
        }
        .available {
            background-color: #d1e7dd;
            cursor: pointer;
        }
        .booked {
            background-color: #f8d7da;
        }
        .current-time {
            background-color: #fff3cd;
        }
        .professional-card {
            transition: all 0.2s;
        }
        .professional-card:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
        .professional-card.active {
            border: 2px solid #0d6efd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Turnos del Día</h2>
        
        <!-- Selector de Fecha -->
        <div class="row mb-4">
            <div class="col-md-6">
                <div class="input-group">
                    <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                    <input type="date" class="form-control" id="datePicker" value="2023-06-15">
                    <button class="btn btn-primary" type="button">Buscar</button>
                </div>
            </div>
        </div>
        
        <!-- Selector de Profesional -->
        <div class="row mb-4">
            <div class="col-12">
                <h4 class="mb-3">Profesionales</h4>
                <div class="d-flex flex-wrap gap-3">
                    <div class="card professional-card active" style="width: 18rem;">
                        <div class="card-body">
                            <h5 class="card-title">Dr. Juan Pérez</h5>
                            <h6 class="card-subtitle mb-2 text-muted">Cardiólogo</h6>
                            <p class="card-text">Disponibilidad: 8:00 - 16:00</p>
                        </div>
                    </div>
                    <div class="card professional-card" style="width: 18rem;">
                        <div class="card-body">
                            <h5 class="card-title">Dra. María Gómez</h5>
                            <h6 class="card-subtitle mb-2 text-muted">Pediatra</h6>
                            <p class="card-text">Disponibilidad: 9:00 - 17:00</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Listado de Turnos -->
        <div class="row">
            <div class="col-md-6">
                <h4 class="mb-3">Turnos - 15 de Junio 2023</h4>
                
                <div class="table-responsive">
                    <table class="table table-bordered">
                        <thead class="day-header">
                            <tr>
                                <th>Hora</th>
                                <th>Paciente</th>
                                <th>Estado</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="current-time">
                                <td>08:00</td>
                                <td>-</td>
                                <td><span class="badge bg-success">Disponible</span></td>
                                <td><button class="btn btn-sm btn-primary">Reservar</button></td>
                            </tr>
                            <tr>
                                <td>09:00</td>
                                <td>Carlos Sánchez</td>
                                <td><span class="badge bg-danger">Ocupado</span></td>
                                <td><button class="btn btn-sm btn-secondary" disabled>Reservado</button></td>
                            </tr>
                            <tr>
                                <td>10:00</td>
                                <td>-</td>
                                <td><span class="badge bg-success">Disponible</span></td>
                                <td><button class="btn btn-sm btn-primary">Reservar</button></td>
                            </tr>
                            <tr>
                                <td>11:00</td>
                                <td>María Rodríguez</td>
                                <td><span class="badge bg-danger">Ocupado</span></td>
                                <td><button class="btn btn-sm btn-secondary" disabled>Reservado</button></td>
                            </tr>
                            <tr>
                                <td>12:00</td>
                                <td>-</td>
                                <td><span class="badge bg-success">Disponible</span></td>
                                <td><button class="btn btn-sm btn-primary">Reservar</button></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        <h5 class="mb-0">Detalle de Turno</h5>
                    </div>
                    <div class="card-body">
                        <div class="alert alert-info">
                            Seleccione un turno disponible para ver los detalles
                        </div>
                        
                        <!-- Este contenido se llenaría dinámicamente -->
                        <div id="turnoDetalle" style="display: none;">
                            <h5>Reservar Turno</h5>
                            <p><strong>Profesional:</strong> Dr. Juan Pérez</p>
                            <p><strong>Fecha:</strong> 15 de Junio 2023</p>
                            <p><strong>Hora:</strong> 10:00</p>
                            
                            <div class="mb-3">
                                <label class="form-label">Nombre del Paciente</label>
                                <input type="text" class="form-control">
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Teléfono</label>
                                <input type="tel" class="form-control">
                            </div>
                            <button class="btn btn-success">Confirmar Turno</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap JS y dependencias -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/js/all.min.js"></script>
    <script>
        // Ejemplo de interacción básica
        document.querySelectorAll('.professional-card').forEach(card => {
            card.addEventListener('click', function () {
                document.querySelectorAll('.professional-card').forEach(c => c.classList.remove('active'));
                this.classList.add('active');
            });
        });

        document.querySelectorAll('button.btn-primary').forEach(btn => {
            btn.addEventListener('click', function () {
                document.getElementById('turnoDetalle').style.display = 'block';
            });
        });
    </script>
</asp:Content>