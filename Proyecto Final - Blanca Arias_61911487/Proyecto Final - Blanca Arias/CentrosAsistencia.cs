using Applicacion.CentrosAsistencia.Commands.CreateAsistenciaCommand;
using Applicacion.CentrosAsistencia.Commands.DeleteAsistenciaCommand;
using Applicacion.CentrosAsistencia.Commands.UpdateAsistenciaCommand;
using Applicacion.CentrosAsistencia.QueriesAsistencia.GetAttendanceByIdQuery;
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
    public partial class CentrosAsistencia : Form
    {
        private readonly Util util;
        public CentrosAsistencia()
        {
            this.util = new Util();
            InitializeComponent();
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var createAsistenciaCommand = new CreateAsistenciaCommand();
            var model = new CreateAsistenciaCommandModel();
            model.Id_Asistencia = Convert.ToInt32(txtIdAsistencia.Text);
            model.Descripcion = txtDescripcion.Text;
            model.Direccion = txtDireccion.Text;
            model.Ciudad = txtCiudad.Text;
            model.Cantidad_Medicos = Convert.ToInt32(txtCantidadMedicos.Text);
            model.Cantidad_Enfermeras = Convert.ToInt32(txtCantidadEnfermeras.Text);
            model.Capacidad_Atencion = Convert.ToInt32(txtCapacidadAtencion.Text);
            if (rbtPublico.Checked)
            {
                model.Estatus = "Público";
            }
            else if (rbtPrivado.Checked)
            {
                model.Estatus = "Privado";
            }
            createAsistenciaCommand.Execute(model);
            this.util.LimpiarControlesDeTexto(this);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var updateAsistenciaCommand = new UpdateAsistenciaCommand();
            var model = new UpdateAsistenciaCommandModel();
            model.Id_Asistencia = Convert.ToInt32(txtIdAsistencia.Text);
            model.Descripcion = txtDescripcion.Text;
            model.Direccion = txtDireccion.Text;
            model.Ciudad = txtCiudad.Text;
            model.Cantidad_Medicos = Convert.ToInt32(txtCantidadMedicos.Text);
            model.Cantidad_Enfermeras = Convert.ToInt32(txtCantidadEnfermeras.Text);
            model.Capacidad_Atencion = Convert.ToInt32(txtCapacidadAtencion.Text);
            if (rbtPublico.Checked)
            {
                model.Estatus = "Público";
            }
            else if (rbtPrivado.Checked)
            {
                model.Estatus = "Privado";
            }
            updateAsistenciaCommand.Execute(model);
            this.util.LimpiarControlesDeTexto(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var getAsistenciaByIdQuery = new GetAsistenciaByIdQuery();
            var model = getAsistenciaByIdQuery.Execute(Convert.ToInt32(txtIdAsistencia.Text));
            txtDescripcion.Text = model.Descripcion;
            txtDireccion.Text = model.Direccion;
            txtCiudad.Text = model.Ciudad;
            txtCantidadEnfermeras.Text = model.Cantidad_Enfermeras.ToString();
            txtCantidadMedicos.Text = model.Cantidad_Medicos.ToString();
            txtCapacidadAtencion.Text = model.Capacidad_Atencion.ToString();
            if (model.Estatus == "Publico")
            {
               rbtPublico.Checked = true;
            }
            else
            {
                rbtPrivado.Checked = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var deleteAsistenciaCommand = new DeleteAsistenciaCommand();
            deleteAsistenciaCommand.Execute(Convert.ToInt32(txtIdAsistencia.Text));
            this.util.LimpiarControlesDeTexto(this);
        }
    }
}
