using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.CentrosAsistencia.Commands.DeleteAsistenciaCommand
{   
    public class DeleteAsistenciaCommand : DB
    {
        public DeleteAsistenciaCommand() : base()
        {            
        }
        public void Execute(int id)
        {
            var asistencia = this.db.CentrosAsistencias.FirstOrDefault(x=>x.Id_Asistencia==id);
            this.db.CentrosAsistencias.Remove(asistencia);
            this.db.SaveChanges();
        }
    }
}
