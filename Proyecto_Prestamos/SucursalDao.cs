using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Proyecto_Prestamos
{
	

	public class SucursalDao
	{
		private MainForm mfo;
		private CRUDSucursal crudSucursal;
		
	public SucursalDao(MainForm mfo){
		this.mfo=mfo;
	}
	public SucursalDao(CRUDSucursal crudSucursal){
		this.crudSucursal=crudSucursal;
	}
		
    public bool agregarSucursal(Sucursal sucursal)
    {
       try
		{
		SqlCommand cmd = mfo.getConecte().getCon().CreateCommand();
		cmd.CommandText = "Insert into Sucursal (idSucursal, nombre, nombreMunicipio, direccion) " +
			"Values('" +sucursal.getIdSucursal() + "','" + sucursal.getNombre() + "','" + sucursal.getNombreMunicipio() + "','" + sucursal.getDireccion()+ ")";
		
		cmd.Connection = mfo.getConecte().getCon();
		
		cmd.ExecuteNonQuery();
		MessageBox.Show("Sucursal agregada exitosamente", "Atención!");
		}
       catch (Exception ex)				
		{				
		MessageBox.Show("Error al agregar una sucursal: " + ex.Message, "Error");				
		}
    }


    public string obtenerSucursales()
    {
       string sucursales = "";
		string consulta = "select * from Sucursal";
		try{
			SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows){
				while (reader.Read()){
					sucursales += reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + "\n";
				}
			}
			reader.Close();
		}
		catch (Exception ex){
			MessageBox.Show("Error al buscar las sucursales: " + ex.Message, "Error");
		}
		return sucursales;
	}


 
    public Sucursal obtenerSucursal(string idSucursal)
    {
        Sucursal sucursal = null;
		string consulta = "select * from Sucursal where idSucursal = '" + idSucursal + "' ";
		try
		{
			SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows)
			{
				reader.Read();
				string id = reader.GetValue(0).ToString();
				string nombre = reader.GetValue(1).ToString();
				string nMunicipio = reader.GetValue(2).ToString();
				string direccion = reader.GetValue(3).ToString();
				sucursal = new Sucursal(id, nombre, nMunicipio, direccion);
			}
			reader.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
		}
		return sucursal;
    }
    
    public bool actualizarSucursal(Sucursal sucursal){
    	bool resultado = false;
		string consulta = "update Sucursal set nombre = '" + sucursal.getNombre() + "', nombreMunicipio = '" + sucursal.getNombreMunicipio() + "', " +
		"direccion = '" + sucursal.getDireccion() +
		"where idEmpleado = '" + sucursal.getIdSucursal() + "'";
		try
		{
			SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
			cmd.ExecuteNonQuery();
			resultado = true;
		}
		catch (Exception ex)
		{
		MessageBox.Show("Error al editar sucursal: " + ex.Message, "Error");
		}
		return resultado;
	}
    
	public bool eliminar(Sucursal sucursal)
	{
		bool resultado = false;
		string consulta = "Delete from Sucursal where idEmpleado = '" + sucursal.getIdSucursal() + "'";
		try{
			SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
			cmd.ExecuteNonQuery();
			resultado = true;
			}
		catch (Exception ex){
			MessageBox.Show("Error al eliminar empleado: " + ex.Message, "Error");
		}
		return resultado;
		}
	}

	
}
