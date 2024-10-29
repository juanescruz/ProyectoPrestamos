using System;

namespace Proyecto_Prestamos
{
	
	public class Solicitud
	
	{
		private String idSolicitud, estado;
		private int monto, periodoMeses;
		private DateTime  fechaSolicitud;
		//tasa de interes derivada
		public Solicitud(String idSolicitud, String estado,int monto, int periodoMeses, DateTime  fechaSolicitud)
		{
			this.idSolicitud=idSolicitud;
			this.estado=estado;
			this.monto=monto;
			this.periodoMeses=periodoMeses;
			this.fechaSolicitud=fechaSolicitud;
		}
	}
}
