using Applicacion.Usuarios.Queries.GetUserByIdQuery;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Usuarios.Commands.UpdateUserCommand
{

    public class UpdateUserCommand
    {
        private readonly GetUserByIdQuery getUserByIdQuery;
        private readonly Proyecto_FinalEntities db;
        public UpdateUserCommand()
        {
            this.getUserByIdQuery = new GetUserByIdQuery();
            this.db = new Proyecto_FinalEntities();
        }
        public void Execute(UpdateUserCommandModel model)
        {
            var usuario = this.db.Usuarios.FirstOrDefault(x => x.Codigo == model.Codigo);
            usuario.NombreCompleto = model.NombreCompleto;
            usuario.Contraseña = model.Contraseña;
            usuario.NumeroIdentidad = model.NumeroIdentidad;
            usuario.Rol=model.Rol;
            usuario.Telefono=model.Telefono;
            usuario.CorreoElectronico=model.CorreoElectronico;
            usuario.Genero=model.Genero;
            this.db.SaveChanges();
        }
    }
    
}
