using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final___Blanca_Arias
{
    public class Util
    {
        public void LimpiarControlesDeTexto(Control control)
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
