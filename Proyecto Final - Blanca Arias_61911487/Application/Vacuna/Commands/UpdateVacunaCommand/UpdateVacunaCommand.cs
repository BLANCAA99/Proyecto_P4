using Applicacion.Vacuna.MapVacuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Vacuna.Commands.UpdateVacunaCommand
{
    public class UpdateVacunaCommand : DB
    {
        public UpdateVacunaCommand() : base()
        {
        }
        public void Execute(UpdateVacunaCommandModel model)
        {
            var vacuna = this.db.Vacunas.FirstOrDefault(x => x.Codigo == model.Codigo);
            AutoMapperVacuna.getMapper().Map(model, vacuna);
            this.db.SaveChanges();
        }
    }
}
