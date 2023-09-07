using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.CentrosAsistencia.QueriesAsistencia.GetAllAttendanceQuery
{
    public class GetAllAsistenciaQueryModel
    {
        public int Id_Asistencia { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public Nullable<int> Capacidad_Atencion { get; set; }
        public Nullable<int> Cantidad_Medicos { get; set; }
        public Nullable<int> Cantidad_Enfermeras { get; set; }
        public string Estatus { get; set; }
    }
}
