using Applicacion.CentrosAsistencia.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.CentrosAsistencia.Commands.UpdateAsistenciaCommand
{
    public  class UpdateAsistenciaCommand : DB
    {
        public UpdateAsistenciaCommand() : base()
        {
        }
        public void Execute(UpdateAsistenciaCommandModel model)
        {
            var asistencia = this.db.CentrosAsistencias.FirstOrDefault(x => x.Id_Asistencia == model.Id_Asistencia);
            AutoMapperCentrosAsistencia.getMapper().Map(model, asistencia);
            this.db.SaveChanges();
        }
    }
}
