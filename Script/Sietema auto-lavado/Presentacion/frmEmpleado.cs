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
    public partial class frmEmpleado : Form
    {
        List<EEmpleado> listaEmpleado;
        bool modificar;
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            desactivarTetbox();
            try {
                actualizarGrid();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        public void actualizarGrid()
        {
            NEmpleado gestiondatos = new NEmpleado();
            listaEmpleado = gestiondatos.listaEmpleado();

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

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EEmpleado UEmpleado = new EEmpleado();
                    UEmpleado.apellidos = txtApellido.Text;
                    UEmpleado.cedula = txtcedula.Text;
                    UEmpleado.celular = Convert.ToInt32(txtcelular.Text);
                    UEmpleado.direccion = txtdireccion.Text;
                    UEmpleado.estado = cmbEstado.Text;
                    UEmpleado.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                    UEmpleado.salario = Convert.ToDecimal(txtSalario.Text);
                    UEmpleado.nombres = txtNombre.Text;

                    NEmpleado updateEmpleado = new NEmpleado();
                    updateEmpleado.UpdateEmpleado(UEmpleado);
                    MessageBox.Show("Se modifico sastifactoriamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    EEmpleado IEmpleado = new EEmpleado();
                    IEmpleado.apellidos = txtApellido.Text;
                    IEmpleado.cedula = txtcedula.Text;
                    IEmpleado.celular = Convert.ToInt32(txtcelular.Text);
                    IEmpleado.direccion = txtdireccion.Text;
                    IEmpleado.estado = cmbEstado.Text;
                    IEmpleado.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                    IEmpleado.salario = Convert.ToDecimal(txtSalario.Text);
                    IEmpleado.nombres = txtNombre.Text;

                    NEmpleado updateEmpleado = new NEmpleado();
                    updateEmpleado.insertarEmpleado(IEmpleado);
                    MessageBox.Show("Se guardo sastifactoriamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                actualizarGrid();
                limpiar();
                modificar = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                txtApellido.Text = dgvEmpleado.Rows[e.RowIndex].Cells["apellidos"].Value.ToString();
                txtcedula.Text = dgvEmpleado.Rows[e.RowIndex].Cells["cedula"].Value.ToString();
                txtcelular.Text = ( dgvEmpleado.Rows[e.RowIndex].Cells["celular"].Value.ToString());
                txtdireccion.Text = dgvEmpleado.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                txtFechaNac.Text = dgvEmpleado.Rows[e.RowIndex].Cells["fechaNacimiento"].Value.ToString();
                txtNombre.Text = dgvEmpleado.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                txtSalario.Text = dgvEmpleado.Rows[e.RowIndex].Cells["salario"].Value.ToString();
                cmbEstado.Text = dgvEmpleado.Rows[e.RowIndex].Cells["estado"].Value.ToString();
                txtcedula.Enabled = false;
                btnNuevo.Enabled = false;
                btnModificar.Enabled = true;
                btnguardar.Enabled = false;
                btnCancelar.Enabled = true;
                desactivarTetbox();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificar = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnguardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtApellido.Enabled = true;
            txtcedula.Enabled = false;
            txtcelular.Enabled = true;
            txtdireccion.Enabled = true;
            txtFechaNac.Enabled = true;
            txtNombre.Enabled = true;
            txtSalario.Enabled = true;
            cmbEstado.Enabled = true;
        }
        
        public void desactivarTetbox()
        {
            txtApellido.Enabled = false;
            txtcedula.Enabled = false;
            txtcelular.Enabled = false;
            txtdireccion.Enabled = false;
            txtFechaNac.Enabled = false;
            txtNombre.Enabled = false;
            txtSalario.Enabled = false;
            cmbEstado.Enabled = false;

        }
        private void limpiar()
        {
            txtApellido.Text = "";
            txtcedula.Text = "";
            txtcelular.Text = "";
            txtdireccion.Text = "";
            txtFechaNac.Text = "";
            txtNombre.Text = "";
            txtSalario.Text = "";
            cmbEstado.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnguardar.Enabled = false;
            btnCancelar.Enabled = false;
            limpiar();
            desactivarTetbox();
        }
        public void activarTexbox() {
            txtcedula.Enabled = true;
            txtApellido.Enabled = true;
            txtcedula.Enabled = true;
            txtcelular.Enabled = true;
            txtdireccion.Enabled = true;
            txtFechaNac.Enabled = true;
            txtNombre.Enabled = true;
            txtSalario.Enabled = true;
            cmbEstado.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnguardar.Enabled = true;
            btnCancelar.Enabled = true;
            activarTexbox();
        }
    }
}
