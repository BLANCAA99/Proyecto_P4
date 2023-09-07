using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Ciudadano.Commands.DeleteCiudadanoCommand
{
    public class DeleteCiudadanoCommand : DB
    {
        public DeleteCiudadanoCommand() : base()
        {
        }
        public void Execute(int id)
        {
            var ciudadano = this.db.Ciudadanos.FirstOrDefault(x => x.Id_Ciudadanos == id);
            this.db.Ciudadanos.Remove(ciudadano);
            this.db.SaveChanges();
        }
    }
}
