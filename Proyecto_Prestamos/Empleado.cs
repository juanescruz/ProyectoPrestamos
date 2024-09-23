using System;

namespace Proyecto_Prestamos
{
	public class Empleado
	{
		private String idEmpleado, nombreEmpleado, cargo, idSucursal, nombreMunicipio, estado;
		//Salario derivado
		public Empleado(String idEmpleado, String nombreEmpleado, String cargo, String idSucursal, String nombreMunicipio,String estado)
		{
			this.idEmpleado=idEmpleado;
			this.nombreEmpleado=nombreEmpleado;
			this.cargo=cargo;
			this.idSucursal=idSucursal;
			this.nombreMunicipio=nombreMunicipio;
			this.estado=estado;
		}
	}
}
