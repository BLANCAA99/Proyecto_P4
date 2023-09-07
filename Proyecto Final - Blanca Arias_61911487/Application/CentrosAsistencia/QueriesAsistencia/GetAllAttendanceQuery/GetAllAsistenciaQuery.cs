using DataAccess;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.CentrosAsistencia.QueriesAsistencia.GetAllAttendanceQuery
{
    public class GetAllAsistenciaQuery
    {
            private readonly Proyecto_FinalEntities db;

            public GetAllAsistenciaQuery()
            {
                this.db = new Proyecto_FinalEntities();
            }
            public List<GetAllAsistenciaQueryModel> Execute()
            {
                List<GetAllAsistenciaQueryModel> list = this.db.CentrosAsistencias.Select(x => new GetAllAsistenciaQueryModel { Id_Asistencia = x.Id_Asistencia, Descripcion = x.Descripcion, Direccion = x.Direccion, Estatus = x.Estatus }).ToList();
                return list;
            }
        }
}
