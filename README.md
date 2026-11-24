# Agenda Médica

Sistema de escritorio para administrar la agenda de una clínica: pacientes, médicos, especialidades, horarios de atención y citas, con control de usuarios por rol.

Proyecto del curso de Programación II, Universidad Internacional San Isidro Labrador.

**Integrantes:** Yariela Carmona Ureña, Brandon Iván Moya Sibaja, Fabián Matarrita Calderón y Luis Fernando Carvajal Amador.

## Requisitos

- Windows
- Visual Studio 2022 o superior, con la carga de trabajo de **desarrollo de escritorio con .NET**
- SDK de **.NET 10**
- **MySQL Server 8.0.16 o superior** (el script usa restricciones `CHECK`) y MySQL Workbench

## Instalación

1. Clone el repositorio:
   ```
   git clone https://github.com/yariurena/AgendaMedica.git
   ```
2. En MySQL Workbench, abra y ejecute completo el script `BaseDatos/agenda_medica.sql`. Crea la base `agenda_medica` con todas sus tablas y los datos iniciales (roles, estados, tipos de cita y especialidades).
3. **Opcional:** ejecute `BaseDatos/datos_prueba.sql` para cargar médicos, pacientes y horarios de ejemplo (lunes a viernes, de 8:00 a 12:00).
4. Revise la cadena de conexión en `AgendaMedica.DAL/ConexionBD.cs`. Por defecto usa `localhost`, puerto `3306` y el usuario `root`. Si su servidor MySQL usa otra contraseña u otro usuario, cámbielos ahí.
5. Abra `AgendaMedica.slnx` con Visual Studio, deje que restaure los paquetes y ejecute el proyecto `AgendaMedica.UI` (tecla `F5`).

## Primer inicio de sesión

La primera vez que se abre el sistema con la tabla de usuarios vacía, se crea automáticamente un administrador y se muestra un aviso con sus datos:

| Correo | Contraseña |
|---|---|
| `admin@agendamedica.com` | `Admin2026!` |

Desde **Administración → Usuarios** el administrador puede crear más usuarios.

## Roles y permisos

| Módulo | Administrador | Recepción |
|---|:---:|:---:|
| Pacientes | Sí | Sí |
| Citas | Sí | Sí |
| Reportes | Sí | Sí |
| Médicos | Sí | No |
| Especialidades | Sí | No |
| Horarios de médicos | Sí | No |
| Historial médico | Sí | No |
| Usuarios | Sí | No |

## Funciones principales

- Gestión de pacientes, médicos y especialidades (se desactivan en lugar de borrarse).
- Horarios de atención de cada médico.
- Citas: agendar, reprogramar, confirmar, cancelar y marcar como atendida o "no asistió".
- Consulta de la agenda por médico, paciente, fecha y estado.
- Historial médico por paciente.
- Reportes: citas por día y médico, citas canceladas y pacientes atendidos.
- Contraseñas guardadas cifradas (PBKDF2 con sal).

## Reglas de negocio

| Regla | Descripción |
|---|---|
| RN-01 | La cita debe quedar completa dentro del horario del médico |
| RN-02 | Un médico no puede tener dos citas que se crucen |
| RN-03 | Un paciente no puede tener dos citas que se crucen |
| RN-04 | Las citas duran 30, 45 o 60 minutos |
| RN-05 | Tipos de cita: presencial, virtual y urgencia |
| RN-06 | No se eliminan registros que dejen relaciones rotas (se desactivan) |
| RN-07 | Estados: Programada, Confirmada, Atendida, Cancelada, No asistió y Reprogramada |
| RN-08 | `Paciente` y `Medico` heredan de la clase base `Persona` |

## Arquitectura

Proyecto en tres capas, más un proyecto compartido de modelos:

```
AgendaMedica.UI        Presentación: formularios de Windows Forms
AgendaMedica.BL        Lógica de negocio: reglas, validaciones, sesión y permisos
AgendaMedica.DAL       Acceso a datos: consultas SQL parametrizadas y transacciones
AgendaMedica.Modelos   Clases compartidas (Paciente, Medico, Cita, Usuario...)
BaseDatos              Scripts SQL
```

La capa de presentación solo se comunica con la lógica de negocio, y esta con el acceso a datos.

## Tecnologías

C#, .NET 10, Windows Forms, MySQL y MySqlConnector. Control de versiones con Git.

## Documentación

La carpeta `Documentacion` incluye:

- Manual técnico
- Manual de usuario
- Pruebas funcionales con evidencias
- Declaración de uso de inteligencia artificial
- Diagramas entidad-relación y de arquitectura
