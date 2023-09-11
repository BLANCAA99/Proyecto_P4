using Applicacion.Vacuna.Commands.DeleteVacunaCommand;
using Applicacion.Vacuna.Commands.CreateVacunaCommand;
using Applicacion.Vacuna.Commands.UpdateVacunaCommand;
using Applicacion.Vacuna.QueriesVacuna.GetVacunaByIdQuery;
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
    public partial class Vacunas : Form
    {
        private readonly Util util;
        public Vacunas()
        {
            this.util = new Util();
            InitializeComponent();
        }
        private bool VacunaExiste(string nombre)
        {
            using (var dbContext = new Proyecto_FinalEntities())
            {
                var Nombre = dbContext.Vacunas.FirstOrDefault(u => u.Nombre == nombre);
                return Nombre != null;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var createVacunaCommand = new CreateVacunaCommand();
            var model = new CreateVacunaCommandModel();
            string nombreVacuna = txtNombre.Text;
            bool vacunaExiste = VacunaExiste(nombreVacuna);

            if (vacunaExiste)
            {
                MessageBox.Show("El nombre de la vacuna ya existe en la base de datos. Introduce un nombre único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            try
            {
                model.Codigo = Convert.ToInt32(txtCodigo.Text);
                model.Fabricante = txtFabricante.Text;
                model.Nombre = txtNombre.Text;
                model.Fecha_Emision = dtpEmision.Value;
                model.Fecha_Vencimiento = dtpFechaVencimiento.Value;
                model.Numero_Lote = txtLote.Text;

                if (model.Fecha_Vencimiento < model.Fecha_Emision)
                {
                    MessageBox.Show("La fecha de vencimiento debe ser posterior a la fecha de emisión.");
                    return;
                }
                if (rbtDonada.Checked)
                {
                    model.Estatus = "Donada";
                }
                else if (rbtComprada.Checked)
                {
                    model.Estatus = "Comprada";
                }
                createVacunaCommand.Execute(model);
                this.util.LimpiarControlesDeTexto(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ya existe un codigo de vacuna identico, Ingrese uno nuevo.");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var getVacunaByIdQuery = new GetVacunaByIdQuery();
            var model = getVacunaByIdQuery.Execute(Convert.ToInt32(txtCodigo.Text));
            txtFabricante.Text = model.Fabricante;
            txtNombre.Text = model.Nombre;
            txtLote.Text = model.Numero_Lote;
            dtpEmision.Value = (DateTime)model.Fecha_Emision;
            dtpFechaVencimiento.Value = (DateTime)model.Fecha_Vencimiento;
            if (model.Estatus == "Donada")
            {
                rbtDonada.Checked = true;
            }
            else
            {
                rbtComprada.Checked = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var updateVacunaCommand = new UpdateVacunaCommand();
            var model = new UpdateVacunaCommandModel();
            model.Codigo = Convert.ToInt32(txtCodigo.Text);
            model.Nombre = txtNombre.Text;
            model.Fabricante = txtFabricante.Text;
            model.Fecha_Emision = dtpEmision.Value;
            model.Fecha_Vencimiento = dtpEmision.Value;
            model.Numero_Lote = txtLote.Text;
            if (rbtDonada.Checked)
            {
                model.Estatus = "Donada";
            }
            else if (rbtComprada.Checked)
            {
                model.Estatus = "Comprada";
            }
            updateVacunaCommand.Execute(model);
            this.util.LimpiarControlesDeTexto(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var deleteVacunaCommand = new DeleteVacunaCommand();
            deleteVacunaCommand.Execute(Convert.ToInt32(txtCodigo.Text));
            this.util.LimpiarControlesDeTexto(this);
        }
    }
}
