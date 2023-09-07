using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Usuarios.Commands.UpdateUserCommand
{
    public class UpdateUserCommandModel
    {
        public int Codigo { get; set; }
        public string Contraseña { get; set; }
        public string NumeroIdentidad { get; set; }
        public string NombreCompleto { get; set; }
        public string Genero { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
    }
}
