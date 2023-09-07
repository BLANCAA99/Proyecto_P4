using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Usuarios.Commands.DeleteUserCommand
{
    public class DeleteUserCommand
    {
        private readonly Proyecto_FinalEntities db;
        public DeleteUserCommand()
        {
            this.db = new Proyecto_FinalEntities();
        }
       public void Execute(int codigo)
        {
            var usuario = this.db.Usuarios.FirstOrDefault(x => x.Codigo == codigo);
            this.db.Usuarios.Remove(usuario);
            this.db.SaveChanges();
        }
    }
}
