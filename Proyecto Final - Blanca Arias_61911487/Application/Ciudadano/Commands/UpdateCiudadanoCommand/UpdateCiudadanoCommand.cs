using Applicacion.Ciudadano.Commands.UpdateCiudadanoCommand;
using Applicacion.Ciudadano.MapCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Ciudadano.Commands.UpdateCiudadanoCommand
{
    public class UpdateCiudadanoCommand : DB
    {
        public UpdateCiudadanoCommand() : base()
        {
        }
        public void Execute(UpdateCiudadanoCommandModel model)
        {
            var ciudadano = this.db.Ciudadanos.FirstOrDefault(x => x.Id_Ciudadanos == model.Id_Ciudadanos);
            AutoMapperCiudadano.getMapper().Map(model, ciudadano);
            this.db.SaveChanges();
        }
    }
}
