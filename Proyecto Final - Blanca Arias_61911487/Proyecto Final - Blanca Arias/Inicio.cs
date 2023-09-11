using Applicacion;
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
using DataAccess;

namespace Proyecto_Final___Blanca_Arias
{
    public partial class Inicio : Form
    {
        private readonly Proyecto_FinalEntities db;
        public Inicio()
        {
            InitializeComponent();
            this.db = new Proyecto_FinalEntities();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        { 
                try
                {
                    int codigoUsuario = Convert.ToInt32(txtUsuario.Text); 
                    string contraseña = mskContraseña.Text;

                    var usuario = db.Usuarios.FirstOrDefault(u => u.Codigo == codigoUsuario && u.Contraseña == contraseña);

                    if (usuario != null)
                    {

                    Auth.codUsuario = usuario.Codigo; // Asigna el código de usuario autenticado
                    Auth.RolUsuario = usuario.Rol;

                    if (usuario.Rol == "1")
                        {
                        Administrador formAdmin = new Administrador();
                        formAdmin.Show();
                        this.Hide();
                    }
                   else if (usuario.Rol == "2")
                    {
                        OficialMedico formMedico = new OficialMedico();
                        formMedico.Show();
                        this.Hide(); 
                    }
                }
                else
                    {
                        MessageBox.Show("Código de usuario o contraseña incorrectos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario formRegistro = new Registro_de_Usuario();
            formRegistro.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
