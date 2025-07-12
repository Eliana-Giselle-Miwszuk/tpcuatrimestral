<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Iniciar Turno</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
    <style>
        .card-header {
            font-weight: 600;
        }
        .info-label {
            font-weight: 500;
            color: #6c757d;
        }
        .info-value {
            font-size: 1.1rem;
        }
        .required-field::after {
            content: " *";
            color: #dc3545;
        }
    </style>
</head>
<body>
    <div class="container mt-4">
        <div class="row mb-4">
            <div class="col">
                <h2><i class="fas fa-play-circle text-primary me-2"></i>Iniciar Atención</h2>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="PanelAdmision.aspx">Panel</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Iniciar Turno</li>
                    </ol>
                </nav>
            </div>
        </div>

        <div class="card shadow mb-4">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Datos del Turno</h4>
            </div>
            <div class="card-body">
                <div class="row mb-4">
                    <div class="col-md-4">
                        <span class="info-label">Número de Turno:</span>
                        <p class="info-value">1254</p>
                    </div>
                    <div class="col-md-4">
                        <span class="info-label">Historia Clínica:</span>
                        <p class="info-value">HC-2023-1254</p>
                    </div>
                    <div class="col-md-4">
                        <span class="info-label">Fecha/Hora:</span>
                        <p class="info-value">15/06/2024 10:00 AM</p>
                    </div>
                </div>

                <div class="row mb-4">
                    <div class="col-md-6">
                        <span class="info-label">Paciente:</span>
                        <p class="info-value">Max (Labrador Retriever)</p>
                    </div>
                    <div class="col-md-6">
                        <span class="info-label">Dueño:</span>
                        <p class="info-value">María González</p>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <span class="info-label">Veterinario asignado:</span>
                        <p class="info-value">Dr. Juan Pérez</p>
                    </div>
                    <div class="col-md-6">
                        <span class="info-label">Motivo de consulta:</span>
                        <p class="info-value">Control anual y vacunación</p>
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow mb-4">
            <div class="card-header bg-light">
                <h4 class="mb-0">Registro Clínico Inicial</h4>
            </div>
            <div class="card-body">
                <form>
                    <div class="row mb-3">
                        <div class="col-md-3">
                            <label class="form-label required-field">Temperatura (°C)</label>
                            <input type="number" class="form-control" step="0.1" placeholder="Ej: 38.5">
                            <small class="text-danger">Campo requerido</small>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label required-field">Peso (kg)</label>
                            <input type="number" class="form-control" step="0.1" placeholder="Ej: 25.3">
                            <small class="text-danger">Campo requerido</small>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Frec. Cardíaca</label>
                            <input type="number" class="form-control" placeholder="Latidos por minuto">
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Frec. Respiratoria</label>
                            <input type="number" class="form-control" placeholder="Respiraciones por minuto">
                        </div>
                    </div>

                    <div class="mb-3">
                        <label class="form-label required-field">Observaciones iniciales</label>
                        <textarea class="form-control" rows="4" placeholder="Describa el estado general del paciente al inicio de la consulta..."></textarea>
                        <small class="text-danger">Campo requerido</small>
                    </div>

                    <div class="mb-3 form-check">
                        <input type="checkbox" class="form-check-input" id="cbConforme">
                        <label class="form-check-label" for="cbConforme">Confirmo que los datos ingresados son correctos</label>
                        <small class="text-danger d-block">Debe confirmar los datos</small>
                    </div>

                    <div class="alert alert-info">
                        <i class="fas fa-info-circle me-2"></i>Al iniciar la atención, el estado del turno cambiará a "En curso" y se registrará la hora de inicio real.
                    </div>
                </form>
            </div>
        </div>

        <div class="d-flex justify-content-between">
            <a href="PanelAdmision.aspx" class="btn btn-outline-secondary">
                <i class="fas fa-arrow-left me-1"></i> Volver al Panel
            </a>
            <div>
                <button class="btn btn-danger me-2">
                    <i class="fas fa-times me-1"></i> Cancelar Turno
                </button>
                <button class="btn btn-primary">
                    <i class="fas fa-play me-1"></i> Iniciar Atención
                </button>
            </div>
        </div>
    </div>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>