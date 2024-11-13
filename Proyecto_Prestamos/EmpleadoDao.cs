using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class EmpleadoDao
    {
        private MainForm mfo;
        private FormEmpleado formEmpleado;

        public EmpleadoDao(MainForm mfo)
        {
            this.mfo = mfo;
        }

        //Metodo que usé para instanciar empleado, no se si produzca error ya que hay dos instancias
        public EmpleadoDao(FormEmpleado formEmpleado)
        {
            this.formEmpleado = formEmpleado;
        }

        public void agregar(Empleado emp)
        {
            try
            {
                SqlCommand cmd = mfo.getConecte().getCon().CreateCommand();
                cmd.CommandText = "Insert into Empleado (idEmpleado, nombreEmpleado, cargo, idSucursal, nombreMunicipio, estado, salario) " +
                 "Values('" + emp.getIdEmpleado() + "','" + emp.getNombreEmpleado() + "','" + emp.getCargo() + "','" + emp.getIdSucursal() + "','" + emp.getNombreMunicipio() + "','" + emp.getEstado() + ")";
                cmd.Connection = mfo.getConecte().getCon();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado agregado exitosamente", "Atención!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message, "Error");
            }
        }

        public string buscarTodos()
        {
            string empleados = "";
            string consulta = "select * from Empleado";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empleados += reader.GetValue(0).ToString() + "   " + reader.GetValue(1).ToString() + "\n";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleados: " + ex.Message, "Error");
            }

            return empleados;
        }

        public Empleado buscarEmpleado(string idEmpleado)
        {
            Empleado emp = null;
            string consulta = "select * from Empleado where idEmpleado = '" + idEmpleado + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetValue(0).ToString();
                    string nombre = reader.GetValue(1).ToString();
                    string cargo = reader.GetValue(2).ToString();
                    string idSucursal = reader.GetValue(3).ToString();
                    string nombreMunicipio = reader.GetValue(4).ToString();
                    string estado = reader.GetValue(5).ToString();

                    emp = new Empleado(id, nombre, cargo, idSucursal, nombreMunicipio, estado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
            }

            return emp;
        }


        public bool editar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "update Empleado set nombreEmpleado = '" + emp.getNombreEmpleado() + "', cargo = '" + emp.getCargo() + "', " +
                "idSucursal = '" + emp.getIdSucursal() + "', nombreMunicipio = '" + emp.getNombreMunicipio() + "', estado = '" + emp.getEstado() +  " " +
                "where idEmpleado = '" + emp.getIdEmpleado() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar empleado: " + ex.Message, "Error");
            }

            return resultado;
        }


        public bool eliminar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "Delete from Empleado where idEmpleado = '" + emp.getIdEmpleado() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex.Message, "Error");
            }

            return resultado;
        }
    }
}
