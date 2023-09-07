using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.CentrosAsistencia.QueriesAsistencia.GetAttendanceByIdQuery
{
   public class GetAsistenciaByIdQuery
    {
        private readonly Proyecto_FinalEntities db;

        public GetAsistenciaByIdQuery()
        {
            this.db = new Proyecto_FinalEntities();
        }
        public GetAsistenciaByIdQueryModel Execute(int codigo)
        {
            var Asistencia = this.db.CentrosAsistencias.FirstOrDefault(x => x.Id_Asistencia == codigo);
            var model = new GetAsistenciaByIdQueryModel { Id_Asistencia = Asistencia.Id_Asistencia, Descripcion = Asistencia.Descripcion, Direccion = Asistencia.Direccion, Ciudad = Asistencia.Ciudad, Capacidad_Atencion = Asistencia.Capacidad_Atencion, Cantidad_Medicos = Asistencia.Cantidad_Medicos, Cantidad_Enfermeras = Asistencia.Cantidad_Enfermeras, Estatus = Asistencia.Estatus };
            return model;
        }
    }
}
