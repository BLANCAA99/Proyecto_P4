using Applicacion.Usuarios.Commands.DeleteUserCommand;
using Applicacion.Usuarios.Commands.UpdateUserCommand;
using Applicacion.Usuarios.Queries.GetUserByIdQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final___Blanca_Arias
{
    public partial class Modificar_Usuario : Form
    {
        private readonly GetUserByIdQuery getUserByIdQuery;
        private readonly UpdateUserCommand updateUserCommand;
        private readonly DeleteUserCommand deleteUserCommand;
        public Modificar_Usuario()
        {
            InitializeComponent();
            this.updateUserCommand = new UpdateUserCommand();
            this.getUserByIdQuery = new GetUserByIdQuery();
            this.deleteUserCommand = new DeleteUserCommand();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var model = this.getUserByIdQuery.Execute(Convert.ToInt32(txtCodigo.Text));
            txtNombre.Text = model.NombreCompleto;
            txtIdentidad.Text = model.NumeroIdentidad;
            txtCorreo.Text = model.CorreoElectronico;
            txtTelefono.Text = model.Telefono;
            if (model.Genero == "M") {
                rbtnMasculino.Checked = true;
            }
            else
            {
                rbtnFemenino.Checked = true;
            }
            mskContraseña.Text = model.Contraseña;
            cboRol.SelectedIndex = Convert.ToInt32(model.Rol) - 1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var model = new UpdateUserCommandModel();
            model.NombreCompleto = txtNombre.Text;
            model.Codigo = Convert.ToInt32(txtCodigo.Text);
            model.Contraseña = mskContraseña.Text;
            model.NumeroIdentidad = txtIdentidad.Text;
            model.Rol = (cboRol.SelectedIndex +1).ToString();
            model.Genero = rbtnMasculino.Checked ? "M" : "F"; 
            model.CorreoElectronico = txtCorreo.Text;
            model.Telefono = txtTelefono.Text;
            this.updateUserCommand.Execute(model);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.deleteUserCommand.Execute (Convert.ToInt32(txtCodigo.Text));
            LimpiarControlesDeTexto(this);
            mskContraseña.Clear();
            cboRol.SelectedIndex = -1;
        }
        private void LimpiarControlesDeTexto(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is TextBox textBox)
                {
                    textBox.Text = string.Empty; // Limpia el contenido del TextBox
                }
                else if (childControl.HasChildren)
                {
                    LimpiarControlesDeTexto(childControl); // Recursivamente limpia los controles hijos
                }
            }
        }
    }
}
