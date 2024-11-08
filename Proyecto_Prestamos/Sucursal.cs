using System;

namespace Proyecto_Prestamos
{
	public class Sucursal
	{
		public String idSucursal, nombre, nombreMunicipio, direccion;
		
		public Sucursal(String idSucursal, String nombre, String nombreMunicipio, String direccion)
		{
			this.idSucursal=idSucursal;
			this.nombre=nombre;
			this.nombreMunicipio=nombreMunicipio;
			this.direccion=direccion;
		}
		
		public Sucursal(){
			
		}
		
		public string getIdSucursal
	    {
	        get { return idSucursal; }
	    }
	
	    public string getNombre
	    {
	        get { return nombre; }
	    }
	
	    public string getNombreMunicipio
	    {
	        get { return nombreMunicipio; }
	    }
	
	    public string getDireccion
	    {
	        get { return direccion; }
	    }
		
		
		
	}
}