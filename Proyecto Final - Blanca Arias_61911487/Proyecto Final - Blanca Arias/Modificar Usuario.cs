using Applicacion.Usuarios.Commands.DeleteUserCommand;
using Applicacion.Usuarios.Commands.UpdateUserCommand;
using Applicacion.Usuarios.Queries.GetUserByIdQuery;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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

            string rolUsuarioAutenticado = Auth.RolUsuario;
            if (rolUsuarioAutenticado == "1")
            {
                int codigoUsuarioBuscado = Convert.ToInt32(txtCodigo.Text);

                var model = this.getUserByIdQuery.Execute(codigoUsuarioBuscado);
                MostrarInformacionUsuario(model);
            }
            else if (rolUsuarioAutenticado == "2")
            {
                int codigoUsuarioBuscado = Convert.ToInt32(txtCodigo.Text);

                var model = this.getUserByIdQuery.Execute(codigoUsuarioBuscado);

                if (model.Rol == "3")
                {
                    MostrarInformacionUsuario(model);
                }
                else
                {
                    MessageBox.Show("No tienes permiso para ver o editar este usuario.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso para ver o editar usuarios.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void MostrarInformacionUsuario(GetUserByIdQueryModel model)
        {
            txtNombre.Text = model.NombreCompleto;
            txtIdentidad.Text = model.NumeroIdentidad;
            txtCorreo.Text = model.CorreoElectronico;
            txtTelefono.Text = model.Telefono;
            if (model.Genero == "M")
            {
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
