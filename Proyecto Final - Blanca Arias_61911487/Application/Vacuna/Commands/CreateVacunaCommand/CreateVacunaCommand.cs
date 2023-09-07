using Applicacion.Vacuna.Commands.CreateVacunaCommand;
using Applicacion.Vacuna.MapVacuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Vacuna.Commands.CreateVacunaCommand
{
    public class CreateVacunaCommand : DB
    {
        public CreateVacunaCommand() : base()
        {
            
        }
        public void Execute(CreateVacunaCommandModel model)
        {
            DataAccess.Vacuna vacuna = AutoMapperVacuna.getMapper()
                                                                  .Map<DataAccess.Vacuna>(model);
            this.db.Vacunas.Add(vacuna);
            this.db.SaveChanges();
        }
    }
}
