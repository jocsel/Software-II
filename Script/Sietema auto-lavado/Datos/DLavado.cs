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
    public class DLavado
    {
        public List<ELavado> SelectRow() {

            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_lavado";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<ELavado> listaLavado = new List<ELavado>();
                while (leer.Read()) {
                    ELavado entidadesLavado = new ELavado();
                    if (leer.IsDBNull(0))
                        entidadesLavado.empleado.nombres = null;
                    else
                        entidadesLavado.empleado.nombres = leer.GetString(0);
                    if (leer.IsDBNull(1))
                        entidadesLavado.tipoVehiculoLavado.vehiculoLavado = null;
                    else
                        entidadesLavado.tipoVehiculoLavado.vehiculoLavado = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        entidadesLavado.placa = null;
                    else
                        entidadesLavado.placa = leer.GetString(2);
                    if (leer.IsDBNull(3))
                        entidadesLavado.servicio.servicioLavado = null;
                    else
                        entidadesLavado.servicio.servicioLavado = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        entidadesLavado.servicio.precio = 0;
                    else
                        entidadesLavado.servicio.precio = leer.GetInt32(5);
                    listaLavado.Add(entidadesLavado);
                }
                conex.Close();
                leer.Close();
                return listaLavado;

            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
