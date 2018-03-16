using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class frmBuscarEmpleado : Form
    {
        public string empleado;
        public string cedula;
        public frmBuscarEmpleado()
        {
            InitializeComponent();
        }

        private void frmBuscarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                NEmpleado gestio = new NEmpleado();
                List<EEmpleado> listaEmpleado = gestio.listaEmpleado();
                var lista = (from user in listaEmpleado
                             select new
                             {
                                 user.nombres,
                                 user.apellidos,
                                 user.fechaNacimiento,
                                 user.cedula,
                                 user.direccion,
                                 user.celular,
                                 user.salario,
                                 user.estado
                             }).ToList();
                dgvEmpleado.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                empleado = dgvEmpleado.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                cedula = dgvEmpleado.Rows[e.RowIndex].Cells["cedula"].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void dgvEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
