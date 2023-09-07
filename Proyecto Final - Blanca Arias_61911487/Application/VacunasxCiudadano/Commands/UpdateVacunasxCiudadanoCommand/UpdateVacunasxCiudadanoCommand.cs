using Applicacion.VacunasxCiudadano.Commands.UpdateVacunasxCiudadanoCommand;
using Applicacion.VacunasxCiudadano.MapVacunaxCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.VacunasxCiudadano.Commands.UpdateVacunasxCiudadanoCommand
{
    public class UpdateVacunasxCiudadanoCommand : DB
    {
        public UpdateVacunasxCiudadanoCommand() : base()
        {
        }
        public void Execute(UpdateVacunasxCiudadanoCommandModel model)
        {
            var vacunaxciudadano = this.db.VacunasxCiudadanoes.FirstOrDefault(x => x.Numero_Dosis == model.Numero_Dosis);
            AutoMapperVacunaxCiudadano.getMapper().Map(model, vacunaxciudadano);
            this.db.SaveChanges();
        }
    }
}
