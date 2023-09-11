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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
        }

        private void modificarCentrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CentrosAsistencia Rg = new CentrosAsistencia();
                Rg.MdiParent = this;
                Rg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modificarVacunasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Vacunas Rg = new Vacunas();
                Rg.MdiParent = this;
                Rg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modificarCiudadanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ciudadanos Rg = new Ciudadanos();
                Rg.MdiParent = this;
                Rg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modificarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Modificar_Usuario Rg = new Modificar_Usuario ();
                Rg.MdiParent = this;
                Rg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crearUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Registro_de_Usuario Rg = new Registro_de_Usuario();
                Rg.MdiParent = this;
                Rg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Application.Exit();
                Inicio login = new Inicio();
                login.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
