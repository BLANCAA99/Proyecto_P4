using DataAccess;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Usuarios.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery
    {
        private readonly Proyecto_FinalEntities db;

        public GetUserByIdQuery()
        {
            this.db = new Proyecto_FinalEntities();
        }
       public GetUserByIdQueryModel Execute(int codigo)
        {
            var usuario = this.db.Usuarios.FirstOrDefault(x => x.Codigo == codigo);
            if (usuario == null) return null;
            var model = new GetUserByIdQueryModel { Codigo = usuario.Codigo, NumeroIdentidad = usuario.NumeroIdentidad, NombreCompleto = usuario.NombreCompleto, Rol = usuario.Rol, Contraseña = usuario.Contraseña, CorreoElectronico = usuario.CorreoElectronico, Genero = usuario.Genero, Telefono = usuario.Telefono };
            return model;
        }
    }
}
