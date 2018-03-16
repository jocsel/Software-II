using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DEmpleado
    {
        public List<EEmpleado> obtenerListaEmpleado()
        {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "S";
                cmd.CommandText = "sp_empleado";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EEmpleado> listaEmpleado = new List<EEmpleado>();
                while (leer.Read()) {
                    EEmpleado datosEmpleado = new EEmpleado();
                    if (leer.IsDBNull(0))
                        datosEmpleado.nombres = null;
                    else
                        datosEmpleado.nombres = leer.GetString(0);
                    if (leer.IsDBNull(1))
                        datosEmpleado.apellidos = null;
                    else
                        datosEmpleado.apellidos = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        datosEmpleado.fechaNacimiento = null;
                    else
                        datosEmpleado.fechaNacimiento = leer.GetDateTime(2);
                    if (leer.IsDBNull(3))
                        datosEmpleado.cedula = null;
                    else
                        datosEmpleado.cedula = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        datosEmpleado.direccion = null;
                    else
                        datosEmpleado.direccion = leer.GetString(4);
                    if (leer.IsDBNull(5))
                        datosEmpleado.celular = null;
                    else
                        datosEmpleado.celular = leer.GetInt32(5);
                    if (leer.IsDBNull(6))
                        datosEmpleado.salario = null;
                    else
                        datosEmpleado.salario = leer.GetDecimal(6);
                    if (leer.IsDBNull(7))
                        datosEmpleado.estado = null;
                    else
                        datosEmpleado.estado = leer.GetString(7);
                    listaEmpleado.Add(datosEmpleado);
                }
                conex.Close();
                leer.Close();
                return listaEmpleado;

            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EEmpleado IEmpleaado)
        {

            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_empleado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_fechaNac", IEmpleaado.fechaNacimiento);
                cmd.Parameters.AddWithValue("@i_celular", IEmpleaado.celular);
                cmd.Parameters.AddWithValue("@i_direccion", IEmpleaado.direccion);
                cmd.Parameters.AddWithValue("@i_cedula", IEmpleaado.cedula);
                cmd.Parameters.AddWithValue("@i_apellidos", IEmpleaado.apellidos);
                cmd.Parameters.AddWithValue("@i_nombres", IEmpleaado.nombres);
                cmd.Parameters.AddWithValue("@i_salario", IEmpleaado.salario);
                cmd.Parameters.AddWithValue("@i_estado", IEmpleaado.estado);
                cmd.Parameters.AddWithValue("@idEmpleado", IEmpleaado.idEmpleado);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            public void UpdateRow(EEmpleado UEmpleaado)
        {

            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_empleado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "U";
                cmd.Parameters.AddWithValue("@i_fechaNac", UEmpleaado.fechaNacimiento);
                cmd.Parameters.AddWithValue("@i_celular", UEmpleaado.celular);
                cmd.Parameters.AddWithValue("@i_direccion", UEmpleaado.direccion);
                cmd.Parameters.AddWithValue("@i_cedula", UEmpleaado.cedula);
                cmd.Parameters.AddWithValue("@i_apellidos", UEmpleaado.apellidos);
                cmd.Parameters.AddWithValue("@i_nombres", UEmpleaado.nombres);
                cmd.Parameters.AddWithValue("@i_salario", UEmpleaado.salario);
                cmd.Parameters.AddWithValue("@i_estado", UEmpleaado.estado);
                cmd.Parameters.AddWithValue("@idEmpleado", UEmpleaado.idEmpleado);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
