using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.Data;

namespace Negocio
{
    public class NEmpleado
    {
        public List<EEmpleado> listaEmpleado() {
            try {
                DEmpleado datosEmpleado = new DEmpleado();
                return datosEmpleado.obtenerListaEmpleado();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void insertarEmpleado(EEmpleado IEmpleado)
        {
            try
            {
                if (IEmpleado.apellidos.Length == 0)
                    throw new ArgumentException("Ingresa el apellido");
                if (IEmpleado.fechaNacimiento == null)
                    throw new ArgumentException("Ingresa la fecha de nacimiento");
                if (IEmpleado.celular == 0)
                    throw new ArgumentException("Ingresa celular");
                if (IEmpleado.direccion.Length == 0)
                    throw new ArgumentException("Ingresa la direccion");
                if (IEmpleado.cedula.Length == 0)
                    throw new ArgumentException("Ingresa la cedula");
                if (IEmpleado.nombres.Length == 0)
                    throw new ArgumentException("Ingresa los nombres");
                if (IEmpleado.salario == 0)
                    throw new ArgumentException("Ingresa el salario");
                if (IEmpleado.estado.Length == 0)
                    throw new ArgumentException("Ingresa el estado");
                DEmpleado gestionEmpleado = new DEmpleado();
                gestionEmpleado.InsertRow(IEmpleado);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void UpdateEmpleado(EEmpleado UEmpleado)
        {
            try
            {
                if (UEmpleado.apellidos.Length == 0)
                    throw new ArgumentException("Ingresa el apellido");
                if (UEmpleado.fechaNacimiento == null)
                    throw new ArgumentException("Ingresa la fecha de nacimiento");
                if (UEmpleado.celular == 0)
                    throw new ArgumentException("Ingresa celular");
                if (UEmpleado.direccion.Length == 0)
                    throw new ArgumentException("Ingresa la direccion");
                if (UEmpleado.cedula.Length == 0)
                    throw new ArgumentException("Ingresa la cedula");
                if (UEmpleado.nombres.Length == 0)
                    throw new ArgumentException("Ingresa los nombres");
                if (UEmpleado.salario == 0)
                    throw new ArgumentException("Ingresa el salario");
                if (UEmpleado.estado.Length == 0)
                    throw new ArgumentException("Ingresa el estado");
                DEmpleado gestionEmpleado = new DEmpleado();
                gestionEmpleado.UpdateRow(UEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
