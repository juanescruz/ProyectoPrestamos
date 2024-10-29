
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{

	public partial class PrincipalEmpleado : Form
	{
		public PrincipalEmpleado()
		{
			InitializeComponent();
			
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			VentanaSolicitud solitud= new VentanaSolicitud();
			solitud.Show();
		}
	}
}
