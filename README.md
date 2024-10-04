# Sistema de Préstamos de Dinero para Empleados

Este es un sistema de gestión de préstamos de dinero a empleados desarrollado con **C# y Windows Forms**. La aplicación permite a una empresa manejar las solicitudes de préstamos de sus empleados, realizar el desembolso de los mismos y gestionar los pagos de cuotas. El sistema también genera reportes específicos sobre la situación de los préstamos y la morosidad de los empleados.

## Características Principales

- **Gestión de usuarios**: Administración de usuarios con distintos niveles de acceso (Administrador, Tesorería y Empleado).
- **Gestión de sucursales**: Manejo de las sucursales y municipios en los que los empleados laboran.
- **Solicitudes de préstamos**: Permite a los empleados realizar solicitudes de préstamos indicando monto, plazo y estado.
- **Aprobación de préstamos**: Los empleados de tesorería pueden aprobar o rechazar las solicitudes según el cargo del empleado y el monto solicitado.
- **Desembolso**: Gestión automática del desembolso de préstamos a la cuenta bancaria del empleado.
- **Pago de cuotas**: Los empleados pueden registrar el pago de sus cuotas mensuales, y el sistema controla la morosidad.
- **Reportes**:
  - Reporte de empleados morosos.
  - Total de préstamos por municipio.
  - Total de préstamos por sucursal.

## Tecnologías Utilizadas

- **Lenguaje**: C#
- **Plataforma**: Windows Forms
- **Base de Datos**: SQL Server (o base de datos de su elección)
- **Reportes**: Generación de reportes en PDF

## Requisitos

- Visual Studio 2022 o superior.
- .NET Framework 4.7.2 o superior.
- SQL Server (u otro sistema de bases de datos compatible).

## Instalación

1. **Clona este repositorio** en tu máquina local:

   ```bash
   git clone https://github.com/juanesCruz/ProyectoPrestamos.git
