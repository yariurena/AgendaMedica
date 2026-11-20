CREATE DATABASE IF NOT EXISTS agenda_medica
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE agenda_medica;

CREATE TABLE IF NOT EXISTS Rol (
    id_rol INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Usuario (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Primer_Apellido VARCHAR(100) NOT NULL,
    Segundo_Apellido VARCHAR(100) NOT NULL DEFAULT '',
    Email VARCHAR(150) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL,
    id_rol INT NOT NULL,
    CONSTRAINT fk_usuario_rol
        FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);

CREATE TABLE IF NOT EXISTS Especialidad (
    id_especialidad INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion VARCHAR(255),
    Activo TINYINT(1) NOT NULL DEFAULT 1
);


CREATE TABLE IF NOT EXISTS Paciente (
    id_paciente INT AUTO_INCREMENT PRIMARY KEY,
    Primer_Apellido VARCHAR(100) NOT NULL,
    Segundo_Apellido VARCHAR(100) NOT NULL DEFAULT '',
    Nombre VARCHAR(100) NOT NULL,
    Cedula VARCHAR(30) NOT NULL UNIQUE,
    Direccion VARCHAR(255),
    Email VARCHAR(150),
    FechaNacimiento DATE,
    Telefono VARCHAR(30),
    Activo TINYINT(1) NOT NULL DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Medico (
    id_medico INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Primer_Apellido VARCHAR(100) NOT NULL,
    Segundo_Apellido VARCHAR(100) NOT NULL DEFAULT '',
    id_especialidad INT NOT NULL,
    Telefono VARCHAR(30),
    Email VARCHAR(150) NOT NULL UNIQUE,
    Activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT fk_medico_especialidad
        FOREIGN KEY (id_especialidad) REFERENCES Especialidad(id_especialidad)
);

CREATE TABLE IF NOT EXISTS HorarioMedico (
    id_horario INT AUTO_INCREMENT PRIMARY KEY,
    id_medico INT NOT NULL,
    Dia VARCHAR(15) NOT NULL,
    Hora_inicio TIME NOT NULL,
    Hora_fin TIME NOT NULL,
    CONSTRAINT fk_horario_medico
        FOREIGN KEY (id_medico) REFERENCES Medico(id_medico),
    CONSTRAINT chk_horario_horas
        CHECK (Hora_inicio < Hora_fin),
    CONSTRAINT chk_horario_dia
        CHECK (Dia IN ('Lunes','Martes','Miércoles','Jueves','Viernes','Sábado','Domingo'))
);

CREATE TABLE IF NOT EXISTS Tipo_de_cita (
    id_tip INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Estado_de_Cita (
    id_estado INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Cita (
    id_cita INT AUTO_INCREMENT PRIMARY KEY,
    id_paciente INT NOT NULL,
    id_medico INT NOT NULL,
    id_estado INT NOT NULL,
    id_tip INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    DuracionMinutos INT NOT NULL DEFAULT 30,
    Motivo VARCHAR(255) NULL,
    HoraFin TIME
        AS (ADDTIME(Hora, SEC_TO_TIME(DuracionMinutos * 60))) STORED,
    CONSTRAINT fk_cita_paciente
        FOREIGN KEY (id_paciente) REFERENCES Paciente(id_paciente),
    CONSTRAINT fk_cita_medico
        FOREIGN KEY (id_medico) REFERENCES Medico(id_medico),
    CONSTRAINT fk_cita_estado
        FOREIGN KEY (id_estado) REFERENCES Estado_de_Cita(id_estado),
    CONSTRAINT fk_cita_tipo
        FOREIGN KEY (id_tip) REFERENCES Tipo_de_cita(id_tip),
    CONSTRAINT chk_cita_duracion
        CHECK (DuracionMinutos IN (30, 45, 60)),
    INDEX idx_cita_medico_fecha_hora (id_medico, Fecha, Hora),
    INDEX idx_cita_paciente (id_paciente)
);

CREATE TABLE IF NOT EXISTS HistorialMedico (
    id_historial INT AUTO_INCREMENT PRIMARY KEY,
    id_paciente INT NOT NULL,
    id_medico INT NOT NULL,
    id_usuario INT NULL,
    Fecha DATE NOT NULL,
    Descripcion TEXT,
    Diagnostico TEXT,
    Tratamiento TEXT,
    Observaciones TEXT,
    CONSTRAINT fk_historial_paciente
        FOREIGN KEY (id_paciente) REFERENCES Paciente(id_paciente),
    CONSTRAINT fk_historial_medico
        FOREIGN KEY (id_medico) REFERENCES Medico(id_medico),
    CONSTRAINT fk_historial_usuario
        FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

INSERT IGNORE INTO Rol (Nombre)
VALUES ('Administrador'), ('Recepción');

INSERT IGNORE INTO Estado_de_Cita (Nombre) VALUES
    ('Programada'),
    ('Confirmada'),
    ('Atendida'),
    ('Cancelada'),
    ('No asistio'),
    ('Reprogramada');

INSERT IGNORE INTO Tipo_de_cita (Nombre) VALUES
    ('Presencial'),
    ('Virtual'),
    ('Urgencia');

INSERT IGNORE INTO Especialidad (Nombre, Descripcion) VALUES
    ('Medicina General', 'Atención médica general'),
    ('Pediatría', 'Atención médica de niños'),
    ('Dermatología', 'Atención de enfermedades de la piel');
