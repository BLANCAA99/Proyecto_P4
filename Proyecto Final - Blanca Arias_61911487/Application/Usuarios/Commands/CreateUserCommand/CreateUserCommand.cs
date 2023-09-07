using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Usuarios.Commands.CreateUserCommand
{
    public class CreateUserCommand
    {

        private readonly Proyecto_FinalEntities db;

        public CreateUserCommand()
        {
            this.db = new Proyecto_FinalEntities();
        }
        public void Execute(CreateUserCommandModel model)
        {
            Usuario usuario = new Usuario { 
                Codigo = model.Codigo,
                Contraseña = model.Contraseña,
                NombreCompleto = model.NombreCompleto,
                NumeroIdentidad = model.NumeroIdentidad,
                Genero = model.Genero,
                CorreoElectronico = model.CorreoElectronico,
                Telefono = model.Telefono,
                Rol = model.Rol
            };
         this.db.Usuarios.Add(usuario);
            this.db.SaveChanges();
        }
    }
}
