using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Applicacion.Usuarios.Queries.GetAllUsersQuery;
namespace Proyecto_Final___Blanca_Arias
{
    public partial class Lista_Usuarios : Form
    {
       private readonly GetAllUsersQuery getAllUsersQuery;
        public Lista_Usuarios()
        {
            InitializeComponent();
            this.getAllUsersQuery = new GetAllUsersQuery();
        }
        private void Lista_Usuarios_Load(object sender, EventArgs e)
        {
            //Inicializar el dataGridView1 de la lista de Usuarios
            this.dataGridView1.DataSource = this.getAllUsersQuery.Execute();
        }
    }
}
