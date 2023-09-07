using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.VacunasxCiudadano.Commands.DeleteVacunasxCiudadanoCommand
{
    public class DeleteVacunasxCiudadanoCommand : DB
    {
        public DeleteVacunasxCiudadanoCommand() : base()
        {
        }
        public void Execute(int codigo)
        {
            var vacunaxciudadano = this.db.VacunasxCiudadanoes.FirstOrDefault(x => x.Numero_Dosis == codigo);
            this.db.VacunasxCiudadanoes.Remove(vacunaxciudadano);
            this.db.SaveChanges();
        }
    }
}
