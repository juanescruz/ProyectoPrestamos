using System;

namespace Proyecto_Prestamos
{
	public class Sucursal
	{
		private String idSucursal, nombre, nombreMunicipio;
		private int numEmpleados;
		public Sucursal(String idSucursal, String nombre, String nombreMunicipio, int numEmpleados)
		{
			this.idSucursal=idSucursal;
			this.nombre=nombre;
			this.nombreMunicipio=nombreMunicipio;
			this.numEmpleados=numEmpleados;
		}
		
	}
}