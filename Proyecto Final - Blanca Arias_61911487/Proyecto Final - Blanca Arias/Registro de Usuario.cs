using Applicacion.Usuarios.Commands.CreateUserCommand;
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
    public partial class Registro_de_Usuario : Form
    {
        private readonly CreateUserCommand createUserCommand;
        public Registro_de_Usuario()
        {
            InitializeComponent();
            this.createUserCommand = new CreateUserCommand();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            CreateUserCommandModel model = new CreateUserCommandModel();
            model.Codigo = Convert.ToInt32(txtCodigo.Text);
            model.NombreCompleto = txtNombre.Text;
            model.NumeroIdentidad = txtIdentidad.Text;
            model.Contraseña = mskContraseña.Text;
            model.CorreoElectronico = txtCorreo.Text;
            model.Telefono = txtTelefono.Text;
            if (rbtnFemenino.Checked)
            {
                model.Genero = "F";
            }
            else if (rbtnMasculino.Checked)
            {
                model.Genero = "M";
            }
            model.Rol =( cboRol.SelectedIndex + 1).ToString();
            this.createUserCommand.Execute(model);
        }
    }
}
