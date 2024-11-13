
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Proyecto_Prestamos
{

	public class SolicitudDao
	{
		private string connectionString = "Data Source=servidor;Initial Catalog=nombre_base_datos;User ID=usuario;Password=contraseña";
	
	public bool agregarSolicitud(Solicitud solicitud)
    {
      try
		{
		SqlCommand cmd = mfo.getConecte().getCon().CreateCommand();
		cmd.CommandText = "Insert into Solicitud (idSolicitud, estado, idEmpleado,monto, periodoMeses,fechaSolicitud) " +
			"Values('" +solicitud.GetIdSolicitud + "','" + solicitud.GetEstado + "','" + solicitud.GetIdEmpleado + "','" + solicitud.GetMonto+", "+solicitud.GetPeriodoMeses+","+solicitud.fechaSolicitud+")";
		
		cmd.Connection = mfo.getConecte().getCon();
		
		cmd.ExecuteNonQuery();
		MessageBox.Show("Solicitud agregada exitosamente", "Atención!");
		}
       catch (Exception ex)				
		{				
		MessageBox.Show("Error al agregar una solicitud: " + ex.Message, "Error");				
		}
    }
	
	 public string obtenerSolicitudes()
    {
       string solicitudes = "";
		string consulta = "select * from Solicitud";
		try{
			SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows){
				while (reader.Read()){
					solicitudes += reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + "\n";
				}
			}
			reader.Close();
		}
		catch (Exception ex){
			MessageBox.Show("Error al buscar las solicitudes: " + ex.Message, "Error");
		}
		return solicitudes;
	}

	 
	public bool eliminarSolicitud(String idSolicitud)
    {
   		bool resultado = false;
		string consulta = "Delete from Solicitud where idSolicitud = '" + idSolicitud + "'";
		try{
			SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
			cmd.ExecuteNonQuery();
			resultado = true;
			}
		catch (Exception ex){
			MessageBox.Show("Error al eliminar la solicitud: " + ex.Message, "Error");
		}
		return resultado;
	}
	
	public Solicitud obtenerSolicitudPorId(String idSolicitud)
	{
    	Solicitud solicitud = null;
		string consulta = "select * from Solicitud where idSolicitud = '" + idSolicitud + "' ";
		try
		{
			SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows)
			{
				reader.Read();
				string id = reader.GetValue(0).ToString();
				string estado = reader.GetValue(1).ToString();
				string idEmpleado = reader.GetValue(2).ToString();
				decimal monto= reader.GetDecimal(3);
				decimal periodoMeses= reader.GetDecimal(4);
				DateTime fechaSolicitud = reader.GetDateTime(5);
				solicitud = new Solicitud(id, estado, idEmpleado, monto, periodoMeses, fechaSolicitud);
			}
			reader.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error al buscar la solicitud: " + ex.Message, "Error");
		}
		return solicitud;
	}
	
	public List<Solicitud> obtenerSolicitudesPorEstado(string estado)
	{
    List<Solicitud> solicitudes = new List<Solicitud>();
    string consulta = "SELECT * FROM Solicitud WHERE estado = @estado";
    try
    {
        SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
        cmd.Parameters.AddWithValue("@estado", estado);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string id = reader.GetString(0); 
            string estado1 = reader.GetString(1);
            string idEmpleado = reader.GetString(2);
            decimal monto = reader.GetDecimal(3);
            decimal periodoMeses = reader.GetDecimal(4);
            DateTime fechaSolicitud = reader.GetDateTime(5);
            
            Solicitud solicitud = new Solicitud(id, estado1, idEmpleado, monto, periodoMeses, fechaSolicitud);
            solicitudes.Add(solicitud);
        }
        
        reader.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al buscar la solicitud: " + ex.Message, "Error");
    }
    
    return solicitudes;
}



	
	
	}
	
	
	
}
