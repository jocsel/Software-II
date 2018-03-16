using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ELavado
    {
        public int idLavado { get; set; }
        public decimal total{ get; set; }
        public DateTime? fecha{ get; set; }
        public string placa { get; set; }
        public ETipoVehiculoLavado tipoVehiculoLavado { get; set; }
        public EEmpleado empleado { get; set; }
        public EServicioLavado servicio = new EServicioLavado();

        public ELavado() {
            tipoVehiculoLavado = new ETipoVehiculoLavado();
            empleado = new EEmpleado();
            servicio = new EServicioLavado();
        }
    }
}
