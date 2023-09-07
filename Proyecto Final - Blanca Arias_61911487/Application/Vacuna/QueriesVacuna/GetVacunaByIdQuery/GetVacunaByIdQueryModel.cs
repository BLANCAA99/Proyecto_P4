using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Vacuna.QueriesVacuna.GetVacunaByIdQuery
{
    public class GetVacunaByIdQueryModel
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Fabricante { get; set; }
        public Nullable<System.DateTime> Fecha_Emision { get; set; }
        public Nullable<System.DateTime> Fecha_Vencimiento { get; set; }
        public string Numero_Lote { get; set; }
        public string Estatus { get; set; }
    }
}
