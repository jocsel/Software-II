using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidad;

namespace Presentacion
{
    public partial class frmUsuario : Form
    {
        List<EUsuario> listaUsuarios;
        bool modificar;
        public void actualizarLista()
            {
            Nusuario gestioUsuario = new Nusuario();
            listaUsuarios = gestioUsuario.SelectRow();
            var lista = (from user in listaUsuarios
                         select new
                         {
                            Trabajador = user.Empleado.apellidos,
                             user.Permiso.usuario,
                             user.password,
                             user.Permiso.venta,
                             user.Permiso.mantenimiento,
                             user.Permiso.lavado,
                             user.Permiso.compra,
                             user.Permiso.empleado,
                             user.Permiso.Tusuario,
                             user.Permiso.producto,
                             user.Permiso.proveedor,
                             user.Estado,
                            

                         }).ToList();
            dgvUsuarios.DataSource = lista;
                
            }
        public frmUsuario()
        {
            InitializeComponent();
            btnCancelar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarLista();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            txtEmpleado.Enabled = false;
            cmbEstado.Enabled = true;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                if (modificar)
                {
                    EUsuario Uusuario = new EUsuario();
                    Uusuario.Empleado.nombres = txtEmpleado.Text;
                    Uusuario.usuario = txtNombreUsuario.Text;
                    Uusuario.password = txtContraseña.Text;
                    Uusuario.Permiso.venta = chkVenta.Checked;
                    Uusuario.Permiso.mantenimiento = chkMantenimiento.Checked;
                    Uusuario.Permiso.lavado = chkLavado.Checked;
                    Uusuario.Permiso.compra = chkCompra.Checked;
                    Uusuario.Permiso.empleado = chkEmpleado.Checked;
                    Uusuario.Permiso.Tusuario = chkUsuario.Checked;
                    Uusuario.Permiso.producto = chkProducto.Checked;
                    Uusuario.Permiso.proveedor = chkProveedor.Checked;
                    Uusuario.Estado = cmbEstado.Text;

                    Nusuario UpUsuario = new Nusuario();
                    UpUsuario.UpdateRow(Uusuario);
                    MessageBox.Show("Cambios realizados sastifactoriamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {

                    EUsuario Iusuario = new EUsuario();
                    Iusuario.Empleado.cedula = txtEmpleado.Text;
                    Iusuario.usuario = txtNombreUsuario.Text;
                    Iusuario.password = txtContraseña.Text;
                    Iusuario.Permiso.venta = chkVenta.Checked;
                    Iusuario.Permiso.mantenimiento = chkMantenimiento.Checked;
                    Iusuario.Permiso.lavado = chkLavado.Checked;
                    Iusuario.Permiso.compra = chkCompra.Checked;
                    Iusuario.Permiso.empleado = chkEmpleado.Checked;
                    Iusuario.Permiso.Tusuario = chkUsuario.Checked;
                    Iusuario.Permiso.producto = chkProducto.Checked;
                    Iusuario.Permiso.proveedor = chkProveedor.Checked;
                    Iusuario.Estado = cmbEstado.Text;

                    Nusuario InUsuario = new Nusuario();
                    InUsuario.InsertRow(Iusuario);
                    MessageBox.Show("Se guardo sastifactoriamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                actualizarLista();
                modificar = false;
                Limpiar();
                Deshabilitar();
                btnCancelar.Enabled = false;
                btnModificar.Enabled = false;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);          
                    }
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado buscarEmpleado = new frmBuscarEmpleado();
            if (buscarEmpleado.ShowDialog() == DialogResult.OK)
            {
                txtEmpleado.Text = buscarEmpleado.cedula.ToString();

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
            cmbEstado.Enabled = true;
            modificar = true;
            txtNombreUsuario.Enabled = false;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                txtEmpleado.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Trabajador"].Value.ToString(); 
                txtNombreUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["usuario"].Value.ToString();
                txtContraseña.Text = dgvUsuarios.Rows[e.RowIndex].Cells["password"].Value.ToString();
                chkVenta.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["venta"].Value.ToString());
                chkMantenimiento.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["mantenimiento"].Value.ToString());
                chkLavado.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["lavado"].Value.ToString()); 
                chkCompra.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["compra"].Value.ToString()); 
                chkEmpleado.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["empleado"].Value.ToString());
                chkUsuario.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["Tusuario"].Value.ToString());
                chkProducto.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["producto"].Value.ToString());
                chkProveedor.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["proveedor"].Value.ToString()); 
                cmbEstado.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
                btnNuevo.Enabled = false;
                txtEmpleado.Enabled = false;
                txtContraseña.Enabled = false;
                txtNombreUsuario.Enabled = false;
                
            }

            
        }
        public void Habilitar()
        {
            txtContraseña.Enabled = true;
            txtContraseña.Enabled = true;
            txtNombreUsuario.Enabled = true;
        }
        public void Deshabilitar()
        {
            txtContraseña.Enabled = false;
            txtContraseña.Enabled = false;
            txtNombreUsuario.Enabled = false;
            cmbEstado.Enabled = false;
        }
        public void Limpiar()
        {
            txtContraseña.Text = "";
            txtEmpleado.Text = "";
            txtNombreUsuario.Text = "";
            chkVenta.Checked = false;
            chkMantenimiento.Checked = false;
            chkLavado.Checked = false;
            chkCompra.Checked = false;
            chkEmpleado.Checked = false;
            chkUsuario.Checked = false;
            chkProducto.Checked = false;
            chkProveedor.Checked = false;
            cmbEstado.Text = "";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
