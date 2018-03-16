using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ETipoVehiculoLavado
    {
        public int idVehiculoLavado { get; set; }
        public string vehiculoLavado { get; set; }
        public EServicioLavado servicioLavado { get; set; }
        public ETipoVehiculoLavado() {
            servicioLavado = new EServicioLavado();
        }
    }
}
