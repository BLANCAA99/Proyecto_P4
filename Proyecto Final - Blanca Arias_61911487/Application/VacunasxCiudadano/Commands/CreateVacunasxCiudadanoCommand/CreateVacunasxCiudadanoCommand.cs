using Applicacion.VacunasxCiudadano.Commands.CreateVacunasxCiudadanoCommand;
using Applicacion.VacunasxCiudadano.MapVacunaxCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.VacunasxCiudadano.Commands.CreateVacunasxCiudadanoCommand
{
    public class CreateVacunasxCiudadanoCommand: DB
    {
        public CreateVacunasxCiudadanoCommand() : base()
        {

        }
        public void Execute(CreateVacunasxCiudadanoCommandModel model)
        {
            DataAccess.VacunasxCiudadano vacunaxciudadano = AutoMapperVacunaxCiudadano.getMapper()
                                                                  .Map<DataAccess.VacunasxCiudadano>(model);
            this.db.VacunasxCiudadanoes.Add(vacunaxciudadano);
            this.db.SaveChanges();
        }
    }
}
