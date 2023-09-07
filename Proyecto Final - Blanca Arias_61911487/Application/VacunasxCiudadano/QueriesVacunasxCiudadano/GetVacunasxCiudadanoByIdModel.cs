using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.VacunasxCiudadano.QueriesVacunasxCiudadano
{
    public class GetVacunasxCiudadanoByIdModel
    {
        public int Numero_Dosis { get; set; }
        public int Ciudadano_ID { get; set; }
        public int Centro_Asistencia_ID { get; set; }
        public int Codigo_Vacuna { get; set; }
        public Nullable<System.DateTime> Fecha_Aplicacion { get; set; }
    }
}
