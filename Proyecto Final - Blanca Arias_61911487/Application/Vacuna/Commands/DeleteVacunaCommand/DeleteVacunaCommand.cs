using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Vacuna.Commands.DeleteVacunaCommand
{
    public class DeleteVacunaCommand : DB
    {
        public DeleteVacunaCommand() : base()
        {
        }
        public void Execute(int codigo)
        {
            var vacuna = this.db.Vacunas.FirstOrDefault(x => x.Codigo == codigo);
            this.db.Vacunas.Remove(vacuna);
            this.db.SaveChanges();
        }
    }
}
