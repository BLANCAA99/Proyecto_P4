using Applicacion.Usuarios.Commands.CreateUserCommand;
using DataAccess;
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
        private readonly Util util;
        public Registro_de_Usuario()
        {
            this.util = new Util();
            InitializeComponent();
            this.createUserCommand = new CreateUserCommand();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Auth.RolUsuario == "1") 
            {
                GuardarUsuario();
            }
            else if (Auth.RolUsuario == "2") 
            {
                if (cboRol.SelectedItem.ToString() == "Digitador")
                {
                    GuardarUsuario();
                }
                else
                {
                    MessageBox.Show("Un Oficial Médico solo puede guardar usuarios con el rol de 'Digitador de Datos'.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void GuardarUsuario()
        {
            try
            {
                int codigoUsuario = Convert.ToInt32(txtCodigo.Text);
                bool usuarioExiste = UsuarioExiste(codigoUsuario);

                if (usuarioExiste)
                {
                    MessageBox.Show("El usuario con el mismo código ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CreateUserCommandModel model = new CreateUserCommandModel();
                    model.Codigo = codigoUsuario;
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
                    model.Rol = (cboRol.SelectedIndex + 1).ToString();
                    this.createUserCommand.Execute(model);
                    this.util.LimpiarControlesDeTexto(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el formulario");
            }
        }
        private bool UsuarioExiste(int codigoUsuario)
        {
            using (var dbContext = new Proyecto_FinalEntities())
            {
                var usuarioExistente = dbContext.Usuarios.FirstOrDefault(u => u.Codigo == codigoUsuario);
                return usuarioExistente != null;
            }
        }
    }
}