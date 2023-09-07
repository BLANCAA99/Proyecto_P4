using Applicacion.Ciudadano.Commands.CreateCiudadanoCommand;
using Applicacion.Ciudadano.MapCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Ciudadano.Commands.CreateCiudadanoCommand
{
   public class CreateCiudadanoCommand : DB
    {
        // private readonly Proyecto_FinalEntities db;

        public CreateCiudadanoCommand() : base()
        {
            //    this.db = new Proyecto_FinalEntities();
        }
        public void Execute(CreateCiudadanoCommandModel model)
        {
            DataAccess.Ciudadano ciudadano = AutoMapperCiudadano.getMapper()
                                                                                  .Map<DataAccess.Ciudadano>(model);
            this.db.Ciudadanos.Add(ciudadano);
            this.db.SaveChanges();
        }
    }
}
