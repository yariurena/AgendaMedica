USE agenda_medica;

-- CONSULTAS DE VERIFICACIÓN
SHOW TABLES;
SELECT * FROM Estado_de_Cita;
SELECT * FROM Tipo_de_cita;
SELECT * FROM Especialidad;
SELECT * FROM Rol;
DESCRIBE HorarioMedico;
DESCRIBE Paciente;
DESCRIBE Medico;
DESCRIBE Usuario;
SELECT id_medico, Nombre, Primer_Apellido, Activo FROM Medico;
DESCRIBE Especialidad;
DESCRIBE Cita;

-- USAR SOLO UNA VEZ PARA INGRESAR
INSERT IGNORE INTO Medico (Nombre, Primer_Apellido, Segundo_Apellido, id_especialidad, Telefono, Email)
SELECT 'Andrés', 'Rojas', 'Soto', id_especialidad, '88881111', 'andres.rojas@example.com'
FROM Especialidad WHERE Nombre = 'Medicina General';

INSERT IGNORE INTO Medico (Nombre, Primer_Apellido, Segundo_Apellido, id_especialidad, Telefono, Email)
SELECT 'Laura', 'Jiménez', 'Mora', id_especialidad, '88882222', 'laura.jimenez@example.com'
FROM Especialidad WHERE Nombre = 'Pediatría';

INSERT IGNORE INTO Paciente (Primer_Apellido, Segundo_Apellido, Nombre, Cedula, Direccion, Email, FechaNacimiento, Telefono)
VALUES
    ('Solís', 'Vargas', 'María Fernanda', '101230456', 'San José, Costa Rica', 'maria.solis@example.com', '1990-03-12', '87771111'),
    ('Campos', 'Araya', 'José Pablo', '202340567', 'Heredia, Costa Rica', 'jose.campos@example.com', '1985-07-25', '87772222'),
    ('Quesada', 'Mora', 'Valeria', '303450678', 'Cartago, Costa Rica', 'valeria.quesada@example.com', '2001-11-02', '87773333');

-- Horario de lunes a viernes de 08:00 a 12:00 para los dos médicos de prueba
INSERT INTO HorarioMedico (id_medico, Dia, Hora_inicio, Hora_fin)
SELECT m.id_medico, d.Dia, '08:00:00', '12:00:00'
FROM Medico m
CROSS JOIN (
    SELECT 'Lunes' AS Dia
    UNION ALL SELECT 'Martes'
    UNION ALL SELECT 'Miércoles'
    UNION ALL SELECT 'Jueves'
    UNION ALL SELECT 'Viernes'
) d
WHERE m.Email IN ('andres.rojas@example.com', 'laura.jimenez@example.com');