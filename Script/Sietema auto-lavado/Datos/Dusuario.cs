using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Dusuario
    {
        public List<EUsuario> SelectRow()
        {

            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBAutoLavado..[sp_Usuario]";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EUsuario> listaUsuarios = new List<EUsuario>();

                while (leer.Read()) {
                    EUsuario entidadesUsuario = new EUsuario();
                    if (leer.IsDBNull(0))
                        entidadesUsuario.Empleado.apellidos = null;
                    else
                        entidadesUsuario.Empleado.apellidos = leer.GetString(0);

                    if (leer.IsDBNull(1))
                        entidadesUsuario.Permiso.usuario = null;
                    else
                        entidadesUsuario.Permiso.usuario = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        entidadesUsuario.password = null;
                    else
                        entidadesUsuario.password = leer.GetString(2);

                    if (leer.IsDBNull(3))
                        entidadesUsuario.Permiso.venta = false;
                    else
                        entidadesUsuario.Permiso.venta = leer.GetBoolean(3);
                    if (leer.IsDBNull(4))
                        entidadesUsuario.Permiso.mantenimiento = false;
                    else
                        entidadesUsuario.Permiso.mantenimiento = leer.GetBoolean(4);
                    if (leer.IsDBNull(5))
                        entidadesUsuario.Permiso.lavado = false;
                    else
                        entidadesUsuario.Permiso.lavado = leer.GetBoolean(5);
                    if (leer.IsDBNull(6))
                        entidadesUsuario.Permiso.compra = false;
                    else
                        entidadesUsuario.Permiso.compra = leer.GetBoolean(6);
                    if (leer.IsDBNull(7))
                        entidadesUsuario.Permiso.empleado = false;
                    else
                        entidadesUsuario.Permiso.empleado = leer.GetBoolean(7);
                    if (leer.IsDBNull(8))
                        entidadesUsuario.Permiso.Tusuario = false;
                    else
                        entidadesUsuario.Permiso.Tusuario = leer.GetBoolean(8);
                    if (leer.IsDBNull(9))
                        entidadesUsuario.Permiso.producto = false;
                    else
                        entidadesUsuario.Permiso.producto = leer.GetBoolean(9);
                    if (leer.IsDBNull(10))
                        entidadesUsuario.Permiso.proveedor = false;
                    else
                        entidadesUsuario.Permiso.proveedor = leer.GetBoolean(10);
                    if (leer.IsDBNull(11))
                        entidadesUsuario.Estado = null;
                    else
                        entidadesUsuario.Estado = leer.GetString(11);

                    listaUsuarios.Add(entidadesUsuario);                    
                }
                conex.Close();
                leer.Close();
                return listaUsuarios;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void InsertRow(EUsuario Iusuario)
        {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBAutoLavado..[sp_Usuario]";
                cmd.Parameters.Add("@i_operacion",SqlDbType.VarChar,1).Value = "I";

                cmd.Parameters.AddWithValue("@i_usuario",Iusuario.usuario);
                cmd.Parameters.AddWithValue("@i_password",Iusuario.password);
                cmd.Parameters.AddWithValue("@i_cedula",Iusuario.Empleado.cedula);
                cmd.Parameters.AddWithValue("@i_Pusuario", Iusuario.usuario);
                cmd.Parameters.AddWithValue("@i_venta",Iusuario.Permiso.venta);
                cmd.Parameters.AddWithValue("@i_mantenimiento",Iusuario.Permiso.mantenimiento);
                cmd.Parameters.AddWithValue("@i_lavado",Iusuario.Permiso.lavado);
                cmd.Parameters.AddWithValue("@i_compra",Iusuario.Permiso.compra);
                cmd.Parameters.AddWithValue("@i_empleado",Iusuario.Permiso.empleado);
                cmd.Parameters.AddWithValue("@i_Tusuario",Iusuario.Permiso.Tusuario);
                cmd.Parameters.AddWithValue("@i_producto",Iusuario.Permiso.producto);
                cmd.Parameters.AddWithValue("@i_proveedor",Iusuario.Permiso.proveedor);
                cmd.Parameters.AddWithValue("@i_estado", Iusuario.Estado);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex) {
                throw ex;
            }

        }
        public void UpdateRow(EUsuario Uusuario)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBAutoLavado..sp_Usuario";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "U";

                cmd.Parameters.AddWithValue("@i_usuario", Uusuario.usuario);
                cmd.Parameters.AddWithValue("@i_password", Uusuario.password);
                cmd.Parameters.AddWithValue("@i_Pusuario", Uusuario.usuario);
                cmd.Parameters.AddWithValue("@i_venta", Uusuario.Permiso.venta);
                cmd.Parameters.AddWithValue("@i_mantenimiento", Uusuario.Permiso.mantenimiento);
                cmd.Parameters.AddWithValue("@i_lavado", Uusuario.Permiso.lavado);
                cmd.Parameters.AddWithValue("@i_compra", Uusuario.Permiso.compra);
                cmd.Parameters.AddWithValue("@i_empleado", Uusuario.Permiso.empleado);
                cmd.Parameters.AddWithValue("@i_Tusuario", Uusuario.Permiso.Tusuario);
                cmd.Parameters.AddWithValue("@i_producto", Uusuario.Permiso.producto);
                cmd.Parameters.AddWithValue("@i_proveedor", Uusuario.Permiso.proveedor);
                cmd.Parameters.AddWithValue("@i_estado", Uusuario.Estado);
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
