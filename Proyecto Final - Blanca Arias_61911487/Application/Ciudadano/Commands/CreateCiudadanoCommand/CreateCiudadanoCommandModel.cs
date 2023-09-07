using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Ciudadano.Commands.CreateCiudadanoCommand
{
   public class CreateCiudadanoCommandModel
    {
        public int Id_Ciudadanos { get; set; }
        public string Nombre_Completo { get; set; }
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }
        public Nullable<int> Edad { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Direccion_Domicilio { get; set; }
        public string Estado_Civil { get; set; }
        public string Enfermedades_Base { get; set; }
    }
}
